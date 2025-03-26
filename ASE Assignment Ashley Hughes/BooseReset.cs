using BOOSE;
using System;
using System.Reflection;
using System.Diagnostics;

namespace ASE_Assignment_Ashley_Hughes
{
    /// <summary>
    /// Utility class for resetting BOOSE library restrictions.
    /// </summary>
    public static class BooseReset
    {
        /// <summary>
        /// Resets all BOOSE library counters that might cause restriction exceptions.
        /// </summary>
        public static void ResetAllBOOSECounters()
        {
            try
            {
                // Reset CompoundCommand counters
                ResetCountersInClass(typeof(CompoundCommand));
                // Reset Method counters
                ResetCountersInClass(typeof(Method));
                // Reset While counters
                ResetCountersInClass(typeof(BOOSE.While));
                // Reset If counters
                ResetCountersInClass(typeof(If));
                // Reset Boolean counters
                ResetCountersInClass(typeof(BOOSE.Boolean));
                // Reset Array counters
                ResetCountersInClass(typeof(BOOSE.Array));

                // Only debug output on successful completion if needed for troubleshooting
                // Debug.WriteLine("All BOOSE counters reset successfully");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error resetting BOOSE counters: {ex.Message}");
            }
        }

        /// <summary>
        /// Resets all static integer fields in a specific class.
        /// </summary>
        /// <param name="classType">The type of class to reset counters for.</param>
        private static void ResetCountersInClass(Type classType)
        {
            try
            {
                // Find all static fields in the specified class
                FieldInfo[] fields = classType.GetFields(
                    BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Public);

                // Reset all integer fields (potential counters)
                foreach (FieldInfo field in fields)
                {
                    if (field.FieldType == typeof(int))
                    {
                        field.SetValue(null, 0);
                        // Remove debug output for successful resets
                        // Debug.WriteLine($"Reset counter {field.Name} in {classType.Name}");
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error resetting counters in {classType.Name}: {ex.Message}");
            }
        }
    }
}