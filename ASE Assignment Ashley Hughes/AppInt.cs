using BOOSE;

namespace ASE_Assignment_Ashley_Hughes
{
    public class AppInt : Int
    {
        // Constructor to call the base class constructor
        public AppInt() : base()
        {
            
        }

        public override void Restrictions()
        {
            // Remove the restriction logic by not calling base.Restrictions()
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
