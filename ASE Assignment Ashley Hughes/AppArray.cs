using BOOSE;

public class AppArray : BOOSE.Array
{
    // Constructor to manage instance restrictions
    public AppArray()
    {
        // Calls the base constructor, which increments the static instance counter
        //base.ArrayRestrictions();
    }
    // Override Compile method to add custom compilation logic
    public override void Compile()
    {
        try
        {
            // Call the base compilation method
            base.Compile();
            // Optional: Add any additional compilation logic specific to your needs
            // For example, logging, additional validation, etc.
        }
        catch (Exception ex)
        {
            // Handle or rethrow compilation exceptions
            throw new CommandException($"Compilation failed: {ex.Message}");
        }
    }
    // Override Execute method to add custom execution logic
    public override void Execute()
    {
        try
        {
            // Call the base execution method
            base.Execute();
            // Optional: Add any additional execution logic
            // For example, logging, additional processing, etc.
        }
        catch (Exception ex)
        {
            // Handle or rethrow execution exceptions
            throw new StoredProgramException($"Execution failed: {ex.Message}");
        }
    }
    // Override CheckParameters to add custom parameter validation
    public override void CheckParameters(string[] parameterList)
    {
        try
        {
            // Call the base parameter checking method
            base.CheckParameters(parameterList);
            // Optional: Add additional parameter validation
            // For example, custom range checks, type validation, etc.
        }
        catch (Exception ex)
        {
            // Handle or rethrow parameter checking exceptions
            throw new CommandException($"Parameter validation failed: {ex.Message}");
        }
    }
    // Optional: Override array manipulation methods with additional logic
    public override void SetIntArray(int val, int row, int col)
    {
        try
        {
            // Perform any pre-set validation or logic
            // For example, range checks, logging, etc.
            // Call the base method to set the array value
            base.SetIntArray(val, row, col);
            // Optional: Post-set logic
        }
        catch (Exception ex)
        {
            throw new CommandException($"Failed to set int array value: {ex.Message}");
        }
    }
    public override void SetRealArray(double val, int row, int col)
    {
        try
        {
            // Perform any pre-set validation or logic
            // Call the base method to set the array value
            base.SetRealArray(val, row, col);
            // Optional: Post-set logic
        }
        catch (Exception ex)
        {
            throw new CommandException($"Failed to set real array value: {ex.Message}");
        }
    }
    // Optional: Add a method to reset the restriction counter if needed
    public void ResetRestrictionCounter()
    {
        // Use reflection or a custom method to reset the static counter
        // Note: This might require internal framework modification
        ReduceRestrictionCounter();
    }
}
