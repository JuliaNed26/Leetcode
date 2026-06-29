public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        int l = 0;
        int r = matrix.Length - 1;
        while(l < r) 
        {
            var med = l + (int)Math.Ceiling(((double)r - (double)l) / 2);
            if(matrix[med][0] == target)
            {
                return true;
            }
            else if(matrix[med][0] < target)
            {
                l = med;
            }
            else
            {
                r = med - 1;
            }
        }

        if(r < 0)
        {
            return false;
        }

        var row = l;
        l = 0;
        r = matrix[0].Length - 1;
        while(l < r) 
        {
            var med = l + (int)Math.Ceiling(((double)r - (double)l) / 2);
            if(matrix[row][med] == target)
            {
                return true;
            }
            else if(matrix[row][med] < target)
            {
                l = med;
            }
            else
            {
                r = med - 1;
            }
        }

        return matrix[row][l] == target;
    }
}