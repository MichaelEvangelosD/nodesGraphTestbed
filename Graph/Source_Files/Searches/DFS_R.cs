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
        Stack<Step> openSet = new Stack<Step>();
        List<string> path = new List<string>();

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

        public List<string> _DFSRPathfind(Graph graph, string from, string to)
        {
            ClearClosedSet(ref closedSet);

            if (!graph.IsNode(from))
            {
                return null;
            }

            if (from.Equals(to))
            {
                path.Add(from);
                return path;
            }

            //Create the first step of the path
            Step firstStep = new Step();
            firstStep.nodeName = from;
            firstStep.previousStep = null;
            openSet.Push(firstStep);

            return _Pathfind(to);
        }

        //TODO: FINISH
        List<string> _Pathfind(string to)
        {
            Step currentStep = openSet.Pop();

            string currentNode = currentStep.nodeName;

            if (closedSet.Contains(currentNode))
            { return null; }

            closedSet.Add(currentNode);

            /*if (currentNode.Equals(to))
            {
                //Get the current step...
                Step pathStep = currentStep;

                //...and while we have not hit a null pathStep
                //continue adding each previous step to the path List
                while (pathStep != null)
                {
                    path.Add(pathStep.nodeName); //Add the node name to the path list
                    pathStep = pathStep.previousStep; //Set the past step to the previous step
                }

                //Return the now filled path list
                return path;
            }*/
        }

        //UTILITIES
        static void ClearClosedSet(ref List<string> closedSet)
        {
            closedSet = new List<string>();
        }
    }
}
