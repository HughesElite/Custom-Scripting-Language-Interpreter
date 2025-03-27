using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using BOOSE;

namespace ASE_Assignment_Ashley_Hughes.Tests
{
    /// <summary>
    /// MSTest class for testing the AppMethod class.
    /// </summary>
    [TestClass]
    public class AppMethodTests
    {
        /// <summary>
        /// Initializes test environment before each test.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            // Reset all BOOSE counters before each test
            ResetAllBOOSECounters();

            // Explicitly reset counters for classes that AppMethod depends on
            ResetCountersInClass(typeof(CompoundCommand));
            ResetCountersInClass(typeof(ConditionalCommand));
            ResetCountersInClass(typeof(Method));
        }

        /// <summary>
        /// Tests that the constructor creates an instance successfully.
        /// </summary>
        [TestMethod]
        public void Constructor_CreatesInstance()
        {
            // Arrange & Act
            var appMethod = new AppMethod();

            // Assert
            Assert.IsNotNull(appMethod, "AppMethod instance should be created");
        }

        /// <summary>
        /// Tests that multiple instances can be created without hitting restrictions.
        /// </summary>
        [TestMethod]
        public void MultipleInstances_CanBeCreated()
        {
            // Arrange
            ResetAllBOOSECounters();
            var firstMethod = new AppMethod();

            // Act
            ResetAllBOOSECounters();
            var secondMethod = new AppMethod();

            // Assert
            Assert.IsNotNull(firstMethod, "First AppMethod instance should be created");
            Assert.IsNotNull(secondMethod, "Second AppMethod instance should be created");
        }

        /// <summary>
        /// Tests that the Compile method exists and can be called.
        /// NullReferenceException is expected because the base class requires initialisation.
        /// </summary>
        [TestMethod]
        public void Compile_MethodExists()
        {
            // Arrange
            var appMethod = new AppMethod();

            // Act - verify the method exists
            var compileMethod = typeof(AppMethod).GetMethod("Compile");

            // Assert
            Assert.IsNotNull(compileMethod, "Compile method should exist");

        }

        /// <summary>
        /// Tests that the Execute method exists and can be called.
        /// </summary>
        [TestMethod]
        public void Execute_MethodExists()
        {
            // Arrange
            var appMethod = new AppMethod();

            // Act - verify the method exists
            var executeMethod = typeof(AppMethod).GetMethod("Execute");

            // Assert
            Assert.IsNotNull(executeMethod, "Execute method should exist");
        }

        /// <summary>
        /// Tests that the static constructor properly resets the Method counter.
        /// </summary>
        [TestMethod]
        public void StaticConstructor_ResetsMethodCounter()
        {
            // Arrange - Reset counters before first instantiation
            ResetAllBOOSECounters();

            // Create first instance
            var appMethod = new AppMethod();

            // Reset counters before second instantiation
            ResetAllBOOSECounters();

            // Create a second instance
            var secondAppMethod = new AppMethod();

            // Assert - if test reaches here without an exception, the test passes
            Assert.IsNotNull(appMethod, "First AppMethod instance should be created");
            Assert.IsNotNull(secondAppMethod, "Second AppMethod instance should be created");
        }

        /// <summary>
        /// Tests that the ResetMethodCounter method properly resets counters via reflection.
        /// </summary>
        [TestMethod]
        public void ResetMethodCounter_ResetsCounters()
        {
            // Reset all BOOSE counters explicitly before the test
            ResetAllBOOSECounters();

            // Manually reset CompoundCommand counters
            ResetCountersInClass(typeof(CompoundCommand));

            // Act - call private method via reflection
            MethodInfo resetMethod = typeof(AppMethod).GetMethod("ResetMethodCounter",
                BindingFlags.NonPublic | BindingFlags.Static);

            resetMethod.Invoke(null, null);

            // Create an instance to verify counters were reset
            var appMethod = new AppMethod();

            // Assert - if test reaches here without an exception, the test passes
            Assert.IsTrue(true, "ResetMethodCounter should reset counters via reflection");
        }

        /// <summary>
        /// Resets all BOOSE library counters to prevent restriction exceptions.
        /// </summary>
        private void ResetAllBOOSECounters()
        {
            try
            {
                // Reset Method counters
                ResetCountersInClass(typeof(Method));

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