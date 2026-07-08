public class Solution {
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
        var graph = wordList.ToDictionary(w => w, _ => new HashSet<string>());
        graph[beginWord] = new HashSet<string>();
        if(!graph.ContainsKey(endWord))
        {
            return 0;
        }

        var wordsToDepth = wordList.ToDictionary(w => w, _ => int.MaxValue);
        wordsToDepth[beginWord] = int.MaxValue;

        foreach(var word in wordsToDepth.Keys)
        {
            foreach(var wordToCompare in wordsToDepth.Keys)
            {
                if(word == wordToCompare || graph[word].Contains(wordToCompare))
                {
                    continue;
                }
                if(HasOnlyOneCharDiffer(word, wordToCompare))
                {
                    graph[word].Add(wordToCompare);
                    graph[wordToCompare].Add(word);
                }
            }
        }

        var queue = new Queue<(string word, int depth)>();
        queue.Enqueue((endWord, 1));
        while(queue.Count != 0)
        {
            (string word, int curDepth) = queue.Dequeue();
            if(wordsToDepth[word] <= curDepth)
            {
                continue;
            }
            if(word == beginWord)
            {
                return curDepth;
            }

            wordsToDepth[word] = curDepth;
            foreach(var neighbour in graph[word])
            {
                queue.Enqueue((neighbour, curDepth + 1));
            }
        }

        return 0;
    }

    private bool HasOnlyOneCharDiffer(string w1, string w2)
    {
        var lettersDiffer = 0;
        for(int i = 0; i < w1.Length; i++)
        {
            if(w1[i] != w2[i])
            {
                lettersDiffer++;
                if(lettersDiffer > 1)
                {
                    return false;
                }
            }
        }

        return true;
    }
}