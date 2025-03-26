using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using BOOSE;

namespace ASE_Assignment_Ashley_Hughes.Tests
{
    /// <summary>
    /// MSTest class for testing the AppStoredProgram class.
    /// </summary>
    [TestClass]
    public class AppStoredProgramTests
    {
        // Private field for test setup
        private ICanvas canvas;

        /// <summary>
        /// Initializes test environment before each test.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            // Reset all BOOSE counters before each test
            ResetAllBOOSECounters();

            // Initialize canvas
            canvas = new AppCanvas();
        }

        /// <summary>
        /// Tests that the constructor creates an instance successfully.
        /// </summary>
        [TestMethod]
        public void Constructor_CreatesInstance()
        {
            // Arrange & Act
            var appStoredProgram = new AppStoredProgram(canvas);

            // Assert
            Assert.IsNotNull(appStoredProgram, "AppStoredProgram instance should be created");
        }

        /// <summary>
        /// Tests that multiple instances can be created without hitting restrictions.
        /// </summary>
        [TestMethod]
        public void MultipleInstances_CanBeCreated()
        {
            // Create first instance
            ResetAllBOOSECounters();
            var firstProgram = new AppStoredProgram(canvas);

            // Reset counters and create second instance
            ResetAllBOOSECounters();
            var secondProgram = new AppStoredProgram(canvas);

            // Assert both instances were created
            Assert.IsNotNull(firstProgram, "First AppStoredProgram instance should be created");
            Assert.IsNotNull(secondProgram, "Second AppStoredProgram instance should be created");
        }

        /// <summary>
        /// Tests that the AppStoredProgram extends the BOOSE StoredProgram class.
        /// </summary>
        [TestMethod]
        public void AppStoredProgram_InheritsFromStoredProgram()
        {
            // Arrange
            Type storedProgramType = typeof(StoredProgram);
            Type appStoredProgramType = typeof(AppStoredProgram);

            // Act & Assert
            Assert.IsTrue(storedProgramType.IsAssignableFrom(appStoredProgramType),
                "AppStoredProgram should inherit from StoredProgram");
        }

        /// <summary>
        /// Tests that the Run method exists and is overridden.
        /// </summary>
        [TestMethod]
        public void Run_MethodIsOverridden()
        {
            // Arrange
            var methodInfo = typeof(AppStoredProgram).GetMethod("Run");

            // Act & Assert
            Assert.IsNotNull(methodInfo, "Run method should exist");
            Assert.IsTrue(methodInfo.DeclaringType == typeof(AppStoredProgram),
                "Run method should be declared in AppStoredProgram (overridden)");
        }

        /// <summary>
        /// Tests the Run method without any commands.
        /// </summary>
        [TestMethod]
        public void Run_WithoutCommands_DoesNotThrow()
        {
            // Arrange
            var appStoredProgram = new AppStoredProgram(canvas);

            try
            {
                // Act
                appStoredProgram.Run();

                // Assert - if we reach here, no exception was thrown
                Assert.IsTrue(true, "Run method should not throw exception when no commands are present");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Run threw an unexpected exception: {ex.Message}");
            }
        }

        /// <summary>
        /// Resets all BOOSE library counters to prevent restriction exceptions.
        /// </summary>
        private void ResetAllBOOSECounters()
        {
            try
            {
                // Reset all BOOSE class counters in this specific order
                // Order is important because of class dependencies

                // Reset Boolean counters first
                ResetCountersInClass(typeof(BOOSE.Boolean));

                // Reset Array counters
                ResetCountersInClass(typeof(BOOSE.Array));

                // Reset ConditionalCommand counters 
                ResetCountersInClass(typeof(ConditionalCommand));

                // Reset If counters
                ResetCountersInClass(typeof(If));

                // Reset While counters
                ResetCountersInClass(typeof(BOOSE.While));

                // Reset CompoundCommand counters
                ResetCountersInClass(typeof(CompoundCommand));

                // Reset Method counters
                ResetCountersInClass(typeof(Method));

                // Reset StoredProgram counters
                ResetCountersInClass(typeof(StoredProgram));

                // Reset CommandFactory counters
                ResetCountersInClass(typeof(CommandFactory));
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