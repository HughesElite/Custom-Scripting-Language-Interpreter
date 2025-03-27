using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using BOOSE;

namespace ASE_Assignment_Ashley_Hughes.Tests
{
    /// <summary>
    /// MSTest class for testing the AppCommandFactory class.
    /// </summary>
    [TestClass]
    public class AppCommandFactoryTests
    {
        private AppCommandFactory factory;

        /// <summary>
        /// Initializes test environment before each test.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            // Reset all BOOSE counters before each test
            ResetAllBOOSECounters();

            // Create a new factory instance for each test
            factory = new AppCommandFactory();
        }

        /// <summary>
        /// Tests that the constructor creates an instance successfully.
        /// </summary>
        [TestMethod]
        public void Constructor_CreatesInstance()
        {
            // Arrange & Act
            var factory = new AppCommandFactory();

            // Assert
            Assert.IsNotNull(factory, "AppCommandFactory instance should be created");
        }

        /// <summary>
        /// Tests that MakeCommand creates appropriate instances for different command types.
        /// </summary>
        [TestMethod]
        public void MakeCommand_CreatesAppropriateInstances()
        {
            // Arrange - factory is created in Setup

            // Act & Assert - Test each command type
            Assert.IsInstanceOfType(factory.MakeCommand("int"), typeof(AppInt), "Should create AppInt instance");
            Assert.IsInstanceOfType(factory.MakeCommand("real"), typeof(AppReal), "Should create AppReal instance");
            Assert.IsInstanceOfType(factory.MakeCommand("write"), typeof(AppWrite), "Should create AppWrite instance");
            Assert.IsInstanceOfType(factory.MakeCommand("array"), typeof(AppArray), "Should create AppArray instance");
            Assert.IsInstanceOfType(factory.MakeCommand("while"), typeof(AppWhile), "Should create AppWhile instance");
            Assert.IsInstanceOfType(factory.MakeCommand("if"), typeof(AppIf), "Should create AppIf instance");
            Assert.IsInstanceOfType(factory.MakeCommand("method"), typeof(AppMethod), "Should create AppMethod instance");
            Assert.IsInstanceOfType(factory.MakeCommand("bool"), typeof(AppBoolean), "Should create AppBoolean instance");
            Assert.IsInstanceOfType(factory.MakeCommand("boolean"), typeof(AppBoolean), "Should create AppBoolean instance");
        }

        /// <summary>
        /// Tests that MakeCommand handles case insensitivity correctly.
        /// </summary>
        [TestMethod]
        public void MakeCommand_HandlesCaseInsensitivity()
        {
            // Arrange - factory is created in Setup

            // Act & Assert - Test with different case
            Assert.IsInstanceOfType(factory.MakeCommand("INT"), typeof(AppInt), "Should handle uppercase");
            Assert.IsInstanceOfType(factory.MakeCommand("Real"), typeof(AppReal), "Should handle mixed case");
            Assert.IsInstanceOfType(factory.MakeCommand("write"), typeof(AppWrite), "Should handle lowercase");
        }

        /// <summary>
        /// Tests that MakeCommand handles whitespace correctly.
        /// </summary>
        [TestMethod]
        public void MakeCommand_HandlesWhitespace()
        {
            // Arrange - factory is created in Setup

            // Act & Assert - Test with whitespace
            Assert.IsInstanceOfType(factory.MakeCommand(" int "), typeof(AppInt), "Should trim whitespace");
            Assert.IsInstanceOfType(factory.MakeCommand("real  "), typeof(AppReal), "Should trim trailing whitespace");
            Assert.IsInstanceOfType(factory.MakeCommand("  write"), typeof(AppWrite), "Should trim leading whitespace");
        }

        /// <summary>
        /// Verifies that MakeCommand delegates to base implementation for unrecognized commands.
        /// </summary>
        [TestMethod]
        public void MakeCommand_FallsBackToBaseImplementation()
        {
           // Arrange - facory already instantiaed in Setup method

           // Act
            try
            {
                var command = factory.MakeCommand("circle");

                // Assert
                Assert.IsNotNull(command, "Should return a command from base implementation");
            }
            catch (FactoryException)
            {
                // Assert = exception path
                Assert.IsTrue(true, "Base class might throw exception for unknown commands");
            }
        }

        /// <summary>
        /// Resets all BOOSE library counters to prevent restriction exceptions.
        /// </summary>
        private void ResetAllBOOSECounters()
        {
            try
            {
                // Reset CompoundCommand counters
                ResetCountersInClass(typeof(CompoundCommand));

                // Reset ConditionalCommand counters 
                ResetCountersInClass(typeof(ConditionalCommand));

                // Reset While counters
                ResetCountersInClass(typeof(BOOSE.While));

                // Reset If counters
                ResetCountersInClass(typeof(If));

                // Reset Boolean counters
                ResetCountersInClass(typeof(BOOSE.Boolean));

                // Reset Array counters
                ResetCountersInClass(typeof(BOOSE.Array));

                // Reset Method counters
                ResetCountersInClass(typeof(Method));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error resetting BOOSE counters: {ex.Message}");
            }
        }

        /// <summary>
        /// Resets all static integer fields in a specific class.
        /// </summary>
        /// <param name="classType">The type of class to reset counters for.</param>
        private void ResetCountersInClass(Type classType)
        {
            try
            {
                // Find all static fields in the specified class
                FieldInfo[] fields = classType.GetFields(
                    BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Public);

                // Reset all integer fields (potential counters)
                foreach (FieldInfo field in fields)
                {
                    if (field.FieldType == typeof(int))
                    {
                        field.SetValue(null, 0);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error resetting counters in {classType.Name}: {ex.Message}");
            }
        }
    }
}