using BOOSE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment_Ashley_Hughes

{
    /// <summary>
    /// Represents an override command to draw a circle to the canvas, not currently implemented
    /// </summary>
    public class AppCircle : ICommand
    {

        public void CheckParameters(string[] Parameters)
        {
            throw new NotImplementedException();  // TODO: Implement CheckParameters functionality for AppCircle command
        }

        public void Compile()
        {
            throw new NotImplementedException(); // TODO: Implement Compile functionality for AppCircle command
        }

        public void Execute()
        {
            throw new NotImplementedException(); // TODO: Implement Execute functionality for AppCircle command
        }

        public void Set(StoredProgram Program, string Params) // TODO: Implement Set functionality for AppCircle command
        {
            throw new NotImplementedException();
        }
    }
}
