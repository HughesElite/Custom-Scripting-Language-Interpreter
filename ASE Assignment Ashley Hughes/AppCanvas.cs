using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOOSE;
using static System.Windows.Forms.DataFormats;

namespace ASE_Assignment_Ashley_Hughes
{
    /// <summary>
    /// Represents a canvas that can be drawn on for the BOOSE interpreter.
    /// </summary>
    public class AppCanvas : ICanvas
    {
        private int xPos, yPos;
        int XCanvasSize, YCanvasSize;
        protected Color penColour;
        protected Pen Pen;
        protected Brush Brush;

        const int XSIZE = 548;
        const int YSIZE = 365;
        private int errorYPos = 10;
        Bitmap bm = new Bitmap(XSIZE, YSIZE);
        Graphics g;
        protected int penSize = 2;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppCanvas"/> class.
        /// </summary>
        public AppCanvas()
        {
            Set(XSIZE, YSIZE);
        }

        /// <summary>
        /// Gets or sets the current X position on the canvas.
        /// </summary>
        public int Xpos
        {
            get
            {
                return xPos;
            }
            set
            {
                xPos = value;
            }

        }

        /// <summary>
        /// Gets or sets the current Y position on the canvas.
        /// </summary>
        public int Ypos
        {
            get
            {
                return yPos;
            }
            set
            {
                yPos = value;
            }

        }

        /// <summary>
        /// Gets or sets the pen color used for drawing on the bitmap.
        /// </summary>
        public Object PenColour
        {
            get
            {
                return penColour;
            }
            set
            {
                penColour = (Color)value;

            }
        }

        /// <summary>
        /// Sets canvas size and initializes drawing tools.
        /// </summary>
        /// <param name="xsize">The width of the canvas.</param>
        /// <param name="ysize">The height of the canvas.</param>
        public void Set(int xsize, int ysize)
        {
            XCanvasSize = xsize;
            YCanvasSize = ysize;
            xPos = yPos = 0;
            XCanvasSize = xsize;
            Pen = new Pen(Color.Red, 3);
            Brush = new SolidBrush(Color.Black);
            g = Graphics.FromImage(bm);
        }

        /// <summary>
        /// Gets the bitmap of the canvas.
        /// </summary>
        /// <returns>The bitmap representation of the canvas.</returns>
        public object getBitmap()
        {
            return bm;
        }

        /// <summary>
        /// Draws a circle on the canvas.
        /// </summary>
        /// <param name="radius">The radius of the circle.</param>
        /// <param name="filled">Indicates if the circle should be filled or not.</param>
        public virtual void Circle(int radius, bool filled)
        {
            try
            {
                if (radius < 0)
                {
                    throw new CanvasException("Invalid circle radius " + radius);
                }

                if (g != null && !filled)
                {
                    g.DrawEllipse(Pen, xPos - radius, yPos - radius, radius * 2, radius * 2);
                }
            }
            catch (CanvasException ex)
            {
                // Draw the error message on the canvas
                DrawErrorMessage(ex.Message);
            }
        }

        /// <summary>
        /// Draws a line to the specified coordinates.
        /// </summary>
        /// <param name="toX">The x-coordinate to draw to.</param>
        /// <param name="toY">The y-coordinate to draw to.</param>
        public void DrawTo(int toX, int toY)
        {
            try
            {
                if (toX < 0 || toX > XCanvasSize || toY < 0 || toY > YCanvasSize)
                    throw new CanvasException("Invalid screen position Draw To " + toX + "," + toY);
                if (g != null)
                    g.DrawLine(Pen, xPos, yPos, toX, toY);
                xPos = toX;
                yPos = toY;
            }
            catch (CanvasException ex)
            {

                DrawErrorMessage(ex.Message);
            }
        }

        /// <summary>
        /// Moves current position to the specified coordinates.
        /// </summary>
        /// <param name="x">The new x-coordinate.</param>
        /// <param name="y">The new y-coordinate.</param>
        public void MoveTo(int x, int y)
        {
            try
            {
                if (x < 0 || x > XCanvasSize || y < 0 || y > YCanvasSize)
                    throw new CanvasException("Invalid screen position Move To" + x + "," + y);
                xPos = x;
                yPos = y;
            }
            catch (CanvasException ex)
            {

                DrawErrorMessage(ex.Message);
            }
        }

        /// <summary>
        /// Draws a rectangle on the canvas.
        /// </summary>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        /// <param name="filled">Indicates if the rectangle should be filled or not.</param>
        public void Rect(int width, int height, bool filled)
        {
            try
            {
                if (width <= 0 || height <= 0)
                    throw new CanvasException("Invalid rectangle parameters " + width + "," + height);
                if (g != null)
                    if (!filled)
                        g.DrawRectangle(Pen, xPos, yPos, width, height);
            }
            catch (CanvasException ex)
            {

                DrawErrorMessage(ex.Message);
            }
        }

        /// <summary>
        /// Resets current position to 0, 0.
        /// </summary>
        public void Reset()
        {
            xPos = yPos = 0;
        }

        /// <summary>
        /// Sets the pen color using RGB values.
        /// RGB minimum value is 0 and the max value is 255.
        /// </summary>
        public virtual void SetColour(int red, int green, int blue)
        {
            try
            {
                if (red < 0 || red > 255 || green < 0 || green > 255 || blue < 0 || blue > 255)
                    throw new CanvasException("Invalid colour " + red + "," + green + "," + blue);
                penColour = Color.FromArgb(255, red, green, blue);
                Pen = new Pen(penColour, penSize);
            }
            catch (CanvasException ex)
            {

                DrawErrorMessage(ex.Message);
            }
        }

