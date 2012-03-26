using CourcePaperWork;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace CourcePaperWorkTest
{
    [TestClass()]
    public class ProgramTest
    {
        [TestMethod()]
        [DeploymentItem("CourcePaperWork.exe")]
        public void FillFunctionTest()
        {
            Assert.AreEqual(Program.FillFunction_ver1(0, 0), -0.0, "FillFunction(0,0) should return -0.0");
            Assert.AreEqual(Program.FillFunction_ver1(1, 1), -1.6799999999999999, "FillFunction(1,1) should return -1.6799999999999999");
            Assert.AreEqual(Program.FillFunction_ver1(-1, -1), 0.74250000000000016, "FillFunction(0,0) should return 0.74250000000000016");
            Assert.AreEqual(Program.FillFunction_ver1(100, 100), 371388289567938600000000000000000000000000000000000000000000000000.0, "FillFunction(100,100) should return 371388289567938600000000000000000000000000000000000000000000000000.0");
        }

        [TestMethod()]
        [DeploymentItem("CourcePaperWork.exe")]
        public void ValidateMatrixDimensionTest()
        {
            Assert.AreEqual(Program.ValidateMatrixSize(-1), false, "ValidateMatrixDimension(-1) = false; Sizes bellow 2 is not valid");
            Assert.AreEqual(Program.ValidateMatrixSize(0), false, "ValidateMatrixDimension(0) = false; Sizes bellow 2 is not valid");
            Assert.AreEqual(Program.ValidateMatrixSize(1), false, "ValidateMatrixDimension(1) = false; Sizes bellow 2 is not valid");
            Assert.AreEqual(Program.ValidateMatrixSize(2), true, "ValidateMatrixDimension(2) = true; Sizes bellow 2 is not valid");
            Assert.AreEqual(Program.ValidateMatrixSize(5), true, "ValidateMatrixDimension(5) = true; Sizes bellow 2 is not valid");
            Assert.AreEqual(Program.ValidateMatrixSize(50), true, "ValidateMatrixDimension(50) = true; Sizes greater than 50 is not valid");
            Assert.AreEqual(Program.ValidateMatrixSize(51), false, "ValidateMatrixDimension(51) = false; Sizes greater than 50 is not valid");
            Assert.AreEqual(Program.ValidateMatrixSize(100), false, "ValidateMatrixDimension(100) = false; Sizes greater than 50 is not valid");        
        }

        delegate double TestFillFunction(int i, int j);

        [TestMethod()]
        public void CreateAndFillMatrixByFuncTest()
        {
            //Arrange
            var matrixSize = 2;
            var expected = new[] { 0.0, 1.0, 2.0, 3.0 };

            Func<int, int, double> fillFuncMock = (i, j) => (double)((i-1)*matrixSize + (j-1));

            //Act
            var matrix = Program.CreateAndFillMatrixByFunc<double>(matrixSize, fillFuncMock);

            //Assert
            Assert.AreEqual(expected.Length, matrix.Length, "Length");

           CollectionAssert.AreEquivalent(expected, matrix);
        }

        [TestMethod()]
        public void MatrixToStringTest()
        {
            //Arrange
            var matrixCols = 3;
            var matrixRows = 2;
            var matrix = new[] { 0.0, 1.0, 2.0, 3.0, 4.0, 5.0 };
            var customNumberFormat = new NumberFormatInfo();
            customNumberFormat.NumberDecimalDigits = 1;

            String expectedString = "0.0, 1.0, 2.0, "+Environment.NewLine+"3.0, 4.0, 5.0, "+Environment.NewLine;
         

            //Act
            var matrixString = Program.MatrixToString<double>(matrix, matrixRows, matrixCols, customNumberFormat);

            //Assert
            Assert.AreEqual(expectedString.Length, matrixString.Length, "Length of strings");
            Assert.AreEqual(expectedString, matrixString, "Strings it selves");
        }

    }
}
