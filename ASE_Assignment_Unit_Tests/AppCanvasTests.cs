using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace ASE_Assignment_Ashley_Hughes.Tests
{
    /// <summary>
    /// MSTest class for testing the AppCanvas class.
    /// </summary>
    [TestClass]
    public class AppCanvasTests
    {
        private AppCanvas canvas;

        // <summary>
        /// Initializes a new instance of the AppCanvas before each test.
        /// </summary>
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

        /// <summary>
        /// Tests that the DrawTo method updates the position and draws a line correctly.
        /// </summary>
        [TestMethod]
        public void DrawTo_UpdatesPositionAndDrawsLine()
        {
            // Arrange
            int startX = 0;
            int startY = 0;
            int endX = 150;
            int endY = 100;


            //Act
            canvas.MoveTo(startX, startY);
            canvas.DrawTo(endX, endY);

            //Asset
            Assert.AreEqual(endX, canvas.Xpos, "X position was not updated correctly after DrawTo.");
            Assert.AreEqual(endY, canvas.Ypos, "Y position was not updated correctly after DrawTo.");
        }

        /// <summary>
        /// Tests that a sequence of drawing commands executes without errors.
        /// </summary>
        [TestMethod]
        public void MultiLineProgram_ExecutesCommandsWithNoErrors()
        {
           // Arrange
            string[] commands = new string[]
            {
                "moveto 100,100",
                "pen 0,255,255",
                "circle 50",
                "pen 255,0,0",
                "moveto 150,50",
                "rect 50,100"
            };

            int expectedX = 0;
            int expectedY = 0;

            //Act
            foreach (var command in commands)
            {
                try
                {
                    string[] parts = command.Split(' ');

                    // Execute the command based on its type
                    switch (parts[0].ToLower())
                    {
                        case "moveto":
                            var moveToCoordinates = parts[1].Split(','); // Split coordinates
                            canvas.MoveTo(int.Parse(moveToCoordinates[0]), int.Parse(moveToCoordinates[1])); // Move to new position
                            canvas.MoveTo(expectedX, expectedY); // Checks if new position has correct x,y coordinates 
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

                    //Assert
                    if (parts[0].ToLower() != "pen")
                    {

                        Assert.AreEqual(expectedX, canvas.Xpos, $"Expected X position: {expectedX}, but got: {canvas.Xpos}");
                        Assert.AreEqual(expectedY, canvas.Ypos, $"Expected Y position: {expectedY}, but got: {canvas.Ypos}");
                    }
                }
                catch (Exception ex)
                {
                    Assert.Fail($"An exception was thrown during execution of command '{command}': {ex.Message}");// Fail if an exception occurs
                }

            }
        }
    }
}