using System;
using System.Collections.Generic;

namespace Graphs.DFSTraverse
{
    static class DFSTraverser
    {
        public static void DFSTraverse(Graph graph, string node)
        {
            // step 1: visit the node...
            Console.WriteLine(node);

            // step 2: find all neighbours of node...
            List<string> neighbours = graph.GetNeighbours(node);

            // step 3: DFS traverse each one of the neighbours...
            foreach (string neighbour in neighbours)
            {
                DFSTraverse(graph,neighbour);
            }
        }
    }
}
