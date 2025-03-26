using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using BOOSE;

namespace ASE_Assignment_Ashley_Hughes.Tests
{
    /// <summary>
    /// MSTest class for testing the AppPoke class.
    /// </summary>
    [TestClass]
    public class AppPokeTests
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
            var appPoke = new AppPoke();

            // Assert
            Assert.IsNotNull(appPoke, "AppPoke instance should be created");
        }

        /// <summary>
        /// Tests that multiple instances can be created without hitting restrictions.
        /// </summary>
        [TestMethod]
        public void MultipleInstances_CanBeCreated()
        {
            // Create first instance
            ResetAllBOOSECounters();
            var firstPoke = new AppPoke();

            // Reset counters and create second instance
            ResetAllBOOSECounters();
            var secondPoke = new AppPoke();

            // Assert both instances were created
            Assert.IsNotNull(firstPoke, "First AppPoke instance should be created");
            Assert.IsNotNull(secondPoke, "Second AppPoke instance should be created");
        }

        /// <summary>
        /// Tests that the AppPoke extends the BOOSE Poke class.
        /// </summary>
        [TestMethod]
        public void AppPoke_InheritsFromPoke()
        {
            // Arrange
            Type pokeType = typeof(Poke);
            Type appPokeType = typeof(AppPoke);

            // Act & Assert
            Assert.IsTrue(pokeType.IsAssignableFrom(appPokeType),
                "AppPoke should inherit from Poke");
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

                // Reset Poke counters
                ResetCountersInClass(typeof(Poke));
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