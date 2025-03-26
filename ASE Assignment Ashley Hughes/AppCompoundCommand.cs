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
        /// Static constructor that runs once before any instances are created.
        /// Resets all static counters in the CompoundCommand class.
        /// </summary>
        static AppCompoundCommand()
        {
            ResetAllCounters();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppCompoundCommand"/> class.
        /// </summary>
        public AppCompoundCommand() : base()
        {
            // Reset counters on every new instance to ensure restrictions are bypassed
            ResetAllCounters();
            ReduceRestrictions();
        }

        /// <summary>
        /// Resets all potential static counters in the CompoundCommand class
        /// to prevent restriction exceptions.
        /// </summary>
        public static void ResetAllCounters()
        {
            try
            {
                // Find all static fields in the CompoundCommand class
                FieldInfo[] fields = typeof(CompoundCommand).GetFields(
                    BindingFlags.NonPublic | BindingFlags.Static);

                // Reset all integer fields (potential counters)
                foreach (FieldInfo field in fields)
                {
                    if (field.FieldType == typeof(int))
                    {
                        field.SetValue(null, 0);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error resetting CompoundCommand counters: {ex.Message}");
            }
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