using BOOSE;
using System;
using System.Reflection;
using System.Diagnostics;

namespace ASE_Assignment_Ashley_Hughes
{
    /// <summary>
    /// Extends the BOOSE Array class to override restrictions.
    /// </summary>
    public class AppMethod : BOOSE.Method
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppArray"/> class.
        ///  Calls the base class method to bypass BOOSE library array limitations.
        /// </summary>
        public AppMethod()
        {
            
        }

        /// <summary>
        /// Compiles the array command.
        /// </summary>
        public override void Compile()
        {
            base.Compile();
        }

        /// <summary>
        /// Compiles the array command.
        /// </summary>
        public override void Execute()
        {
            base.Execute();
        }
    }

}
