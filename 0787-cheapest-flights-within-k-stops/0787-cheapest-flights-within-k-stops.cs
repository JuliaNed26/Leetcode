public class Solution {
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        const int MaxPrice = int.MaxValue;
        var prices = Enumerable.Repeat(MaxPrice, n).ToArray();
        prices[src] = 0;
        var curFlightPrices = new int[n];
        prices.CopyTo(curFlightPrices, 0);
        for(int i = 0; i < k + 1; i++)
        {
            foreach(var flight in flights)
            {
                var curSrc = flight[0];
                var curDst = flight[1];
                var curPrice = flight[2];
                if(prices[curSrc] != MaxPrice
                    && prices[curSrc] + curPrice < curFlightPrices[curDst])
                {
                    curFlightPrices[curDst] = prices[curSrc] + curPrice;
                }
            }

            curFlightPrices.CopyTo(prices, 0);
        }

        return prices[dst] == MaxPrice ? -1 : prices[dst];
    }
}