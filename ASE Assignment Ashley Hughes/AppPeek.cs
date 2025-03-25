using BOOSE;
using System;
using System.Diagnostics;

namespace ASE_Assignment_Ashley_Hughes
{
    public class AppPeek : BOOSE.Peek
    {
        public AppPeek() : base()
        {
            Debug.WriteLine("AppPeek constructor called");
            // Base constructor already calls ReduceRestrictionCounter()
        }

        // The base class has NotImplementedException, so we need to override
        public override void CheckParameters(string[] Parameters)
        {
            Debug.WriteLine("AppPeek.CheckParameters called");
            // Use the ProcessArrayParametersCompile method from the base Array class
            base.ArrayRestrictions();
            base.Parameters = base.ParameterList.Trim().Split(',');

            if (base.Parameters.Length < 2)
            {
                throw new CommandException("Invalid array parameters");
            }
        }

        // Base class calls ProcessArrayParametersCompile(false)
        public override void Compile()
        {
            Debug.WriteLine("AppPeek.Compile called");
            base.Compile();
        }

        // Base class calls ProcessArrayParametersExecute(false) and updates the variable
        public override void Execute()
        {
            Debug.WriteLine("AppPeek.Execute called");
            base.Execute();
        }
    }
}