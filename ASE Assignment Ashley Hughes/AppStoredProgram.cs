using BOOSE;
using System;
using System.Reflection;
using System.Diagnostics;

namespace ASE_Assignment_Ashley_Hughes
{
    /// <summary>
    /// Extends the BOOSE StoredProgram class to override execution limits.
    /// </summary>
    public class AppStoredProgram : StoredProgram
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppStoredProgram"/> class.
        /// </summary>
        /// <param name="canvas">The canvas thats used for drawing operations.</param>
        public AppStoredProgram(ICanvas canvas) : base(canvas)
        {
        }

        /// <summary>
        /// Overrides the Run method to bypass the execution count limitation
        /// present in the base BOOSE implementation.
        /// </summary>
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