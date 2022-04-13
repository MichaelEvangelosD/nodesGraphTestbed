using System;
using System.Collections.Generic;

namespace Graphs.DFSTraverse
{
    static class DFSTraverser
    {
        public static void DFSTraverse_Recursive(Graph graph, string startingNode)
        {
            // step 1: visit the node...
            Console.Write(startingNode);
            Console.Write(" ");

            // step 2: find all neighbours of node...
            List<string> neighbours = graph.GetNeighbours(startingNode);

            // step 3: DFS traverse each one of the neighbours...
            foreach (string neighbour in neighbours)
            {
                DFSTraverse_Recursive(graph,neighbour);
            }
        }

        public static void DFSTraverse_NonRecursive(Graph graph, string startingNode)
        {
            Stack<string> openset = new Stack<string>(); //LIFO

            openset.Push(startingNode); //insert the first node indo the openSet

            while (openset.Count != 0)
            {
                //remove the currently traversed node
                string currentNode = openset.Pop();

                Console.Write(currentNode);
                Console.Write(" ");  

                //get the children nodes of the currently traversed node
                List<string> childNodes = graph.GetNeighbours(currentNode);

                foreach (string child in childNodes)
                {
                    openset.Push(child);
                }
            }
        }
    }
}
