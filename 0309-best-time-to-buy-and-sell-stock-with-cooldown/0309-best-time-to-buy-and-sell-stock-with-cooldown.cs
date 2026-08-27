public class Solution {

    public int MaxProfit(int[] prices) {
        var prevRes = new int[3]; // selling skip, buying skip, selling
        for(int i = prices.Length - 1; i >= 0; i--)
        {
            Console.WriteLine($"sell = {prevRes[0]} buy = {prevRes[1]} prev sell = {prevRes[2]}");
            // buying allowed
            var tempBuy = Math.Max(
                prevRes[1], // skip
                prevRes[0] - prices[i] // buy
            );

            // hold
            var tempHold = Math.Max(
                prevRes[0], // skip
                prevRes[2] + prices[i] // sell
            );
            
            prevRes[2] = prevRes[1];
            prevRes[1] = tempBuy;
            prevRes[0] = tempHold;
        }

        return prevRes[1];
    }
}