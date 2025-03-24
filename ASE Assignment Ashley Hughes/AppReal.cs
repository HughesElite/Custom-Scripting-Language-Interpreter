using System;
using System.Diagnostics;
using BOOSE;

namespace ASE_Assignment_Ashley_Hughes
{
    public class AppReal : Real
    {
        private static int instanceCounter;

        public AppReal() : base()
        {
            Debug.WriteLine("AppReal constructor called");
            Restrictions();
        }

        public override void Restrictions()
        {
            Debug.WriteLine($"AppReal.Restrictions called - current count: {instanceCounter}");
            if (instanceCounter++ > 50000)
            {
                Debug.WriteLine("AppReal restriction exceeded!");
                throw new RestrictionException("Maximum number of Real instances exceeded");
            }
        }

        public override void Compile()
        {
            Debug.WriteLine("AppReal.Compile called");
            try
            {
                base.Compile();
                Debug.WriteLine($"AppReal.Compile completed - varName: {varName}, expression: {expression}");

                // Check variable name and expression
                if (string.IsNullOrEmpty(varName))
                    Debug.WriteLine("WARNING: varName is null or empty after base.Compile()");
                if (string.IsNullOrEmpty(expression))
                    Debug.WriteLine("WARNING: expression is null or empty after base.Compile()");

                base.Program.AddVariable(this);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ERROR in AppReal.Compile: {ex.Message}");
                throw;
            }
        }

        public override void Execute()
        {
            Debug.WriteLine("AppReal.Execute called");
            try
            {
                Debug.WriteLine($"Before base.Execute() - evaluatedExpression: '{evaluatedExpression}'");
                base.Execute();
                Debug.WriteLine($"After base.Execute() - evaluatedExpression: '{evaluatedExpression}', Value: {Value}");

                // If base.Execute() already set the value, don't try to parse again
                if (!string.IsNullOrEmpty(evaluatedExpression))
                {
                    Debug.WriteLine($"Attempting to parse '{evaluatedExpression}' as double");

                    // Try with invariant culture and different formats
                    if (double.TryParse(evaluatedExpression, out double parsedValue))
                    {
                        Debug.WriteLine($"Successfully parsed '{evaluatedExpression}' to {parsedValue}");
                        Value = parsedValue;
                        base.Program.UpdateVariable(varName, Value);
                    }
                    else if (double.TryParse(evaluatedExpression.Replace(',', '.'),
                             System.Globalization.NumberStyles.Any,
                             System.Globalization.CultureInfo.InvariantCulture,
                             out parsedValue))
                    {
                        Debug.WriteLine($"Successfully parsed '{evaluatedExpression}' to {parsedValue} using invariant culture");
                        Value = parsedValue;
                        base.Program.UpdateVariable(varName, Value);
                    }
                    else
                    {
                        Debug.WriteLine($"FAILED to parse '{evaluatedExpression}' as double");
                        throw new StoredProgramException($"Invalid real number format: '{evaluatedExpression}'");
                    }
                }
                else
                {
                    Debug.WriteLine("evaluatedExpression is null or empty, skipping parsing");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ERROR in AppReal.Execute: {ex.Message}");
                throw;
            }
        }
    }
}