using BOOSE;
using System;
using System.Diagnostics;

namespace ASE_Assignment_Ashley_Hughes
{
    // Check if Poke exists in the BOOSE namespace, otherwise assume it's a standard class
    public class AppPoke : Poke
    {
        public AppPoke() : base()
        {
            // Just call the base constructor
            Debug.WriteLine("AppPoke constructor called");
        }

        // We don't need to override any methods unless you want to add custom behavior
    }
}