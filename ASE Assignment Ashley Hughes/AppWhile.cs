using BOOSE;
using System;
using System.Reflection;
using System.Diagnostics;

namespace ASE_Assignment_Ashley_Hughes
{
    /// <summary>
    /// Extends the BOOSE While class to override built-in restrictions.
    /// </summary>
    public class AppWhile : BOOSE.While
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppWhile"/> class.
        /// Calls the ReduceRestrictions method to bypass built-in BOOSE limitations.
        /// </summary>
        public AppWhile() : base()
        {
            
            ReduceRestrictions();
        }
    }
}