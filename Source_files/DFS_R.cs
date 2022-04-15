using System;
using System.Collections.Generic;

namespace GraphSearch.DFS
{
    public static class DFS_R
    {
        //TODO: Path-confirmation/finding
        public static void DFSTraverse_R(Graph graph, string startingNode)
        {
            // step 1: visit the node...
            Console.Write(startingNode);
            Console.Write(" ");

            // step 2: find all neighbours of node...
            List<string> neighbours = graph.GetNeighbours(startingNode);

            // step 3: DFS traverse each one of the neighbours...
            foreach (string neighbour in neighbours)
            {
                DFSTraverse_R(graph, neighbour);
            }
        }

    }
}
