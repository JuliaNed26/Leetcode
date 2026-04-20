public class Solution {
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        const int MaxPrice = int.MaxValue;
        var graph = flights.GroupBy(f => f[0])
                            .ToDictionary(
                                g => g.Key,
                                g => g.Select(r => new List<int>(2) {r[1], r[2]}).ToList()
                            );
        var memo = new Dictionary<(int node, int stops), int>();
        var price = DFS(src, k);
        return price == MaxPrice ? -1 : price;

        int DFS(int node, int stopsLeft)
        {
            if (node == dst)
            {
                return 0;
            }

            if (stopsLeft < 0)
            {
                return MaxPrice;
            }

            if (memo.TryGetValue((node, stopsLeft), out var cached))
            {
                return cached;
            }

            var best = MaxPrice;
            if (graph.TryGetValue(node, out var routes))
            {
                foreach (var route in routes)
                {
                    var sub = DFS(route[0], stopsLeft - 1);
                    if (sub != MaxPrice)
                    {
                        best = Math.Min(best, route[1] + sub);
                    }
                }
            }

            return memo[(node, stopsLeft)] = best;
        }
    }
}
