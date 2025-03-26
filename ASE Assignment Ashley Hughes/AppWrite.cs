using BOOSE;

namespace ASE_Assignment_Ashley_Hughes
{
    /// <summary>
    /// Extends the BOOSE Write class to output text to the canvas.
    /// </summary>
    public class AppWrite : Write
    {
        private static ICanvas staticCanvas;

        /// <summary>
        /// Sets the canvas that will be used for text output.
        /// </summary>
        /// <param name="canvas">The canvas to write text on.</param>
        public static void SetCanvas(ICanvas canvas)
        {
            staticCanvas = canvas;
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="AppWrite"/> class.
        /// </summary>
        public AppWrite()
        {
        }

        /// <summary>
        /// Executes the write command, outputting text to the canvas.
        /// </summary>
        public override void Execute()
        {
            base.Execute();
            if (staticCanvas != null)
            {
                staticCanvas.WriteText(evaluatedExpression ?? "");
            }
        }
    }
}