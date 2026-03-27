public class Solution {
    public int[] FindRedundantConnection(int[][] edges) {
        var dsu = new DSU(edges.Length);
        foreach(var edge in edges)
        {
            if(!dsu.Union(edge[0], edge[1]))
            {
                return edge;
            }
        }
        return [0,0];
    }
}

public class DSU
{
    private int[] parents;
    private int[] ranks;
    
    public DSU(int count)
    {
        parents = Enumerable.Range(0, count + 1).ToArray();
        ranks = Enumerable.Range(0, count + 1)
                            .Select(_ => 1)
                            .ToArray();
    }

    public int Find(int node)
    {
        int curNode = node;
        while(parents[curNode] != curNode)
        {
            curNode = parents[curNode];
        }
        parents[node] = curNode;
        return curNode;
    }

    public bool Union(int first, int second)
    {
        var firstParent = Find(first);
        var secondParent = Find(second);
        if(firstParent == secondParent)
        {
            return false;
        }

        if(ranks[secondParent] > ranks[firstParent])
        {
            parents[firstParent] = secondParent;
            ranks[secondParent] += ranks[firstParent];
        }
        else
        {
            parents[secondParent] = firstParent;
            ranks[firstParent] += ranks[secondParent];
        }
        return true;
    }
}
