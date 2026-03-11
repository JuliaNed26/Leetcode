public class Solution {
    private int _endPointer;
    public int LastStoneWeight(int[] stones) {
        Array.Sort(stones);
        _endPointer = stones.Length;
        while(_endPointer > 1)
        {
            var first = stones[_endPointer - 1];
            var second = stones[_endPointer - 2];
            _endPointer -= 2;
            var substractionResult = first - second;
            if (substractionResult > 0)
            {
                InsertToSortedArray(stones, substractionResult);
            }
        }

        return _endPointer > 0 ? stones[0] : 0;
    }

    private void InsertToSortedArray(int[] array, int num)
    {
        int l = 0;
        int r = _endPointer;
        int idxToInsert = -1;
        while(l < r) 
        {
            int mid = (int)Math.Floor(((double)r + l) / 2);
            if(array[mid] > num)
            {
                r = mid;
            }
            else if(array[mid] < num)
            {
                l = mid + 1;
            }
            else
            {
                idxToInsert = mid;
                break;
            }
        }

        if(idxToInsert == -1)
        {
            idxToInsert = l;
        }

        for(int i = _endPointer; i > idxToInsert; i--)
        {
            array[i] = array[i - 1];
        }
        array[idxToInsert] = num;
        _endPointer += 1;
    }
}
