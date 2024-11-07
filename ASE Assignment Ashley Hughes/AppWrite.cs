using BOOSE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace ASE_Assignment_Ashley_Hughes

{
    /// <summary>
    /// Represents an override command to write text to the canvas, not currently implemented
    /// </summary>
    public class AppWrite : Write
    {
        public AppWrite() { }

        /// <summary>
        /// Checks the parameters for the write command.
        /// </summary>
        /// <param name="parameters">The parameters passed to the write command.</param>
        /// <exception cref="CommandException">Thrown when parameters are invalid.</exception>
        public void CheckParameters(string[] parameters)
        {
            if (parameters.Length < 1)
            {
                throw new CommandException(" Invalid parameters for write command");
            }
        }

        public void Compile()
        {
            // TODO: Implement compile functionality for AppWrite command
        }

        public override void Execute()
        {
            string expression = base.Expression;
            this.evaluatedExpression = base.Program.EvaluateExpressionWithString(base.Parameters[0]);
            Console.WriteLine(this.evaluatedExpression);


        }

        /// <summary>
        /// Sets the stored program and parameters for the write command.
        /// This method is not implemented yet.
        /// </summary>
        public void Set(StoredProgram Program, string Params)
        {
            // TODO: Implement Set functionality for AppWrite command
        }
    }
}
