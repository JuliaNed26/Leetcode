public class Solution {
    public string AddBinary(string a, string b) {
        var result = new StringBuilder();
        var remainder = 0;
        var aCharArray = a.ToCharArray();
        var bCharArray = b.ToCharArray();
        Array.Reverse(aCharArray);
        Array.Reverse(bCharArray);
        a = new string(aCharArray);
        b = new string(bCharArray);

        for(int i = 0; i < Math.Max(a.Length, b.Length); i++)
        {
            var curABit = i < a.Length ? int.Parse(a[i].ToString()) : 0;
            var curBBit = i < b.Length ? int.Parse(b[i].ToString()) : 0;
            var curSum = remainder + curABit + curBBit;
            var curBit = curSum % 2;
            remainder = curSum > 1 ? 1 : 0;
            result.Insert(0, curBit);
        }

        if(remainder == 1)
        {
            result.Insert(0, '1');
        }

        return result.ToString();
    }
}