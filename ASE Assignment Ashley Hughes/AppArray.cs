using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOOSE;

namespace ASE_Assignment_Ashley_Hughes
{
    public class AppArray : BOOSE.Array
        {
            ValidateIndices(row, col);
            realArray[row, col] = value;
        }

        public double GetRealValue(int row, int col)
        {
            ValidateIndices(row, col);
            return realArray[row, col];
        }

}