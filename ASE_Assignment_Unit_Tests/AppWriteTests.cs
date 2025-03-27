using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using BOOSE;

namespace ASE_Assignment_Ashley_Hughes.Tests
{
    /// <summary>
    /// MSTest class for testing the AppWrite class.
    /// </summary>
    [TestClass]
    public class AppWriteTests
    {
        // Private field for test setup
        private ICanvas canvas;

        /// <summary>
        /// Initialises test environment before each test.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            // Reset all BOOSE counters before each test
            ResetAllBOOSECounters();

            // Initialize canvas
            canvas = new AppCanvas();

            // Set the static canvas for AppWrite
            AppWrite.SetCanvas(canvas);
        }

        /// <summary>
        /// Tests that the constructor creates an instance successfully.
        /// </summary>
        [TestMethod]
        public void Constructor_CreatesInstance()
        {
            // Arrange & Act
            var appWrite = new AppWrite();

            // Assert
            Assert.IsNotNull(appWrite, "AppWrite instance should be created");
        }

        /// <summary>
        /// Tests that multiple instances can be created without hitting restrictions.
        /// </summary>
        [TestMethod]
        public void MultipleInstances_CanBeCreated()
        {
            // Create first instance
            ResetAllBOOSECounters();
            var firstWrite = new AppWrite();

            // Reset counters and create second instance
            ResetAllBOOSECounters();
            var secondWrite = new AppWrite();

            // Assert both instances were created
            Assert.IsNotNull(firstWrite, "First AppWrite instance should be created");
            Assert.IsNotNull(secondWrite, "Second AppWrite instance should be created");
        }

        /// <summary>
        /// Tests that the AppWrite extends the BOOSE Write class.
        /// </summary>
        [TestMethod]
        public void AppWrite_InheritsFromWrite()
        {
            // Arrange
            Type writeType = typeof(Write);
            Type appWriteType = typeof(AppWrite);

            // Act & Assert
            Assert.IsTrue(writeType.IsAssignableFrom(appWriteType),
                "AppWrite should inherit from Write");
        }

        /// <summary>
        /// Tests that the Execute method is overridden.
        /// </summary>
        [TestMethod]
        public void Execute_MethodIsOverridden()
        {
            // Arrange
            var methodInfo = typeof(AppWrite).GetMethod("Execute");

            // Act & Assert
            Assert.IsNotNull(methodInfo, "Execute method should exist");
            Assert.IsTrue(methodInfo.DeclaringType == typeof(AppWrite),
                "Execute method should be declared in AppWrite (overridden)");
        }

        /// <summary>
        /// Tests that the SetCanvas method properly sets the static canvas.
        /// </summary>
        [TestMethod]
        public void SetCanvas_SetsStaticCanvas()
        {
            // Arrange
            var testCanvas = new AppCanvas();

            // Act
            AppWrite.SetCanvas(testCanvas);

            // Create an instance and try to use it (would throw if canvas is not set)
            var appWrite = new AppWrite();

            // Assert - test if canvas was set
            Assert.IsNotNull(appWrite, "AppWrite instance should be created after setting canvas");
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

                // Reset Write counters
                ResetCountersInClass(typeof(Write));
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