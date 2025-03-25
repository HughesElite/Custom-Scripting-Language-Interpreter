using BOOSE;

namespace ASE_Assignment_Ashley_Hughes
{
    public class AppStoredProgram : BOOSE.StoredProgram
    {
        public AppStoredProgram(ICanvas canvas) : base(canvas)
        {
            // Call the base constructor with the canvas
        }

        // Override the Run method to remove the restrictions
        public override void Run()
        {
            // Simple implementation without restrictions
            while (Commandsleft())
            {
                ICommand command = (ICommand)NextCommand();
                try
                {
                    command.Execute();
                }
                catch (BOOSEException ex)
                {
                    SyntaxOk = false;
                    throw new StoredProgramException(ex.Message + " at line " + PC);
                }
            }

            // Check for unmatched conditional commands using base class methods
            if (base.Pop() != null)
            {
                SyntaxOk = false;
                throw new StoredProgramException("Missing end statement");
            }
        }
    }
}