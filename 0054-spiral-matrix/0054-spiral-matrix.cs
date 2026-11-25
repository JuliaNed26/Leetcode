public class Solution {
    private const int minVal = -101;

    public IList<int> SpiralOrder(int[][] matrix) {
        int width = matrix[0].Length;
        int height = matrix.Length;
        var result = new List<int>();
        for(int round = 0; round < (int)Math.Ceiling((decimal)height / 2); round++)
        {
            var shouldEnd = false;
            // right
            for(int i = round; i < width - round; i++)
            {
                result.Add(matrix[round][i]);
                matrix[round][i] = minVal;
            }
            // down
            for(int i = round + 1; i < height - round; i++)
            {
                if(shouldEnd || matrix[i][width - 1 - round] == minVal)
                {
                    shouldEnd = true;
                    break;
                }
                result.Add(matrix[i][width - 1 - round]);
                matrix[i][width - 1 - round] = minVal;
            }
            // left
            for(int i = width - 2 - round; i >= round; i--)
            {
                if(shouldEnd || matrix[height - 1 - round][i] == minVal)
                {
                    shouldEnd = true;
                    break;
                }
                result.Add(matrix[height - 1 - round][i]);
                matrix[height - 1 - round][i] = minVal;
            }
            // up
            for(int i = height - 2 - round; i > round; i--)
            {
                if(shouldEnd || matrix[i][round] == minVal)
                {
                    shouldEnd = true;
                    break;
                }
                result.Add(matrix[i][round]);
                matrix[i][round] = minVal;
            }

            if(shouldEnd)
            {
                break;
            }
        }

        return result;
    }
}