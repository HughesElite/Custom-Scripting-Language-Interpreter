using BOOSE;

namespace ASE_Assignment_Ashley_Hughes
{
    /// <summary>
    /// Extended Real Number Variable class that builds upon the existing BOOSE.Real class.
    /// </summary>
    public class AppReal : Real
    {
        /// <summary>
        /// Constructor for the extended Real class.
        /// </summary>
        public AppReal() : base()
        {
            // Any additional initialization can go here
        }

        /// <summary>
        /// Override the Restrictions method if you need to modify its behavior
        /// </summary>
        public override void Restrictions()
        {
            // If you want to change the restriction behavior
            // Otherwise, you can remove this override and use the base implementation
           // base.Restrictions();
        }

        /// <summary>
        /// Override the Compile method to add additional functionality
        /// </summary>
        public override void Compile()
        {
            // Add any pre-compilation logic here

            base.Compile();

            // Add any post-compilation logic here
        }

        /// <summary>
        /// Override the Execute method to add additional functionality
        /// </summary>
        public override void Execute()
        {
            // Add any pre-execution logic here

            base.Execute();

            // Add any post-execution logic here
        }

        // Add any additional methods or properties specific to your implementation
    }
}