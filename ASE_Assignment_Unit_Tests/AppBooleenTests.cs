using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ASE_Assignment_Ashley_Hughes.Tests
{
    [TestClass]
    public class AppBooleanTests
    {
        [TestMethod]
        public void Constructor_CreatesInstance()
        {
            // Arrange & Act
            var appBoolean = new AppBoolean();

            // Assert
            Assert.IsNotNull(appBoolean, "AppBoolean instance should be created");
        }

        [TestMethod]
        public void Restrictions_DoesNotThrowException()
        {
            // Arrange
            var appBoolean = new AppBoolean();

            // Act
            appBoolean.Restrictions();

            // Assert - if test reaches here without an exception, the test passes
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void MultipleInstances_CanBeCreated()
        {
            // Arrange & Act
            for (int i = 0; i < 100; i++)
            {
                var appBoolean = new AppBoolean();
                appBoolean.Restrictions(); // Call restrictions on each
            }

            // Assert - if test reaches here without an exception, the test passes
            Assert.IsTrue(true);
        }
    }
}