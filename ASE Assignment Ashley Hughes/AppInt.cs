using BOOSE;
using System;

public class AppInt : Int
{
    private static int instanceCounter;

    public AppInt()
    {
        Restrictions();
    }

    public override void Restrictions()
    {
        // Limit the number of instances (similar to other BOOSE classes)
        if (instanceCounter++ > 5000000)
        {
            throw new RestrictionException("Maximum number of Int instances exceeded");
        }
    }

    public override void Compile()
    {
        base.Compile();
        base.Program.AddVariable(this);
    }

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

    // Property to match the typical pattern in BOOSE classes
    public new int Value { get; private set; }
}