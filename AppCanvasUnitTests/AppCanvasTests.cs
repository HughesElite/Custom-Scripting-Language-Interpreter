using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace ASE_Assignment_Ashley_Hughes.Tests
{
    [TestClass]
    public class AppCanvasTests
    {
        private AppCanvas canvas;

        [TestInitialize]
        public void Setup()
        {
            canvas = new AppCanvas();
        }

        [TestMethod]
        public void MoveTo_UpdatesXposAndYPos()
        {
            // Arrange
            int expectedX = 100;
            int expectedY = 150;

            // Act
            canvas.MoveTo(expectedX, expectedY);

            // Assert
            Assert.AreEqual(expectedX, canvas.Xpos, "X position was not updated correctly.");
            Assert.AreEqual(expectedY, canvas.Ypos, "Y position was not updated correctly.");
        }

        [TestMethod]
        public void DrawTo_UpdatesPositionAndDrawsLine()
        {
            // Arrange
            int startX = 50;
            int startY = 50;
            int endX = 150;
            int endY = 100;

         
            canvas.MoveTo(startX, startY);

            // Act
            canvas.DrawTo(endX, endY);

            // Assert
            Assert.AreEqual(endX, canvas.Xpos, "X position was not updated correctly after DrawTo.");
            Assert.AreEqual(endY, canvas.Ypos, "Y position was not updated correctly after DrawTo.");
        }
        [TestMethod]
        public void MultiLineProgram_ExecutesCommandsWithNoErrors()
        {
            // Arrange
            string[] commands = new string[]
            {
                "moveto 100,100",
                "pen 0,255,0",
                "circle 50",
                "pen 255,0,0",
                "moveto 150,50",
                "rect 50,100"
            };

            
            foreach (var command in commands)
            {
                try
                {
                    string[] parts = command.Split(' ');

                    switch (parts[0].ToLower())
                    {
                        case "moveto":
                            var moveToCoordinates = parts[1].Split(',');
                            canvas.MoveTo(int.Parse(moveToCoordinates[0]), int.Parse(moveToCoordinates[1]));
                            break;
                        case "pen":
                            var colorValues = parts[1].Split(',');
                            canvas.SetColour(int.Parse(colorValues[0]), int.Parse(colorValues[1]), int.Parse(colorValues[2]));
                            break;
                        case "circle":
                            canvas.Circle(int.Parse(parts[1]), false); 
                            break;
                        case "rect":
                            var rectDimensions = parts[1].Split(',');
                            canvas.Rect(int.Parse(rectDimensions[0]), int.Parse(rectDimensions[1]), false); 
                            break;
                        default:
                            Assert.Fail($"Unknown command: {parts[0]}");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Assert.Fail($"An exception was thrown during execution of command '{command}': {ex.Message}");
                }

            }
        }
    }
}