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
            if (commandType.Equals("moveto"))
                return new MoveTo();
            if (commandType.Equals("drawto"))
                return new DrawTo();
            if (commandType.Equals("circle"))
                return new Circle();
            if (commandType.Equals("rect"))
                return new Rect();
            if (commandType.Equals("pen"))
                return new PenColour();
            if (commandType.Equals("eval"))
                return new Evaluation();
            if (commandType.Equals("if"))
                return new If();
            if (commandType.Equals("end"))
                return new End();
            if (commandType.Equals("else"))
                return new Else();
            if (commandType.Equals("while"))
                return new While();
            if (commandType.Equals("for"))
                return new For();

            if (commandType.Equals("int")) //origianl replaces old int command
                return new AppInt();

            if (commandType.Equals("real"))
                return new AppReal();
            if (commandType.Equals("write"))
                return new AppWrite();

            // if (commandType.Equals("array"))
            //    return new AppArray();

            if (commandType.Equals("poke"))
                return new Poke();
            if (commandType.Equals("cast"))
                return new Cast();
            if (commandType.Equals("method"))
                return new Method();
            if (commandType.Equals("call"))
                return new Call();

            throw new FactoryException(" No such command \'" + commandType + "\'"); // Throw an exception if the command type is unrecognised

            return base.MakeCommand(commandType);  // Call the base class's MakeCommand method if no matching command type is found


        }

    }

}
