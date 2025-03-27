using BOOSE;
using System;
using System.Reflection;
using System.Diagnostics;

namespace ASE_Assignment_Ashley_Hughes
{
    /// <summary>
    /// Extends the BOOSE Method class to override restrictions.
    /// </summary>
    public class AppMethod : Method
    {
        /// <summary>
        /// Static constructor that runs once before any instances are created.
        /// Resets all static counters in the Method class.
        /// </summary>
        static AppMethod()
        {
            ResetMethodCounter();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppMethod"/> class.
        /// </summary>
        public AppMethod() : base()
        {
            ResetMethodCounter();
        }

        /// <summary>
        /// Uses reflection to reset the static counter in the Method class
        /// that limits the number of method instances.
        /// </summary>
        private static void ResetMethodCounter()
        {
            try
            {
                // Find all static fields in the Method class
                FieldInfo[] fields = typeof(Method).GetFields(
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
                Debug.WriteLine($"Error resetting Method counter: {ex.Message}");
            }
        }

        /// <summary>
        /// Compiles the method command.
        /// </summary>
        public override void Compile()
        {
            base.Compile();
        }

        /// <summary>
        /// Executes the method command.
        /// </summary>
        public override void Execute()
        {
            base.Execute();
        }
    }
}