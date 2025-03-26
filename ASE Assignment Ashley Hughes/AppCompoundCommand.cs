using BOOSE;
using System;
using System.Reflection;
using System.Diagnostics;

namespace ASE_Assignment_Ashley_Hughes
{
    /// <summary>
    /// Extends the BOOSE CompoundCommand class to override built-in restrictions.
    /// </summary>
    public class AppCompoundCommand : CompoundCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppCompoundCommand"/> class.
        /// Calls the ReduceRestrictions method to bypass built-in BOOSE limitations.
        /// </summary>
        public AppCompoundCommand()
        {
            ReduceRestrictions();
        }

        /// <summary>
        /// Compiles the compound command.
        /// </summary>
        public override void Compile()
        {
            base.Compile();
        }
    }
}