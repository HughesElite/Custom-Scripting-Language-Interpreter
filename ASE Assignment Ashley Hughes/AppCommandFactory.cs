using BOOSE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment_Ashley_Hughes
{
    /// <summary>
    /// Factory class for creating command instances based on command types.
    /// Extends original BOOSE command factory.
    /// </summary>
    public class AppCommandFactory : CommandFactory
    {
        public AppCommandFactory() { }

        /// <summary>
        /// Creates a command based on the provided command type.
        /// </summary>
        /// <param name="commandType">The type of command to create.</param>
        /// <returns>An ICommand instance corresponding to the command type.</returns>
        public override ICommand MakeCommand(string commandType)
        {
            commandType = commandType.ToLower().Trim();

            if (commandType == "int")
                return new AppInt();
            if (commandType == "real")
                return new AppReal();
            if (commandType == "write")
                return new AppWrite();
            if (commandType == "array")
                return new AppArray();
            if (commandType == "while")
                return new AppWhile();
            if (commandType == "CompoundCommand")
                return new AppCompoundCommand();



            return (base.MakeCommand(commandType));

            //throw new FactoryException("No such command \'"+commandType+"\'");

        }
    }
}




// //var command = base.MakeCommand(commandType);
// //if (command != null)
// //    return command;

//// throw new FactoryException(" No such command \'" + commandType + "\'");


// return base.MakeCommand(commandType);  // Call the base class's MakeCommand method if no matching command type is found

// throw new FactoryException(" No such command \'" + commandType + "\'"); // Throw an exception if the command type is unrecognised
