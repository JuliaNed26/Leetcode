public class Solution {
    public int OrangesRotting(int[][] grid) {
        const int FRESH = 1;
        const int ROTTEN = 2;
        const int ROTTING = 3;

        int width = grid[0].Length;
        int height = grid.Length;

        var freshCount = 0;
        for(int i = 0; i < grid.Length; i++)
        {
            for(int k = 0; k < grid[0].Length; k++)    
            {
                if(grid[i][k] == FRESH)
                {
                    freshCount++;
                }
            }
        }

        var time = 0;
        var sides = new List<(int y, int x)>() {(0,1),(1,0),(-1,0),(0,-1)};
        while(freshCount > 0)
        {
            var anyRotting = false;
            for(int i = 0; i < height; i++)
            {
                for(int j = 0; j < width; j++)
                {
                    if(grid[i][j] == ROTTEN)
                    {
                        foreach(var side in sides)
                        {
                            var curX = j + side.x;
                            var curY = i + side.y;
                            if(curX >= 0 && curX < width && curY >= 0 && curY < height
                                && grid[curY][curX] == FRESH) 
                            {
                                anyRotting = true;
                                grid[curY][curX] = ROTTING;
                                freshCount--;
                            }
                        }
                    }
                }
            }
            
            if(!anyRotting)
            {
                return -1;
            }

            for(int i = 0; i < height; i++)
            {
                for(int j = 0; j < width; j++)
                {
                    if(grid[i][j] == ROTTING)
                    {
                        grid[i][j] = ROTTEN;
                    }
                }
            }

            time++;
        }

        return time;
    }
}