using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using BOOSE;

namespace ASE_Assignment_Ashley_Hughes.Tests
{
    [TestClass]
    public class AppWhileTests
    {
        [TestInitialize]
        public void Setup()
        {
            // Reset all BOOSE counters before each test
            ResetAllBOOSECounters();
        }

        [TestMethod]
        public void Constructor_CreatesInstance()
        {
            // Arrange & Act
            var appWhile = new AppWhile();

            // Assert
            Assert.IsNotNull(appWhile, "AppWhile instance should be created");
        }

        [TestMethod]
        public void MultipleInstances_CanBeCreated()
        {
           
            // Arrange & Act
            for (int i = 0; i < 10; i++)
            {
                // Reset Boolean counters before creating each instance to avoid hitting variable limits
                ResetCountersInClass(typeof(BOOSE.Boolean));

                var appWhile = new AppWhile();
                // No need to call any methods, just create instances
            }

            // Assert - if test reaches here without an exception, the test passes
            Assert.IsTrue(true, "Test should complete without exceptions");
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