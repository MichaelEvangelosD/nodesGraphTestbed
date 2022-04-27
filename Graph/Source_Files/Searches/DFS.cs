using System;
using System.Collections.Generic;

namespace Graphs
{
    sealed class DFS
    {
        public DFS()
        {

        }

        public void _DFSTraverse(Graph graph, string startingNode)
        {
            //Fast return if the node doesn't exists in the node graph.
            if (!graph.IsNode(startingNode))
            {
                Console.WriteLine($"Node: {startingNode} not present in node graph.");
                return;
            }

            Stack<string> openSet = new Stack<string>();
            List<string> closedSet = new List<string>();

            openSet.Push(startingNode); //insert the first node into the openSet

            while (openSet.Count != 0)
            {
                //remove the currently visited node...
                string currentNode = openSet.Pop();

                //...and then print the visited node
                Console.Write(currentNode);
                Console.Write(" ");

                //Checks if we've already visited this node and bypasses it.
                if (closedSet.Contains(currentNode))
                { continue; }

                closedSet.Add(currentNode);

                //get the children nodes of the currently traversed node
                List<string> childNodes = graph.GetNeighbours(currentNode);

                foreach (string child in childNodes)
                {
                    openSet.Push(child);
                }
            }
        }

        public bool _DFSConfirmPath(Graph graph, string startingNode, string goalNode)
        {
            //Fast return if the starting node does not exist in the node graph
            if (!graph.IsNode(startingNode))
            {
                return false;
            }

            //Fast return if the starting node is the goal node
            if (startingNode.Equals(goalNode))
            {
                return false;
            }

            Stack<string> openSet = new Stack<string>();
            List<string> closedSet = new List<string>();

            openSet.Push(startingNode);

            while (openSet.Count != 0)
            {
                string currentNode = openSet.Pop();

                List<string> childNodes = graph.GetNeighbours(currentNode);

                foreach (string child in childNodes)
                {
                    if (child.Equals(goalNode))
                    {
                        return true;
                    }

                    if (!closedSet.Contains(child))
                    {
                        closedSet.Add(child);
                        openSet.Push(child);
                    }
                }
            }

            return false;
        }

        public List<string> _DFSPathfind(Graph graph, string startingNode, string toNode)
        {
            //Fast return if the starting node does not exist in the node graph
            if (!graph.IsNode(startingNode))
            {
                return null;
            }

            List<string> path = new List<string>();

            //Fast return if the starting node is the goal node
            if (startingNode.Equals(toNode))
            {
                path.Add(startingNode);
                return path;
            }

            //Create the necessary collections
            Stack<Step> openSet = new Stack<Step>();
            List<string> closedSet = new List<string>();

            /*
             * We begin with a step that points towards nothing behind it,
             * thus is the first step on the Search Tree.
             */
            Step startingStep = new Step();
            startingStep.nodeName = startingNode;
            startingStep.previousStep = null; //null is used to check if we are in the last node...

            openSet.Push(startingStep);

            while (openSet.Count != 0)
            {
                Step currentStep = openSet.Pop();

                string currentNode = currentStep.nodeName;

                //If we've already passed this node, this time bypass it
                if (closedSet.Contains(currentNode))
                { continue; }

                //Add the current node to the visited list so we don't have cycles
                closedSet.Add(currentNode);

                //We found the goal node - Backtrack to the tree root
                if (currentNode.Equals(toNode))
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
                }

                //Continue to the next node
                //(If we are here this means we are still searching for the goal Node)
                List<string> neighbours = graph.GetNeighbours(currentNode);

                //For each child node of THIS node's neighbours...
                foreach (string childNode in neighbours)
                {
                    Step nextStep = new Step(); //Create a new step...
                    nextStep.nodeName = childNode; //With the name of the child node...
                    nextStep.previousStep = currentStep; //And set it's PREVIOUS step to the CURRENT step...

                    openSet.Push(nextStep); //Then add it to the openset
                }
            }

            //Return the (may) empty path list
            return path;
        }
    }
}
