using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using BOOSE;

namespace ASE_Assignment_Ashley_Hughes.Tests
{
    /// <summary>
    /// MSTest class for testing the AppPeek class.
    /// </summary>
    [TestClass]
    public class AppPeekTests
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
            var appPeek = new AppPeek();

            // Assert
            Assert.IsNotNull(appPeek, "AppPeek instance should be created");
        }

        /// <summary>
        /// Tests that multiple instances can be created without hitting restrictions.
        /// </summary>
        [TestMethod]
        public void MultipleInstances_CanBeCreated()
        {
            // Create first instance
            ResetAllBOOSECounters();
            var firstPeek = new AppPeek();

            // Reset counters and create second instance
            ResetAllBOOSECounters();
            var secondPeek = new AppPeek();

            // Assert both instances were created
            Assert.IsNotNull(firstPeek, "First AppPeek instance should be created");
            Assert.IsNotNull(secondPeek, "Second AppPeek instance should be created");
        }

        /// <summary>
        /// Tests that the AppPeek extends the BOOSE Peek class.
        /// </summary>
        [TestMethod]
        public void AppPeek_InheritsFromPeek()
        {
            // Arrange
            Type peekType = typeof(Peek);
            Type appPeekType = typeof(AppPeek);

            // Act & Assert
            Assert.IsTrue(peekType.IsAssignableFrom(appPeekType),
                "AppPeek should inherit from Peek");
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

                // Reset Peek counters
                ResetCountersInClass(typeof(Peek));
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