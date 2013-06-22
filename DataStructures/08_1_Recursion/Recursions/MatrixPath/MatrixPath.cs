using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixPath
{
    class MatrixPath
    {
        private const int PASSED = 2;
        private const int ENTRY = 4;
        private const int EXIT = 3;

        static void Main(string[] args)
        {
            int[,] matrix = {
                { 0, 0, 1, 0, 0 },
                { 0, 1, 0, 1, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 1, 0, 0 },
                { 0, 0, 1, 0, 1 }
            };

            int entryRow = 0;
            int entryCol = 0;

            int exitRow = 2;
            int exitCol = 4;

            matrix[entryRow, entryCol] = ENTRY;
            matrix[exitRow, exitCol] = EXIT;

            FindPath(matrix, entryRow, entryRow);
        }

        private static void FindPath(int[,] matrix, int currRow, int currCol)
        {
            // If out of matrix, return
            if (currRow < 0 || currCol < 0)
            {
                return;
            }

            if (currRow >= matrix.GetLength(0) || currCol >= matrix.GetLength(1))
            {
                return;
            }

            // If cell is not passable (==1) return
            if (matrix[currRow, currCol] == 1)
            {
                return;
            }

            // If cell is already passed return
            if (matrix[currRow, currCol] == PASSED)
            {
                return;
            }

            // If end cell is found, print the matrix
            if (matrix[currRow, currCol] == EXIT)
            {
                PrintMatrix(matrix);
            }
            
            matrix[currRow, currCol] = PASSED;

            FindPath(matrix, currRow - 1, currCol);
            FindPath(matrix, currRow, currCol - 1);
            FindPath(matrix, currRow + 1, currCol);
            FindPath(matrix, currRow, currCol + 1);
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0} ", matrix[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
