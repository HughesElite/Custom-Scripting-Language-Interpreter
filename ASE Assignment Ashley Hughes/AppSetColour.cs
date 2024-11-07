using BOOSE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment_Ashley_Hughes

{
    /// <summary>
    /// Represents an override command to set the pen color, not currently implemented
    /// </summary>
    public class AppSetColour : ICommand
    {
        public AppSetColour() { }

        private int red, green, blue;

        /// <summary>
        /// Checks if the parameters provided for the color command are valid.
        /// </summary>
        /// <param name="parameters">The parameters containing the color values.</param>
        /// <exception cref="ArgumentException">Thrown when parameters are invalid.</exception>
        public void CheckParameters(string[] parameters)
        {
            if (parameters.Length != 3)
            {
                throw new ArgumentException("Three parameters are required: red, green, blue.");
            }

            // Validate each color value (must be integers between 0 and 255)
            if (!int.TryParse(parameters[0], out red) || red < 0 || red > 255 ||
                !int.TryParse(parameters[1], out green) || green < 0 || green > 255 ||
                !int.TryParse(parameters[2], out blue) || blue < 0 || blue > 255)
            {
                throw new ArgumentException("Invalid color values. Each must be an integer between 0 and 255.");
            }
        }

        public void Compile()
        {
            throw new NotImplementedException(); // TODO: Implement Compile functionality for AppCircle command
        }

        public void Execute()
        {
            throw new NotImplementedException(); // TODO: Implement Execute functionality for AppCircle command
        }

        public void Set(StoredProgram Program, string Params)
        {
            throw new NotImplementedException(); // TODO: Implement Set functionality for AppCircle command
        }
    }
}
