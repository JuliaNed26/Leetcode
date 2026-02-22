public class Solution {
    public int NumIslands(char[][] grid) {
        Stack<(int x, int y)> stack = [];
        int islandsCount = 0;
        for(int y = 0; y < grid.Length; y++) 
        {
            for(int x = 0; x < grid[0].Length; x++)
            {
                if(grid[y][x] != '0')
                {
                    stack.Push((x, y));
                    while(stack.Count != 0)
                    {
                        var peek = stack.Pop();
                        if(peek.x >= 0 && peek.x < grid[0].Length
                            && peek.y >= 0 && peek.y < grid.Length
                            && grid[peek.y][peek.x] != '0')
                        {
                            grid[peek.y][peek.x] = '0';
                            stack.Push((peek.x + 1, peek.y));
                            stack.Push((peek.x, peek.y + 1));
                            stack.Push((peek.x - 1, peek.y));
                            stack.Push((peek.x, peek.y - 1));
                        }
                    }
                    islandsCount++;
                }
            }
        }

        return islandsCount;
    }
}
