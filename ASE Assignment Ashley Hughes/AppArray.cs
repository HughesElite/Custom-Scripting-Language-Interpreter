using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOOSE;

namespace ASE_Assignment_Ashley_Hughes
{
    public class AppArray : Evaluation
    {
        private int[,] intArray;
        private double[,] realArray;
        private int rows;
        private int columns;
        private string type;

        public int Rows => rows;
        public int Columns => columns;

        public AppArray(string type, int rows, int columns = 1)
        {
            this.type = type.ToLower();
            this.rows = rows;
            this.columns = columns;

            if (type == "int")
                intArray = new int[rows, columns];
            else if (type == "real")
                realArray = new double[rows, columns];
            else
                throw new ArgumentException("Invalid type. Use 'int' or 'real'.");
        }

        public void SetIntValue(int row, int col, int value)
        {
            ValidateIndices(row, col);
            intArray[row, col] = value;
        }

        public int GetIntValue(int row, int col)
        {
            ValidateIndices(row, col);
            return intArray[row, col];
        }

        public void SetRealValue(int row, int col, double value)
        {
            ValidateIndices(row, col);
            realArray[row, col] = value;
        }

        public double GetRealValue(int row, int col)
        {
            ValidateIndices(row, col);
            return realArray[row, col];
        }

        private void ValidateIndices(int row, int col)
        {
            if (row >= rows || col >= columns || row < 0 || col < 0)
                throw new IndexOutOfRangeException("Array index out of bounds.");
        }
    }
}