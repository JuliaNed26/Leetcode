public class Solution {
    public string foreignDictionary(string[] words) {
        var distinctWords = words.Distinct().ToList();
        var graph = new Dictionary<char, HashSet<char>>();
        var charToInDegree = new Dictionary<char, int>();

        for(int i = 0; i < distinctWords.Count; i++)
        {
            for(int k = 0; k < distinctWords[i].Length; k++)
            {
                var curLetter = distinctWords[i][k];
                if(!graph.ContainsKey(curLetter))
                {
                    graph[curLetter] = new HashSet<char>();
                    charToInDegree[curLetter] = 0;
                }
            }
        }

        for(int i = 0; i < distinctWords.Count - 1; i++)
        {
            if(TryGetFirstDiffer(distinctWords[i], distinctWords[i + 1], out var a, out var b))
            {
                if(graph[a.Value].Add(b.Value))
                {
                    charToInDegree[b.Value]++;
                }
            }
            else if(distinctWords[i].Length > distinctWords[i + 1].Length)
            {
                return "";
            }
        }

        var stack = new Stack<char>();
        foreach(var chToInDegree in charToInDegree)
        {
            if(chToInDegree.Value == 0)
            {
                stack.Push(chToInDegree.Key);
            }
        }

        var result = new StringBuilder();
        while(stack.Count != 0)
        {
            var curLetter = stack.Pop();
            result.Append(curLetter);
            foreach(var neighbour in graph[curLetter])
            {
                charToInDegree[neighbour]--;
                if(charToInDegree[neighbour] == 0)
                {
                    stack.Push(neighbour);
                }
            }
        }

        var alphabet = result.ToString();
        return alphabet.Length == graph.Keys.Count() ? alphabet : "";
    }

    public bool TryGetFirstDiffer(string word1, string word2, out char? a, out char? b)
    {
        for(int i = 0; i < word1.Length; i++)
        {
            if(i >= word2.Length)
            {
                break;
            }
            if(word1[i] != word2[i])
            {
                a = word1[i];
                b = word2[i];
                return true;
            }
        }

        a = null;
        b = null;
        return false;
    }
}
