using System.Linq;
using System.Runtime.InteropServices;

namespace Lab6
{
    public class Green
    {
        public void Task1(ref int[] A, ref int[] B)
        {

            // code here
            DeleteMaxElement(ref A);
            DeleteMaxElement(ref B);
            A = CombineArrays(A,B);
            // end

        }
        public void Task2(int[,] matrix, int[] array)
        {

            // code here
            int rows = matrix.GetLength(0);

            int limit = Math.Min(rows, array.Length);

            for (int i = 0; i < limit; i++)
            {
                int maxCol;
                int max = FindMaxInRow(matrix, i, out maxCol);

                if (max < array[i])
                {
                    matrix[i, maxCol] = array[i];
                }
            }

            // end

        }
        public void Task3(int[,] matrix)
        {

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1))
                return; 
            
            int row, col;
            FindMax(matrix, out row, out col);
            SwapColWithDiagonal(matrix, col);
            // end

        }
        public void Task4(ref int[,] matrix)
        {

            // code here
            for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
            {
                bool hasZero = false;
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] == 0)
                        hasZero = true;
                        break;

                if (hasZero)
                    RemoveRow(ref matrix, i);
            }
            // end

        }
        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1))
                return; answer;
            
            answer = GetRowsMinElements(matrix);
            // end

            return answer;
        }
        public int[] Task6(int[,] A, int[,] B)
        {
            int[] answer = null;

            // code here
            answer = CombineArrays( SumPositiveElementsInColumns(A),SumPositiveElementsInColumns(B));
            // end

            return answer;
        }
        public void Task7(int[,] matrix, Sorting sort)
        {

            // code here

            // end

        }
        public int Task8(double[] A, double[] B)
        {
            int answer = 0;

            // code here

            // end

            return answer;
        }
        public void Task9(int[,] matrix, Action<int[]> sorter)
        {

            // code here

            // end

        }
        public double Task10(int[][] array, Func<int[][], double> func)
        {
            double res = 0;

            // code here

            // end

            return res;
        }


        
        public void DeleteMaxElement(ref int[] array)
        {
            if (array == null || array.Length == 0)
                return;

            int max = array.Max();
            int maxindex = Array.IndexOf(array, max);
            array = array
                .Where((x, i) => i != maxindex)
                .ToArray();
        }

        public int[] CombineArrays(int[] A, int[] B)
        {
            int[] C = new int[A.Length + B.Length];
            int j = 0;

            for (int i = 0; i < A.Length; i++)
            {
                C[j] = A[i];
                j++;
            }

            for (int i = 0; i < B.Length; i++)
            {
                C[j] = B[i];
                j++;
            }

            return C;
        }
        public int FindMaxInRow(int[,] matrix, int row, out int col)
        {
            int cols = matrix.GetLength(1);

            int max = matrix[row, 0];
            col = 0;

            for (int j = 1; j < cols; j++)
            {
                if (matrix[row, j] > max)
                {
                    max = matrix[row, j];
                    col = j;
                }
            }

            return max;
        }

        public void FindMax(int[,] matrix, out int row, out int col)
        {
            row = 0;
            col = 0;
            int max = matrix[0,0];

            for (int i=0; i<matrix.GetLength(0);i++)
                for (int j=0; j<matrix.GetLength(1);j++)
                    if (max<matrix[i,j]){
                        row = i;
                        col = j;
                        max = matrix[i,j]
                    }
                

        }

        public void SwapColWithDiagonal(int[,] matrix, int col)
        {
            for (int i=0; i<matrix.GetLength(0);i++)
            {
                (matrix[i,col], matrix[i,i] )= (matrix[i,i], matrix[i,col]);
            }
        }
        public void RemoveRow(ref int[,] matrix, int row)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[,] newMatrix = new int[rows - 1, cols];
            int k = 0;
            for (int i=0; i< rows; i++)
            {
                if (i==row) {continue;}
                for (int j=0; j<cols; j++)
                {
                    newMatrix[k,j] = matrix[i,j];
                }
                k++;
            }
            matrix = newMatrix;
        }
        public int[] GetRowsMinElements(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[] resp = new int[rows];
            for (int i=0; i<rows; i++) {
                int min = matrix[i,i];
                for (int j=i; j<cols; j++){
                    if (min>matrix[i,j]){
                        min = matrix[i,j];
                    }
                }
                resp[i] = min;
            }
            return resp;
        }

        public int[] SumPositiveElementsInColumns(int[,] matrix) 
        {
            int rows = matrix.GetLength(0); 
            int cols = matrix.GetLength(1);
            int[] ans = new int[cols];
            for (int i = 0; i< rows; i++)
            {
              for (int j = 0; j<cols; j++)
              {
                if (matrix[i,j] > 0) 
                {
                  ans[j] += matrix[i,j];
                }
              }
            }
            return ans;
        }
    }
}
