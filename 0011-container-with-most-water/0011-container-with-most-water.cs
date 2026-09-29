public class Solution {
    public int MaxArea(int[] height) {
        var l = 0;
        var r = height.Length - 1;
        var max = 0;
        while(l < r)
        {
            var heightL = height[l];
            var heightR = height[r];
            var waterAmount = Math.Min(heightL, heightR) * (r - l);
            max = Math.Max(max, waterAmount);
            if(heightL < heightR)
            {
                l++;
            }
            else
            {
                r--;
            }
        }

        return max;
    }
}