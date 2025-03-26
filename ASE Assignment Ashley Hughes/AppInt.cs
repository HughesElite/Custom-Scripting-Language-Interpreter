using BOOSE;
using System;

/// <summary>
/// Extends the BOOSE Int class to handle integer variables.
/// </summary>
public class AppInt : Int
{
    private static int instanceCounter;

    /// <summary>
    /// Initializes a new instance of the <see cref="AppInt"/> class.
    /// </summary>
    public AppInt()
    {
        Restrictions();
    }

    /// <summary>
    /// Enforces restrictions on the number of Int instances that can be created.
    /// </summary>
    public override void Restrictions()
    {
        // Limit the number of instances (similar to other BOOSE classes)
        if (instanceCounter++ > 5000000)
        {
            throw new RestrictionException("Maximum number of Int instances exceeded");
        }
    }

    /// <summary>
    /// Compiles the int command and adds the variable to the program.
    /// </summary>
    public override void Compile()
    {
        base.Compile();
        base.Program.AddVariable(this);
    }

    /// <summary>
    /// Executes the int command, parsing the expression into an integer value.
    /// </summary>
    public override void Execute()
    {
        base.Execute();
        // Attempt to parse the evaluated expression
        if (!int.TryParse(evaluatedExpression, out int parsedValue))
        {
            throw new StoredProgramException("Invalid integer format");
        }
        // Update the value and the program variable
        Value = parsedValue;
        base.Program.UpdateVariable(varName, Value);
    }

    /// <summary>
    /// Gets or sets the integer value of this variable.
    /// </summary>
    public new int Value { get; private set; }
}