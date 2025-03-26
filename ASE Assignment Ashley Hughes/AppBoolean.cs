using BOOSE;
using System;
using System.Reflection;
using System.Diagnostics;

namespace ASE_Assignment_Ashley_Hughes
{
    /// <summary>
    /// Extends the BOOSE Boolean class to override restrictions.
    /// </summary>
    public class AppBoolean : BOOSE.Boolean
    {
        /// <summary>
        /// Overrides the base Restrictions method to bypass the built-in limitation
        /// on the number of Boolean instances that can be created.
        /// </summary>
        public override void Restrictions()
        {
            // Bypasses the restriction check completely
        }
    }
}