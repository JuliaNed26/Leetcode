public class Solution {
    public void Rotate(int[][] matrix) {
        var n = matrix.Length;
        // transpose
        for(int i = 0; i < n; i++)
        {
            for(int j = i; j < n; j++)
            {
                var tmp = matrix[i][j];
                matrix[i][j] = matrix[j][i];
                matrix[j][i] = tmp;
            }
        }

        // reverse
        for(int i = 0; i < n; i++)
        {
            for(int j = 0; j < n / 2; j++)
            {
                var tmp = matrix[i][j];
                matrix[i][j] = matrix[i][n - 1 - j];
                matrix[i][n - 1 - j] = tmp;
            }
        }
    }
}