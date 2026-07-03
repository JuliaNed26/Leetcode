public class Solution {
    public int OrangesRotting(int[][] grid) {
        int width = grid[0].Length;
        int height = grid.Length;
        const int FRESH = 1;
        const int ROTTEN = 2;

        var queue = new Queue<(int y, int x, int time)>();
        for(int i = 0; i < grid.Length; i++)
        {
            for(int k = 0; k < grid[0].Length; k++)    
            {
                if(grid[i][k] == ROTTEN)
                {
                    queue.Enqueue((i, k, 0));
                }
            }
        }

        var sides = new List<(int y, int x)>() { (0, 1), (1, 0), (0, -1), (-1, 0) };
        var time = 0;
    
        while(queue.Count != 0)
        {
            (int y, int x, int curTime) = queue.Dequeue();
            time = curTime;
            foreach(var side in sides)
            {
                var curX = x + side.x;
                var curY = y + side.y;
                if (curX >= 0 && curX < width && curY >= 0 && curY < height 
                    && grid[curY][curX] == FRESH)
                {
                    grid[curY][curX] = ROTTEN;
                    queue.Enqueue((curY, curX, curTime + 1));
                }
            }
        }

        for(int i = 0; i < grid.Length; i++)
        {
            for(int k = 0; k < grid[0].Length; k++)    
            {
                if(grid[i][k] == FRESH)
                {
                    return -1;
                }
            }
        }

        return time;
    }
}