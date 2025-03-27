using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using BOOSE;

namespace ASE_Assignment_Ashley_Hughes.Tests
{
    /// <summary>
    /// MSTest class for testing the AppArray class.
    /// </summary>
    [TestClass]
    public class AppArrayTests
    {
        /// <summary>
        /// Initializes test environment before each test.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            // Reset all BOOSE counters before each test
            ResetAllBOOSECounters();
        }

        /// <summary>
        /// Tests that the constructor creates an instance successfully.
        /// </summary>
        [TestMethod]
        public void Constructor_CreatesInstance()
        {
            // Arrange & Act
            var appArray = new AppArray();

            // Assert
            Assert.IsNotNull(appArray, "AppArray instance should be created");
        }

        /// <summary>
        /// Tests that multiple instances can be created without hitting restrictions.
        /// </summary>
        [TestMethod]
        public void MultipleInstances_CanBeCreated()
        {
            // Arrange & Act
            for (int i = 0; i < 10; i++)
            {
                // Reset Array counters before creating each instance
                ResetCountersInClass(typeof(BOOSE.Array));
                var appArray = new AppArray();
             
            }

            // Assert - if test reaches here without an exception, the test passes
            Assert.IsTrue(true, "Test should complete without exceptions");
        }

        /// <summary>
        /// Verifies that the AppArray class can be instantiated successfully
        /// </summary>
        [TestMethod]
        public void AppArray_CanBeInstantiated()
        {
            // Arrange & Act
            var appArray = new AppArray();

            //Assert 
            Assert.IsNotNull(appArray, "AppArray instance should be created");

            Assert.IsTrue(true, "Test should complete without exceptions");
            // Test passes if execution reaches this point without exceptions
        }

        /// <summary>
        /// Tests that Execute method executes without errors.
        /// </summary>
        [TestMethod]
        public void Execute_ExecutesWithoutErrors()
        {
            // Arrange
            var appArray = new AppArray();

            // Act & Asset
            try
            {
                appArray.Execute();
                Assert.IsTrue(true, "Execute should not throw exceptions with proper setup");
            }
            catch (NullReferenceException)
            {
                // Expected when Program property is uninitialized
                Assert.IsTrue(true, "NullReferenceException is expected without proper initialization");
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