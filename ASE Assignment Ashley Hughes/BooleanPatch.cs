using BOOSE;
using System;
using System.Reflection;

namespace ASE_Assignment_Ashley_Hughes
{
    /// <summary>
    /// A class to patch the Boolean class to bypass restrictions.
    /// </summary>
    public static class BooleanPatch
    {
        /// <summary>
        /// Resets all static integer counters in the Boolean class to zero
        /// to bypass built-in instance limits.
        /// </summary>
        public static void Apply()
        {
            try
            {
                // Get all static fields in the Boolean class
                FieldInfo[] fields = typeof(BOOSE.Boolean).GetFields(
                    BindingFlags.NonPublic | BindingFlags.Static);

                // Reset any integer fields (such as counters) to zero
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