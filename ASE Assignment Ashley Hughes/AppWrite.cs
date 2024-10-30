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
    public class AppWrite : Write
    {
        public AppWrite() { }

        public void CheckParameters(string[] parameters)
        {
            if (parameters.Length < 1)
            {
                throw new CommandException(" Invalid parameters for write command");
            }
        }

        public void Compile()
        {

        }

        public override void Execute()
        {
            string expression = base.Expression;
            this.evaluatedExpression = base.Program.EvaluateExpressionWithString(base.Parameters[0]);
            Console.WriteLine(this.evaluatedExpression);


        }

        public void Set(StoredProgram Program, string Params)
        {

        }
    }
}
