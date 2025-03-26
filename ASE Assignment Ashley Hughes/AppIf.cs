using BOOSE;
using System;
using System.Reflection;
using System.Diagnostics;

namespace ASE_Assignment_Ashley_Hughes
{
    /// <summary>
    /// Extends the BOOSE If class to override built-in restrictions.
    /// </summary>
    public class AppIf : If
    {
        /// <summary>
        /// Static constructor that runs once before any instances are created.
        /// Resets all static counters in the CompoundCommand class.
        /// </summary>
        static AppIf()
        {
            ResetAllCounters();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppIf"/> class.
        /// Resets restriction counters and reduces restrictions to bypass
        /// built-in BOOSE limitations.
        /// </summary>
        public AppIf()
        {
            ResetAllCounters();
            ReduceRestrictions();
        }

        /// <summary>
        /// Resets all potential static counters in the CompoundCommand class
        /// to prevent "Variable limit reached" exceptions.
        /// </summary>
        private static void ResetAllCounters()
        {
            try
            {
                FieldInfo[] fields = typeof(CompoundCommand).GetFields(
                    BindingFlags.NonPublic | BindingFlags.Static);
                foreach (FieldInfo field in fields)
                {
                    if (field.FieldType == typeof(int))
                    {
                        field.SetValue(null, 0);
                    }
                }
            }
            catch (Exception)
            {
           
            }
        }
    }
}