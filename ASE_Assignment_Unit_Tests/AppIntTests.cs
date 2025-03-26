using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ASE_Assignment_Ashley_Hughes.Tests
{
    [TestClass]
    public class AppIntTests
    {
        [TestMethod]
        public void Constructor_CreatesInstance()
        {
            // Arrange & Act
            var appInt = new AppInt();

            // Assert
            Assert.IsNotNull(appInt, "AppInt instance should be created");
        }

        [TestMethod]
        public void Restrictions_DoesNotThrowException()
        {
            // Arrange
            var appInt = new AppInt();

            // Act
            appInt.Restrictions();

            // Assert - if test reaches here without an exception, the test passes
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void MultipleInstances_CanBeCreated()
        {
            // Arrange & Act
            for (int i = 0; i < 100; i++)
            {
                var appInt = new AppInt();
                appInt.Restrictions(); // Call restrictions on each
            }

            // Assert - if test reaches here without an exception, the test passes
            Assert.IsTrue(true);
        }
    }
}