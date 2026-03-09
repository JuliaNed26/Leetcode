public class Solution {
    public int LastStoneWeight(int[] stones) {
        var maxHeap = new MaxHeap(stones.Length);
        foreach(var stone in stones)
        {
            maxHeap.Add(stone);
        }

        while(maxHeap.Count > 1)
        {
            var first = maxHeap.Remove();
            var second = maxHeap.Remove();
            var newStoneWeight = first - second;
            if (newStoneWeight > 0)
            {
                maxHeap.Add(newStoneWeight);
            }
        }

        return maxHeap.Count > 0 ? maxHeap.Remove() : 0;
    }
}

public class MaxHeap
{
    private int[] _heap;
    private int _lastFilledIdx = 0;

    public MaxHeap(int count)
    {
        _heap = new int[count + 1];
    }

    public int Count => _lastFilledIdx;

    public void Add(int num)
    {
        _heap[++_lastFilledIdx] = num;
        var parentIndex = GetParentIdx(_lastFilledIdx);
        var curIndex = _lastFilledIdx;
        while(parentIndex != 0 && _heap[parentIndex] < _heap[curIndex])
        {
            _heap[curIndex] = _heap[parentIndex];
            _heap[parentIndex] = num;
            curIndex = parentIndex;
            parentIndex = GetParentIdx(curIndex);
        }
    }

    public int Remove()
    {
        var removedItem = _heap[1];
        _heap[1] = _heap[_lastFilledIdx--];
        var curIndex = 1;
        var leftChildIndex = GetLeftChildIdx(curIndex);
        var rightChildIndex = GetRightChildIdx(curIndex);
        var itemToMove = _heap[curIndex];
        while((leftChildIndex <= _lastFilledIdx && _heap[curIndex] < _heap[leftChildIndex])
                || (rightChildIndex <= _lastFilledIdx && _heap[curIndex] < _heap[rightChildIndex]))
        {
            var greaterChildIdx = rightChildIndex <= _lastFilledIdx
                                    && _heap[leftChildIndex] < _heap[rightChildIndex]
                                ? rightChildIndex
                                : leftChildIndex;
            _heap[curIndex] = _heap[greaterChildIdx];
            _heap[greaterChildIdx] = itemToMove;
            curIndex = greaterChildIdx;
            leftChildIndex = GetLeftChildIdx(curIndex);
            rightChildIndex = GetRightChildIdx(curIndex);    
        }

        return removedItem;
    }

    private int GetParentIdx(int i)
    {
        return (int)Math.Floor((double)i / 2);
    }

    private int GetLeftChildIdx(int i)
    {
        return i * 2;
    }

    private int GetRightChildIdx(int i)
    {
        return i * 2 + 1;
    }
}