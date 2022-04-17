using System;
using System.Collections.Generic;

namespace GraphSearch.DFS
{
    public static class DFS_R
    {
        static List<string> closedSet = new List<string>();

        public static void DFSR_Traverse(Graph graph, string from)
        {
            ClearClosedSet(ref closedSet);

            _Traverse(graph, from);
        }

        static void _Traverse(Graph graph, string from)
        {
            Console.Write(from);
            Console.Write(" ");

            if (closedSet.Contains(from))
                return;

            closedSet.Add(from);

            List<string> neighbours = graph.GetNeighbours(from);

            foreach (string neighbour in neighbours)
            {
                _Traverse(graph, neighbour);
            }
        }

        public static bool DFSR_PathConfirmation(Graph graph, string from, string goalNode)
        {
            ClearClosedSet(ref closedSet);

            _PathConfirmation(graph, from, goalNode);

            if (closedSet.Contains(goalNode))
                return true;
            else
                return false;
        }

        static void _PathConfirmation(Graph graph, string from, string goalNode)
        {
            if (closedSet.Contains(goalNode))
                return;

            closedSet.Add(from);

            List<string> neighbours = graph.GetNeighbours(from);

            foreach (string neighbour in neighbours)
            {
                if (closedSet.Contains(neighbour))
                    continue;

                _PathConfirmation(graph, neighbour, goalNode);
            }
        }


        //UTILITIES
        static void ClearClosedSet(ref List<string> closedSet)
        {
            closedSet = new List<string>();
        }
    }
}
