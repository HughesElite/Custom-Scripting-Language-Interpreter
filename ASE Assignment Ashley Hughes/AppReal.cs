using System;
using BOOSE;

namespace ASE_Assignment_Ashley_Hughes
{
    /// <summary>
    /// Extends the BOOSE Real class to handle real number variables.
    /// </summary>
    public class AppReal : Real
    {
        private static int instanceCounter;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppReal"/> class.
        /// </summary>
        public AppReal() : base()
        {
            Restrictions();
        }

        /// <summary>
        /// Enforces restrictions on the number of Real instances that can be created.
        /// </summary>
        public override void Restrictions()
        {
            if (instanceCounter++ > 50000)
            {
                throw new RestrictionException("Maximum number of Real instances exceeded");
            }
        }

        /// <summary>
        /// Compiles the real number command and adds the variable to the program.
        /// </summary>
        public override void Compile()
        {
            try
            {
                base.Compile();
                base.Program.AddVariable(this);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Executes the real number command, parsing the expression into a double value.
        /// </summary>
        /// <remarks>
        /// This method:
        /// <list type="bullet">
        ///     <item>Calls the base class's Execute method first</item>
        ///     <item>Attempts to parse the evaluated expression as a double value</item>
        ///     <item>Uses standard number format parsing (with period as decimal separator)</item>
        ///     <item>Updates the variable in the program if parsing succeeds</item>
        ///     <item>Throws an exception with a helpful error message if parsing fails</item>
        /// </list>
        /// </remarks>
        public override void Execute()
        {
            try
            {
                base.Execute();

                // Only processes if there is an expression to parse
                if (!string.IsNullOrEmpty(evaluatedExpression))
                {
                    // Attempts standard number format (such as "123.45")
                    if (double.TryParse(evaluatedExpression, out double parsedValue))
                    {
                        Value = parsedValue;
                        base.Program.UpdateVariable(varName, Value);
                    }
                    // If parsing fails, displays an error
                    else
                    {
                        throw new StoredProgramException($"Invalid real number format: '{evaluatedExpression}'");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}