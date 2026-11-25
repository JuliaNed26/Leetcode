public class Solution {
    public void SetZeroes(int[][] matrix) {
        var rowsZero = new HashSet<int>();
        var colsZero = new HashSet<int>();
        for(int i = 0; i < matrix.Length; i++) 
        {
            for(int j = 0; j < matrix[0].Length; j++)
            {
                if(matrix[i][j] == 0)
                {
                    rowsZero.Add(i);
                    colsZero.Add(j);
                }
            }
        }

        foreach(var r in rowsZero)
        {
            for(int i = 0; i < matrix[0].Length; i++)
            {
                matrix[r][i] = 0;
            }
        }

        foreach(var c in colsZero)
        {
            for(int i = 0; i < matrix.Length; i++)
            {
                matrix[i][c] = 0;
            }
        }
    }
}