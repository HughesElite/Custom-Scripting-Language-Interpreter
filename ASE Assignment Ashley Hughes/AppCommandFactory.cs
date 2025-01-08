using BOOSE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment_Ashley_Hughes
{
    /// <summary>
    /// Factory class for creating command instances based on command types.
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
       

  
  

            return base.MakeCommand(commandType);  // Call the base class's MakeCommand method if no matching command type is found

            throw new FactoryException(" No such command \'" + commandType + "\'"); // Throw an exception if the command type is unrecognized
        }

    }

}
