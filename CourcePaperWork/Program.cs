using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace CourcePaperWork
{
    class Program
    {

        public static double FillFunction_ver1(int i, int j)
        {
            return Math.Pow(2.0, j - 1.0) * (Math.Abs(j - 3.0) - 1.3) * Math.Pow(2.0, j) * (i - 3.4) * (j / (3.0 - 1.0));
        }

        public static T[] CreateAndFillMatrixByFunc<T>(int size, Func<int, int, T> func)
        {
            var newMatrix = new T[size * size];
            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    newMatrix[i * size + j] = func(i+1, j+1);
                }
            }

            return newMatrix;
        }

        public static Boolean ValidateMatrixSize(int matrixA)
        {
            return (matrixA > 1 && matrixA <= 50);
        }

        public static String MatrixToString<T>(T[] matrix,  int rows, int cols, IFormatProvider numbersFormat = null) where T : IFormattable
        {
            //TODO: try to use string builder

            StringBuilder strBuffer = new StringBuilder();
            if (numbersFormat == null)
            {
                numbersFormat = CultureInfo.CurrentCulture.NumberFormat;
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    strBuffer.Append((matrix[i*cols + j]).ToString("N", numbersFormat) + ", ");
                }
                strBuffer.Append(Environment.NewLine);
            }

            return strBuffer.ToString();
        }

        static void Main(string[] args)
        {
            double[] matrixA;
            int matrixSize = 0;
            String inputString;
            
            do
            {
                Console.Write("Введите размерность матрицы: ");
                inputString = Console.ReadLine();
            } while (!(int.TryParse(inputString, out matrixSize) && ValidateMatrixSize(matrixSize)));

            matrixA = CreateAndFillMatrixByFunc<double>(matrixSize, FillFunction_ver1);

            //var customNumberFormat = new NumberFormatInfo();
            //customNumberFormat.NumberDecimalDigits = 5;
            Console.Write(MatrixToString(matrixA, matrixSize, matrixSize));

        }
    }
}
