public class Solution {
    public string foreignDictionary(string[] words) {
        const int UNTOUCHED = 0;
        const int VISITING = 1;
        const int VISITED = 2;

        var colours = new Dictionary<char, int>();
        var distinctWords = words.Distinct().ToList();
        var graph = new Dictionary<char, HashSet<char>>();

        for(int i = 0; i < distinctWords.Count; i++)
        {
            for(int k = 0; k < distinctWords[i].Length; k++)
            {
                var curLetter = distinctWords[i][k];
                if(!graph.ContainsKey(curLetter))
                {
                    graph[curLetter] = new HashSet<char>();
                    colours[curLetter] = UNTOUCHED;
                }
            }
        }

        for(int i = 0; i < distinctWords.Count - 1; i++)
        {
            if(TryGetFirstDiffer(distinctWords[i], distinctWords[i + 1], out var a, out var b))
            {
                graph[a.Value].Add(b.Value);
            }
            else if(distinctWords[i].Length > distinctWords[i + 1].Length)
            {
                return "";
            }
        }
        var result = new List<char>();

        foreach(var colouredLetter in colours)
        {
            if(colouredLetter.Value == UNTOUCHED)
            {
                if(!Dfs(colouredLetter.Key))
                {
                    return "";
                }
            }
        }

        result.Reverse();
        var sb = new StringBuilder();
        foreach (var c in result) {
            sb.Append(c);
        }
        return sb.ToString();

        bool Dfs(char startLetter)
        {
            var stack = new Stack<char>();
            stack.Push(startLetter);
            while(stack.Count != 0)
            {
                var curLetter = stack.Peek();
                if(colours[curLetter] == VISITING || colours[curLetter] == VISITED)
                {
                    if(colours[curLetter] == VISITING)
                    {
                        result.Add(curLetter);
                    }
                    colours[curLetter] = VISITED;
                    stack.Pop();
                    continue;
                }

                colours[curLetter] = VISITING;
                foreach(var neighbour in graph[curLetter])
                { 
                    if(colours[neighbour] == VISITING)
                    {
                        return false;
                    }
                    if(colours[neighbour] == UNTOUCHED)
                    {
                        stack.Push(neighbour);
                    }
                }
            }
            return true;
        }
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
