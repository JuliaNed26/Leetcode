public class Solution {
    public IList<IList<int>> PacificAtlantic(int[][] heights) {
        int[][] oceans = Enumerable.Range(0, heights.Length)
                                    .Select(_ => new int[heights[0].Length])
                                    .ToArray();

        PacificBFS(heights, oceans);
        AtlanticBFS(heights, oceans);
        var result = new List<IList<int>>();
        for(var i = 0; i < oceans.Length; i++)
        {
            for(var j = 0; j < oceans[0].Length; j++)
            {
                if(oceans[i][j] == 2)
                {
                    result.Add(new List<int>() {i, j});
                }
            }
        }

        return result;
    }

    private void PacificBFS(int[][] heights, int[][] result)
    {
        var queue = new Queue<(int x, int y)>();
        for(int i = 0 ; i < heights.Length; i++)
        {
            queue.Enqueue((0, i));
        }
        for(int i = 0 ; i < heights[0].Length; i++)
        {
            queue.Enqueue((i, 0));
        }

        while(queue.Count != 0)
        {
            (int x, int y) = queue.Dequeue();
            if(x >= heights[0].Length || y >= heights.Length || result[y][x] == 1)
            {
                continue;
            }
            
            result[y][x] = 1;
            if(y < heights.Length - 1 && heights[y + 1][x] >= heights[y][x])
            {
                queue.Enqueue((x, y + 1));
            }
            if(x < heights[0].Length - 1 && heights[y][x + 1] >= heights[y][x])
            {
                queue.Enqueue((x + 1, y));
            }
            if(x >= 1 && heights[y][x - 1] >= heights[y][x])
            {
                queue.Enqueue((x - 1, y));
            }
            if(y >= 1 && heights[y - 1][x] >= heights[y][x])
            {
                queue.Enqueue((x, y - 1));
            }
        }

        foreach(var res in result)
        {
            foreach(var cell in res)
            {
                Console.Write(cell + " ");
            }
            Console.WriteLine();
        }
    }

    private void AtlanticBFS(int[][] heights, int[][] result)
    {
        var queue = new Queue<(int x, int y)>();
        var visited = new bool[heights[0].Length * heights.Length];

        for(int i = 0 ; i < heights.Length; i++)
        {
            queue.Enqueue((heights[0].Length - 1, i));
        }
        for(int i = 0 ; i < heights[0].Length; i++)
        {
            queue.Enqueue((i, heights.Length - 1));
        }

        while(queue.Count != 0)
        {
            (int x, int y) = queue.Dequeue();
            if(x < 0 || y >= heights.Length || visited[FlattenIdx(x, y)])
            {
                continue;
            }
            
            visited[FlattenIdx(x, y)] = true;
            result[y][x] += 1;

            if(y >= 1 && heights[y - 1][x] >= heights[y][x])
            {
                queue.Enqueue((x, y - 1));
            }
            if(x >= 1 && heights[y][x - 1] >= heights[y][x])
            {
                queue.Enqueue((x - 1, y));
            }
            if(x < heights[0].Length - 1 && heights[y][x + 1] >= heights[y][x])
            {
                queue.Enqueue((x + 1, y));
            }
            if(y < heights.Length - 1 && heights[y + 1][x] >= heights[y][x])
            {
                queue.Enqueue((x, y + 1));
            }
        }

        int FlattenIdx(int x, int y)
        {
            return y * heights[0].Length + x;
        }
    }
}