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
        /// <summary>
        /// Initializes a new instance of the <see cref="AppCommandFactory"/> class.
        /// Applies Boolean patch to bypass restrictions.
        /// </summary>
        public AppCommandFactory()
        {
            BooseReset.ResetAllBOOSECounters();
        }

        /// <summary>
        /// Creates a command based on the provided command type.
        /// Returns custom App implementations for BOOSE library commands to bypass BOOSE restrictions,
        /// or falls back to the base implementation for unrecognised commands.
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
            if (commandType == "if")
                return new AppIf();
            if (commandType == "method")
                return new AppMethod();
            if (commandType == "bool" || commandType == "boolean")//
                return new AppBoolean();

            try
            {
                return base.MakeCommand(commandType);
            }
            catch (Exception ex)
            {
                // Logs the error before throwing the exception
                ErrorLogger.Instance.LogError($"Command not found: '{commandType}'. Error: {ex.Message}");

                // If the base implementation can't find the command, throw a FactoryException
                throw new FactoryException("No such command '" + commandType + "'");
            }
        }
    }
}