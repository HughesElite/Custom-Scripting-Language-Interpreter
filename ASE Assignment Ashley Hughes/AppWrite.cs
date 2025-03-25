using BOOSE;

namespace ASE_Assignment_Ashley_Hughes
{
    public class AppWrite : Write
    {
        private static ICanvas staticCanvas;
        public static void SetCanvas(ICanvas canvas)
        {
            staticCanvas = canvas;
        }
        public AppWrite()
        {
        }
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