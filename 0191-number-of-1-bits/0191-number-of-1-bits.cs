public class Solution {
    public int HammingWeight(int n) {
        var result = 0;
        while(n != 0)
        {
            result++;
            n -= (int)Math.Pow(2, Math.Floor(Math.Log2(n)));
        }
        return result;
    }
}