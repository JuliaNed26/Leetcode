public class MedianFinder {
    PriorityQueue<int, int> firstHalf;
    PriorityQueue<int, int> secondHalf;

    public MedianFinder() {
        firstHalf = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a))); // max heap
        secondHalf = new PriorityQueue<int, int>(); // min heap
    }
    
    public void AddNum(int num) {
        if(secondHalf.Count > 0 && secondHalf.Peek() < num)
        {
            secondHalf.Enqueue(num, num);
        }
        else
        {
            firstHalf.Enqueue(num, num);
        }

        if(Math.Abs(secondHalf.Count - firstHalf.Count) > 1)
        {
            int balanceNum = 0;

            if(secondHalf.Count > firstHalf.Count)
            {
                balanceNum = secondHalf.Dequeue();
                firstHalf.Enqueue(balanceNum, balanceNum);
            }
            else
            {
                balanceNum = firstHalf.Dequeue();
                secondHalf.Enqueue(balanceNum, balanceNum);
            }
        }
    }
    
    public double FindMedian() {
        if(firstHalf.Count == secondHalf.Count)
        {
            return (firstHalf.Peek() + secondHalf.Peek()) / 2.0;
        }
        if(firstHalf.Count < secondHalf.Count)
        {
            return secondHalf.Peek();
        }
        return firstHalf.Peek();
    }
}