        /// <summary>
        /// Draws a triangle on the canvas ****** NOT CURRENTLY IMPLEMENTED ******
        /// </summary>
        /// <param name="width">The width of the triangle.</param>
        /// <param name="height">The height of the triangle.</param>
        public void Tri(int width, int height)
        {
            throw new NotImplementedException();

        }

        /// <summary>
        /// Writes text on the canvas at the current position.
        /// </summary>
        /// <param name="text">The text to write.</param>
        public virtual void WriteText(string text)
        {

            if (g != null)
            {
                Font font = new Font("Arial", 11, FontStyle.Bold);
                Brush brush = new SolidBrush(Color.Black);
                g.DrawString(text, font, brush, xPos, yPos);
            }
        }

        /// <summary>
        /// Draws an error message on the canvas at the current error message position.
        /// </summary>
        /// <param name="message"></param>
        private void DrawErrorMessage(string message)
        {
            if (g != null)
            {
                Font font = new Font("Arial", 11, FontStyle.Regular);
                Brush brush = new SolidBrush(Color.IndianRed);
                g.DrawString("\nError: " + message, font, brush, new PointF(10, errorYPos));
                errorYPos += 20;
            }
        }
        /// <summary>
        /// calls the DrawErrorMessage method to display the error message on the canvas.
        /// </summary>
        /// <param name="message"></param>
        public void DisplayErrorOnCanvas(string message)
        {
            DrawErrorMessage(message);
        }

        /// <summary>
        /// Clears canvas of any drawing or text.
        /// </summary>
        public void Clear()
        {
            g.Clear(Color.White);
            errorYPos = 10;

        }
        /// <summary>
        /// Processes the program text and handles the "write" command.
        /// </summary>
        /// <param name="programText">The program text to process.</param>
        public void ProcessProgramText(string programText)
        {
            string[] lines = programText.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            // First, process variable declarations to build your variable dictionary
            Dictionary<string, double> variables = new Dictionary<string, double>();
            foreach (var line in lines)
            {
                if (line.Trim().StartsWith("real "))
                {
                    ProcessVariableDeclaration(line, variables);
                }
            }

            // Track the current position for write commands
            int currentX = xPos; // Use the initial position values
            int currentY = yPos;

            // Process all commands in sequence
            foreach (var line in lines)
            {
                string trimmedLine = line.Trim().ToLower();

                try
                {
                    // Handle moveto commands to update position
                    if (trimmedLine.StartsWith("moveto"))
                    {
                        string coordinates = trimmedLine.Substring(6).Trim();
                        string[] parts = coordinates.Split(',');

                        if (parts.Length == 2 && int.TryParse(parts[0], out int x) && int.TryParse(parts[1], out int y))
                        {
                            currentX = x;
                            currentY = y;
                        }
                        else
                        {
                            throw new CanvasException("Invalid coordinates for moveto command.");
                        }
                    }
                    // Handle write commands
                    else if (trimmedLine.StartsWith("write"))
                    {
                        // Extract the parameter part (everything after "write")
                        string expression = trimmedLine.Substring(5).Trim();

                        if (string.IsNullOrEmpty(expression))
                        {
                            throw new CanvasException("Write command requires text to be specified.");
                        }

                        // Evaluate the expression
                        double result = EvaluateExpression(expression, variables);

                        // Write the result at the current position
                        WriteTextAtPosition(result.ToString(), currentX, currentY);
                    }
                }
                catch (CanvasException ex)
                {
                    DrawErrorMessage(ex.Message);
                }
            }
        }

        /// <summary>
        /// Writes text at a specific position without changing the current canvas position.
        /// </summary>
        /// <param name="text">The text to write.</param>
        /// <param name="x">The x-coordinate.</param>
        /// <param name="y">The y-coordinate.</param>
        private void WriteTextAtPosition(string text, int x, int y)
        {
            if (g != null)
            {
                Font font = new Font("Arial", 11, FontStyle.Bold);
                Brush brush = new SolidBrush(penColour);
                g.DrawString(text, font, brush, x, y);
            }
        }

        private void ProcessVariableDeclaration(string line, Dictionary<string, double> variables)
        {
            // Remove "real " prefix
            string declaration = line.Substring(5).Trim();

            // Check if it's an assignment
            if (declaration.Contains("="))
            {
                string[] parts = declaration.Split('=');
                string variableName = parts[0].Trim();
                string valueExpression = parts[1].Trim();

                // Try to parse the value
                double value;
                if (double.TryParse(valueExpression, out value))
                {
                    variables[variableName] = value;
                }
                else
                {
                    // This handles expressions like "2 * pi * radius"
                    value = EvaluateExpression(valueExpression, variables);
                    variables[variableName] = value;
                }
            }
            else
            {
                // Just a declaration without assignment
                variables[declaration] = 0; // Default value
            }
        }

        private double EvaluateExpression(string expression, Dictionary<string, double> variables)
        {
            // This is a simplified expression evaluator
            // You might want to use a proper expression parsing library

            // First, replace all variable names with their values
            foreach (var variable in variables)
            {
                expression = expression.Replace(variable.Key, variable.Value.ToString());
            }

            // Now the expression should contain only numbers and operators
            // Use a library or implement a simple evaluator to calculate the result
            // For example, you could use DataTable.Compute() or NCalc

            // Simple example using DataTable.Compute()
            System.Data.DataTable table = new System.Data.DataTable();
            try
            {
                // This evaluates mathematical expressions
                return Convert.ToDouble(table.Compute(expression, ""));
            }
            catch
            {
                // If evaluation fails, return the expression as is
                return 0;
            }
        }
    }
}