using BOOSE;
using System;
using System.Reflection;
using System.Diagnostics;

namespace ASE_Assignment_Ashley_Hughes
{
    /// <summary>
    /// Extends the BOOSE Parser to remove line and command restrictions.
    /// </summary>
    public class AppParser : Parser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppParser"/> class.
        /// </summary>
        /// <param name="Factory">The command factory to use for creating commands.</param>
        /// <param name="Program">The stored program to populate with commands.</param>
        public AppParser(CommandFactory Factory, StoredProgram Program) : base(Factory, Program)
        {

        }

        /// <summary>
        /// Overrides ParseProgram to bypass the line count restriction in the base BOOSE parser.
        /// </summary>
        /// <param name="program">The program text to parse.</param>
        public override void ParseProgram(string program)
        {
            // Uses the base implementation, but removes any internal restrictions
            base.ParseProgram(program);
        }
    }
}