public class Solution {
    const int MaxPrice = int.MaxValue;
    Dictionary<int, Dictionary<int, int>> nodeWithStopsWithPrice;

    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        nodeWithStopsWithPrice = new();
        var graph = flights.GroupBy(f => f[0])
                            .ToDictionary(
                                g => g.Key,
                                g => g.Select(r => new List<int>(2) {r[1], r[2]}).ToList()
                            );
        var priorityQueue = new PriorityQueue<(int node, int stopsLeft), int>();
        priorityQueue.Enqueue((src, k), 0);
        
        while(priorityQueue.Count != 0)
        {
            priorityQueue.TryDequeue(out var curPath, out var curPrice);
            var upserted = false;

            if (curPath.node == dst || curPath.stopsLeft >= 0)
            {
                upserted = UpsertNodePriceForStops(
                    curPath.node,
                    curPath.stopsLeft,
                    curPrice);
            }

            if(!upserted || curPath.node == dst)
            {
                continue;
            }

            if(graph.TryGetValue(curPath.node, out var neighbours))
            {
                foreach(var neighbour in neighbours)
                {
                    priorityQueue.Enqueue(
                        (neighbour[0], curPath.stopsLeft - 1),
                        curPrice + neighbour[1]);
                }
            }
        }

        var dstLowestPrice = nodeWithStopsWithPrice.TryGetValue(dst, out var pricesWithStops)
                                ? pricesWithStops.Values.Min()
                                : -1;

        return dstLowestPrice;    
    }

    private bool UpsertNodePriceForStops(
        int node,
        int stopsLeft,
        int price)
    {
        if (!nodeWithStopsWithPrice.ContainsKey(node))
        {
            nodeWithStopsWithPrice[node] = new Dictionary<int, int>();
        }

        var previousPrice = nodeWithStopsWithPrice[node].GetValueOrDefault(
                                                            stopsLeft, 
                                                            MaxPrice);
        var upserted = previousPrice > price;

        if(upserted)
        {
            nodeWithStopsWithPrice[node][stopsLeft] = price;    
        }

        return upserted;
    }
}
