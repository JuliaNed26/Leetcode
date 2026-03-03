public class KthLargest {
    private MinHeap _minHeap;
    private int _k;

    public KthLargest(int k, int[] nums) {
        _minHeap = new MinHeap(k);
        _k = k;

        foreach(var num in nums)
        {
            Add(num);
        }
    }

    public int Add(int val) {
        if (!_minHeap.Filled || _minHeap.SmallestElement < val) 
        {
            if (_minHeap.Filled)
            {
                _minHeap.Remove();
            }

            _minHeap.Add(val);
            return _minHeap.SmallestElement;
        }

        return _minHeap.SmallestElement;
    }
}

public class MinHeap
{
    int[] heap;
    int lastFilledIdx = 0;

    public MinHeap(int length)
    {
        heap = new int[length + 1];
    }

    public int SmallestElement => heap[1];

    public bool Filled => lastFilledIdx == heap.Length - 1;

    public void Add(int a)
    {
        heap[++lastFilledIdx] = a;
        var curElemIdx = lastFilledIdx;
        var parentIdx = GetParentIdx(curElemIdx);
        
        while (parentIdx != 0 && heap[parentIdx] > a)
        {
            heap[curElemIdx] = heap[parentIdx];
            heap[parentIdx] = a;
            curElemIdx = parentIdx;
            parentIdx = GetParentIdx(curElemIdx);
        }
    }

    public void Remove()
    {
        heap[1] = heap[lastFilledIdx--];
        var curIdx = 1;
        var leftChildIdx = GetLeftChildIdx(curIdx);
        var rightChildIdx = GetRightChildIdx(curIdx);
        var itemToMove = heap[1];
        while ((leftChildIdx <= lastFilledIdx && heap[leftChildIdx] < heap[curIdx])
            || (rightChildIdx <= lastFilledIdx && heap[rightChildIdx] < heap[curIdx]))
        {
            var idxWithMaxValue = rightChildIdx <= lastFilledIdx
                                  && heap[rightChildIdx] < heap[leftChildIdx]
                                    ? rightChildIdx
                                    : leftChildIdx;
            heap[curIdx] = heap[idxWithMaxValue];
            heap[idxWithMaxValue] = itemToMove;
            curIdx = idxWithMaxValue;
            leftChildIdx = GetLeftChildIdx(curIdx);
            rightChildIdx = GetRightChildIdx(curIdx);    
        }
    }

    private int GetParentIdx(int idx)
    {
        return (int)Math.Floor((double)idx / 2);
    }

    private int GetLeftChildIdx(int idx)
    {
        return 2 * idx;
    }

    private int GetRightChildIdx(int idx)
    {
        return 2 * idx + 1;
    }
}

/**
 * Your KthLargest object will be instantiated and called as such:
 * KthLargest obj = new KthLargest(k, nums);
 * int param_1 = obj.Add(val);
 */
