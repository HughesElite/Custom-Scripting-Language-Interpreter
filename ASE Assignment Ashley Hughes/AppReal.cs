using BOOSE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment_Ashley_Hughes
{

    public class AppReal : Real
    {
        private static int a;
        private double b;
        public new double Value
        {
            get
            {
                return b;
            }
            set
            {
                b = value;
            }
        }
        public AppReal() : base()
        {
            // Skip restriction logic by overriding Restrictions
        }

        public override void Restrictions()
        {
            // Do nothing to bypass the restriction logic
        }

        public override void Compile()
        {
     
            base.Compile();
            base.Program.AddVariable(this);

            // Additional customization can go here if needed
        }
        public override void Execute()
        {
            // Retain the existing Execute logic
            base.Execute();

            // Additional customization can go here if needed
        }
    }
}