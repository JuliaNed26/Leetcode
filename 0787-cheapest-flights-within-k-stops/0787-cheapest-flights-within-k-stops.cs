public class Solution {
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        int INF = int.MaxValue;
        List<int[]>[] adj = new List<int[]>[n];
        int[][] dist = new int[n][];

        for (int i = 0; i < n; i++) {
            adj[i] = new List<int[]>();
            dist[i] = new int[k + 2];
            Array.Fill(dist[i], INF);
        }

        foreach (var flight in flights) {
            adj[flight[0]].Add(new int[] { flight[1], flight[2] });
        }

        dist[src][0] = 0;
        var minHeap = new PriorityQueue<(int cst, int node, int stops), int>();
        minHeap.Enqueue((0, src, 0), 0);

        while (minHeap.Count > 0) {
            var (cst, node, stops) = minHeap.Dequeue();
            if (node == dst) return cst;
            if (stops > k) continue;

            foreach (var neighbor in adj[node]) {
                int nei = neighbor[0], w = neighbor[1];
                int nextCst = cst + w;
                int nextStops = stops + 1;

                if (dist[nei][nextStops] > nextCst) {
                    dist[nei][nextStops] = nextCst;
                    minHeap.Enqueue((nextCst, nei, nextStops), nextCst);
                }
            }
        }
        return -1;
    }
}