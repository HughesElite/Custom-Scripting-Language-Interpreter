using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using BOOSE;

namespace ASE_Assignment_Ashley_Hughes.Tests
{
    /// <summary>
    /// MSTest class for testing the BooseReset utility class functionality.
    /// </summary>
    [TestClass]
    public class BooseResetTests
    {
        private AppCommandFactory factory;
        private AppCanvas canvas;

        /// <summary>
        /// Initializes test environment before each test.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            // Reset all BOOSE counters before each test
            BooseReset.ResetAllBOOSECounters();
            factory = new AppCommandFactory();
            canvas = new AppCanvas();
        }

        /// <summary>
        /// Tests that ResetAllBOOSECounters successfully resets all class counters
        /// and allows creating multiple command instances.
        /// </summary>
        [TestMethod]
        public void ResetAllBOOSECounters_EnablesCreatingMultipleCommandInstances()
        {
            // Arrange
            AppCompoundCommand compoundCommand1;
            AppCompoundCommand compoundCommand2;

            // Act
            compoundCommand1 = new AppCompoundCommand();
            BooseReset.ResetAllBOOSECounters();
            compoundCommand2 = new AppCompoundCommand();

            // Assert
            Assert.IsNotNull(compoundCommand1, "First instance should be created");
            Assert.IsNotNull(compoundCommand2, "Second instance should be created after reset");
        }

        /// <summary>
        /// Tests that ResetAllBOOSECounters allows AppCommandFactory to create multiple 
        /// instances of different command types without hitting restrictions.
        /// </summary>
        [TestMethod]
        public void ResetAllBOOSECounters_EnablesFactoryToCreateMultipleCommands()
        {
            // Arrange - Command types to test
            string[] commandTypes = { "if", "while", "array", "bool", "method" };

            // Act & Assert - Create multiple instances of each command type
            foreach (string commandType in commandTypes)
            {
                for (int i = 0; i < 3; i++)
                {
                    // Reset counters before each creation
                    BooseReset.ResetAllBOOSECounters();

                    // Create command via factory
                    ICommand command = factory.MakeCommand(commandType);

                    // Verify command was created
                    Assert.IsNotNull(command, $"Factory should create {commandType} command (iteration {i + 1})");
                    Assert.IsInstanceOfType(command, GetExpectedTypeForCommand(commandType),
                        $"Command should be of the expected type for {commandType}");
                }
            }
        }

        /// <summary>
        /// Tests that ResetCountersInClass correctly resets counters for a specific class.
        /// </summary>
        [TestMethod]
        public void ResetCountersInClass_ResetsSpecificClassCounters()
        {
            // Arrange
            MethodInfo resetMethod = typeof(BooseReset).GetMethod("ResetCountersInClass",
                BindingFlags.NonPublic | BindingFlags.Static);

            // Act & Assert - Tries resetting Method class counters and creating instances
            for (int i = 0; i < 3; i++)
            {
                // Reset only Method counters
                resetMethod.Invoke(null, new object[] { typeof(Method) });

                // Create a Method instance
                AppMethod method = new AppMethod();

                // Verify it was created
                Assert.IsNotNull(method, $"Should create Method instance after resetting its counters (iteration {i + 1})");
            }
        }

        /// <summary>
        /// Tests that ResetAllBOOSECounters properly enables creating a working program.
        /// </summary>
        [TestMethod]
        public void ResetAllBOOSECounters_EnablesCreatingWorkingProgram()
        {
            // Arrange
            BooseReset.ResetAllBOOSECounters();

            // Act - Create a program and parser
            AppStoredProgram program = new AppStoredProgram(canvas);
            AppParser parser = new AppParser(factory, program);

            // Create a simple program with a circle command
            string simpleProgram = "circle 50";
            parser.ParseProgram(simpleProgram);

            // Assert - no exceptions when running program
            try
            {
                program.Run();
                // If we get here without exception, the test passes
                Assert.IsTrue(true, "Program should run without exceptions after reset");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Program execution failed with exception: {ex.Message}");
            }
        }

        /// <summary>
        /// Tests that BooseReset is called in AppCommandFactory constructor.
        /// </summary>
        [TestMethod]
        public void AppCommandFactory_CallsBooseResetInConstructor()
        {
            // Arrange & Act
            // Create multiple factories in sequence which works if BooseReset is called in constructor
            AppCommandFactory factory1 = new AppCommandFactory();
            AppCommandFactory factory2 = new AppCommandFactory();
            AppCommandFactory factory3 = new AppCommandFactory();

            // Assert - factories are created without exceptions
            Assert.IsNotNull(factory1, "First factory should be created");
            Assert.IsNotNull(factory2, "Second factory should be created");
            Assert.IsNotNull(factory3, "Third factory should be created");

            // Additional verification: create a command from each factory
            ICommand cmd1 = factory1.MakeCommand("if");
            ICommand cmd2 = factory2.MakeCommand("while");
            ICommand cmd3 = factory3.MakeCommand("bool");

            Assert.IsNotNull(cmd1, "First factory should create command");
            Assert.IsNotNull(cmd2, "Second factory should create command");
            Assert.IsNotNull(cmd3, "Third factory should create command");
        }

        /// <summary>
        /// Tests that ResetAllBOOSECounters handles exceptions gracefully.
        /// </summary>
        [TestMethod]
        public void ResetAllBOOSECounters_HandlesExceptionsGracefully()
        {
            // Act - Calls the method which will handle internal exceptions
            try
            {
                BooseReset.ResetAllBOOSECounters();
                // If we get here without exception, the test passes
                Assert.IsTrue(true, "ResetAllBOOSECounters should handle exceptions gracefully");
            }
            catch (Exception ex)
            {
                Assert.Fail($"ResetAllBOOSECounters should not throw exceptions to caller: {ex.Message}");
            }
        }

        /// <summary>
        /// Helper method to get the expected type for a command.
        /// </summary>
        /// <param name="commandType">The command type string.</param>
        /// <returns>The expected Type for the command.</returns>
        private Type GetExpectedTypeForCommand(string commandType)
        {
            switch (commandType.ToLower())
            {
                case "if":
                    return typeof(AppIf);
                case "while":
                    return typeof(AppWhile);
                case "array":
                    return typeof(AppArray);
                case "bool":
                case "boolean":
                    return typeof(AppBoolean);
                case "method":
                    return typeof(AppMethod);
                default:
                    return typeof(ICommand);
            }
        }
    }
}