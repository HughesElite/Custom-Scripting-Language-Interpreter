using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ASE_Assignment_Ashley_Hughes.Tests
{
    [TestClass]
    public class AppRealTests
    {
        [TestMethod]
        public void Constructor_CreatesInstance()
        {
            // Arrange & Act
            var appReal = new AppReal();

            // Assert
            Assert.IsNotNull(appReal, "AppReal instance should be created");
        }

        [TestMethod]
        public void Restrictions_DoesNotThrowException()
        {
            // Arrange
            var appReal = new AppReal();

            // Act
            appReal.Restrictions();

            // Assert - if test reaches here without an exception, the test passes
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void MultipleInstances_CanBeCreated()
        {
            // Arrange & Act
            for (int i = 0; i < 100; i++)
            {
                var appReal = new AppReal();
                appReal.Restrictions(); // Call restrictions on each
            }

            // Assert - if test reaches here without an exception, the test passes
            Assert.IsTrue(true);
        }
    }
}