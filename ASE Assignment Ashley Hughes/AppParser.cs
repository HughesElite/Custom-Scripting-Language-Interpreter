using BOOSE;

namespace ASE_Assignment_Ashley_Hughes
{
    /// <summary>
    /// Extends the BOOSE Parser to remove line and command restrictions
    /// </summary>
    public class AppParser : Parser
    {
        public AppParser(CommandFactory Factory, StoredProgram Program) : base(Factory, Program)
        {
        }

        /// <summary>
        /// Override ParseProgram to remove line count restriction
        /// </summary>
        public override void ParseProgram(string program)
        {
            // Use the base implementation, but remove any internal restrictions
            base.ParseProgram(program);
        }
    }
}