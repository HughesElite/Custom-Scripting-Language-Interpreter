namespace CanvasAppTests
{
    [TestClass]
    public class AppCanvasUnitTests
    {
        [TestMethod]
        public void MoveTo_ValidPosition_UpdatesPenPositionCorrectly()
        {
            // Arrange
            var appCanvas = new AppCanvas();

            int expectedX = 100;
            int expectedY = 150;

            // Act
            appCanvas.MoveTo(expectedX, expectedY);

            // Assert
            Assert.AreEqual(expectedX, appCanvas.Xpos, "The X position of the pen is not updated correctly.");
            Assert.AreEqual(expectedY, appCanvas.Ypos, "The Y position of the pen is not updated correctly.");
        }

       
        
    }
}