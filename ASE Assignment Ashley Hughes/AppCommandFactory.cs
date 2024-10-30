using BOOSE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment_Ashley_Hughes
{
    public class AppCommandFactory : CommandFactory
    {
        public AppCommandFactory() { }

        public override ICommand MakeCommand(string commandType)
        {
            commandType = commandType.ToLower().Trim();
            if (commandType == "mypen")
                return new AppSetColour();
            commandType = commandType.ToLower().Trim();
            if (commandType == "mycircle")
                return new AppCircle();
            commandType = commandType.ToLower().Trim();
            if (commandType == "mywrite")
                return new AppWrite();
            return base.MakeCommand(commandType);

            throw new FactoryException(" No such command \'" + commandType + "\'");
        }

    }

}
