using BOOSE;

namespace ASE_Assignment_Ashley_Hughes
{
    public class AppStoredProgram : StoredProgram
    {
        public AppStoredProgram(ICanvas canvas) : base(canvas)
        {
        }

        public override void Run()
        {
            while (Commandsleft())
            {
                ICommand command = (ICommand)NextCommand();
                command.Execute();
            }
        }
    }
}