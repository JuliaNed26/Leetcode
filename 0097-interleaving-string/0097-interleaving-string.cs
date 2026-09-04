public class Solution {
    private string _strToTest;
    private string _firstStr;
    private string _secondStr;
    private Dictionary<(int l, int r), bool> _dp;

    public bool IsInterleave(string s1, string s2, string s3) {
        if(s1.Length + s2.Length != s3.Length)
        {
            return false;
        }

        _strToTest = s3;
        _firstStr = s1;
        _secondStr = s2;
        _dp = new Dictionary<(int l, int r), bool>(); 

        return IsInterleavingRecursive(0, 0, 0);
    }
    
    private bool IsInterleavingRecursive(int l, int r, int curIdx)
    {
        if(curIdx >= _strToTest.Length)
        {
            return true;
        }

        if(l >= _firstStr.Length && r >= _secondStr.Length)
        {
            return false;
        }

        if(_dp.TryGetValue((l,r), out var isInterleaving))
        {
            return isInterleaving;
        }

        if(l < _firstStr.Length && _firstStr[l] == _strToTest[curIdx])
        {
            isInterleaving = IsInterleavingRecursive(l + 1, r, curIdx + 1);
        }
        if(!isInterleaving && (r < _secondStr.Length && _secondStr[r] == _strToTest[curIdx]))
        {
            isInterleaving = IsInterleavingRecursive(l, r + 1, curIdx + 1);
        }

        _dp[(l,r)] = isInterleaving;
        return isInterleaving;
    }
}