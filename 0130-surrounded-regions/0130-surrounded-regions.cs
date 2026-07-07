public class Solution {
    public void Solve(char[][] board) {
        const char WATER = 'X';
        const char LAND = 'O';
        const char EDGE_LAND = '3';

        var width = board[0].Length;
        var height = board.Length;
        var stack = new Stack<(int y, int x)>();
        for(int j = 0; j < width; j++)
        {
            if(board[0][j] == LAND)
            {
                stack.Push((0, j));
            }
            if(board[height - 1][j] == LAND)
            {
                stack.Push((height - 1, j));
            }
        }
        for(int j = 0; j < height; j++)
        {
            if(board[j][0] == LAND)
            {
                stack.Push((j, 0));
            }
            if(board[j][width - 1] == LAND)
            {
                stack.Push((j, width - 1));
            }
        }

        var sides = new (int y, int x)[] {(1,0), (0,1), (-1,0), (0,-1)};
        while(stack.Count != 0)
        {
            (int y, int x) = stack.Pop();
            if(board[y][x] == EDGE_LAND)
            {
                continue;
            }

            board[y][x] = EDGE_LAND;
            foreach(var side in sides)
            {
                var curX = x + side.x;
                var curY = y + side.y;
                if(curX >= 0 && curY >= 0 && curX < width && curY < height
                    && board[curY][curX] == LAND)
                {
                    stack.Push((curY, curX));
                }
            }
        }

        for(int i = 0; i < height; i++)
        {
            for(int j = 0; j < width; j++)
            {
                if(board[i][j] == LAND)
                {
                    board[i][j] = WATER;
                }
                if(board[i][j] == EDGE_LAND)
                {
                    board[i][j] = LAND;
                }
            }
        }
    }
}