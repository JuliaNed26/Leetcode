public class Solution {
    public void Solve(char[][] board) {
        const char WATER = 'X';
        const char LAND = 'O';
        const char EDGE_LAND = '3';

        var width = board[0].Length;
        var height = board.Length;
        var queue = new Queue<(int y, int x)>();
        for(int j = 0; j < width; j++)
        {
            if(board[0][j] == LAND)
            {
                queue.Enqueue((0, j));
            }
            if(board[height - 1][j] == LAND)
            {
                queue.Enqueue((height - 1, j));
            }
        }
        for(int j = 0; j < height; j++)
        {
            if(board[j][0] == LAND)
            {
                queue.Enqueue((j, 0));
            }
            if(board[j][width - 1] == LAND)
            {
                queue.Enqueue((j, width - 1));
            }
        }

        var sides = new (int y, int x)[] {(1,0), (0,1), (-1,0), (0,-1)};
        while(queue.Count != 0)
        {
            (int y, int x) = queue.Dequeue();
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
                    queue.Enqueue((curY, curX));
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