using BOOSE;

namespace ASE_Assignment_Ashley_Hughes
{
    public class AppInt : Int
    {
        // Constructor to call the base class constructor
        public AppInt() : base()
        {
            // Override the restrictions if necessary
            
        }

        // Override the Restrictions method to remove or change the logic
        public override void Restrictions()
        {
            // Remove the restriction logic by not calling base.Restrictions()
            // This means AppInt will not have the restriction counter logic.
        }

        public override void Compile()
        {
            base.Compile();
            base.Program.AddVariable(this);
        }

        public override void Execute()
        {
            base.Execute();  // Kept the original execute logic from Int
         
        }

        
    }
}
