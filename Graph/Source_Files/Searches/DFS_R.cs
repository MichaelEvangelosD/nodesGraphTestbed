using System;
using System.Collections.Generic;

namespace Graphs
{
    sealed class DFS_R
    {
        public DFS_R()
        {

        }

        List<string> closedSet = new List<string>();

        public void _DFSR_Traverse(Graph graph, string from)
        {
            ClearClosedSet(ref closedSet);

            _Traverse(graph, from);
        }

        void _Traverse(Graph graph, string from)
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

        public bool _DFSR_PathConfirmation(Graph graph, string from, string goalNode)
        {
            ClearClosedSet(ref closedSet);

            _PathConfirmation(graph, from, goalNode);

            if (closedSet.Contains(goalNode))
                return true;
            else
                return false;
        }

        void _PathConfirmation(Graph graph, string from, string goalNode)
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
