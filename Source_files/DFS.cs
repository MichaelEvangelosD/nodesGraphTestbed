using System;
using System.Collections.Generic;

namespace GraphSearch.DFS
{
    static class DFS
    {
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

        public static void DFSTraverse_NR_Queue(Graph graph, string startingNode)
        {
            Queue<string> openset = new Queue<string>();

            openset.Enqueue(startingNode); //insert the first node indo the openSet

            while (openset.Count != 0)
            {
                //remove the currently visited node...
                string currentNode = openset.Dequeue();

                //...and then print the visited node
                Console.Write(currentNode);
                Console.Write(" ");

                //get the children nodes of the currently traversed node
                List<string> childNodes = graph.GetNeighbours(currentNode);

                foreach (string child in childNodes)
                {
                    openset.Enqueue(child);
                }
            }
        }

        //- Basically a modified version of BFS -
        //If you change the Queue<> to a Stack<>
        //then the BFS behaves like a DFS.
        public static void DFSTraverse_NR_Stack(Graph graph, string startingNode)
        {
            Stack<string> openset = new Stack<string>();

            openset.Push(startingNode); //insert the first node indo the openSet

            while (openset.Count != 0)
            {
                //remove the currently visited node...
                string currentNode = openset.Pop();

                //...and then print the visited node
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
