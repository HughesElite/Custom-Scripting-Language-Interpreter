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
         //   commandType = commandType.ToLower().Trim();
            if (commandType == "Mypen")
                return new AppSetColour();
            commandType = commandType.ToLower().Trim();
            if (commandType == "Mycircle")
                return new AppCircle();
            return base.MakeCommand(commandType);

            throw new FactoryException(" No such command \'"+commandType+"\'");
        }
       
    }

}
