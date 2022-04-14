using System;
using System.Collections.Generic;

namespace Graphs.BFSTraverse
{
    class BFSTraverser
    {
        public static void BFSTraverse(Graph graph, string startingNode)
        {
            //Fast return if the node doesn't exists in the node graph.
            if (!graph.IsNode(startingNode))
            {
                Console.WriteLine($"Node: {startingNode} not present in node graph.");
                return;
            }

            //Create the necessary collections
            Queue<string> openset = new Queue<string>();
            List<string> visited = new List<string>(); //Keeps track of the visited nodes so we don't visit them again

            openset.Enqueue(startingNode); //insert the first node into the openSet

            while (openset.Count != 0)
            {
                //remove the currently traversed node
                string currentNode = openset.Dequeue();

                //Checks if we've already visited this node and bypasses it...
                if (visited.Contains(currentNode))
                {
                    continue;
                }

                //Add the curently visited node to the visited list
                //so we don't end up doing cycles
                visited.Add(currentNode);

                Console.Write(currentNode);
                Console.Write(" ");

                //get the children nodes of the currently traversed node
                List<string> childNodes = graph.GetNeighbours(currentNode);

                foreach (string child in childNodes)
                {
                    //Populate the collection with the next child nodes to search
                    openset.Enqueue(child);
                }
            }
        }

        /*public static void BFS(Graph graph, string startingNode, string goalNode)
        {
            //Fast return if the starting node does not exist in the node graph
            if (!graph.IsNode(startingNode))
            {
                Console.WriteLine($"Node: {startingNode} not present in node graph.");
                return;
            }

            //Fast return if the starting node is the goal node
            if (startingNode.Equals(goalNode))
                return;

            Queue<string> openset = new Queue<string>();
            List<string> visited = new List<string>();

            openset.Enqueue(startingNode);

            while (openset.Count != 0)
            {
                string currentNode = openset.Dequeue();

                Console.Write(currentNode);
                Console.Write(" ");

                List<string> childNodes = graph.GetNeighbours(currentNode);

                foreach (string child in childNodes)
                {
                    if (child.Equals(goalNode))
                    {
                        Console.WriteLine($"\nNode {goalNode} found!");
                        return;
                    }

                    if (!visited.Contains(child))
                    {
                        visited.Add(child);
                        openset.Enqueue(child);
                    }
                }
            }

            Console.WriteLine("\nNode was not found");
        }*/

        /// <summary>
        /// Call to check if THERE IS an available path from startingNode towards the goalNode
        /// </summary>
        public static bool BFSConfirmPath(Graph graph, string startingNode, string goalNode)
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

            Queue<string> openSet = new Queue<string>();
            List<string> closedSet = new List<string>();

            openSet.Enqueue(startingNode);

            while (openSet.Count != 0)
            {
                string currentNode = openSet.Dequeue();

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
                        openSet.Enqueue(child);
                    }
                }
            }

            return false;
        }

        public static List<string> BFSFindPath(Graph graph, string startingNode, string toNode)
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

            Queue<Step> openSet = new Queue<Step>();
            List<string> closedSet = new List<string>();

            /*
             * We begin with a step that points towards nothing behind it,
             * thus is the first step on the Search Tree
             */
            Step startingStep = new Step();
            startingStep.nodeName = startingNode;
            startingStep.previousStep = null;

            openSet.Enqueue(startingStep);

            while (openSet.Count != 0)
            {
                Step currentStep = openSet.Dequeue();

                string currentNode = currentStep.nodeName;

                if (closedSet.Contains(currentNode))
                { continue; }

                //Add the current node to the visited list so we don't have cycles
                closedSet.Add(currentNode);

                //We found the goal node - Backtrack to the tree root
                if (currentNode.Equals(toNode))
                {
                    Step pathStep = currentStep;

                    while (pathStep != null)
                    {
                        path.Add(pathStep.nodeName); //Add the node name to the path list
                        pathStep = pathStep.previousStep; //Set the past step to the previous step
                    }

                    //Return the now filled path list
                    return path;
                }

                //Continue to the next node
                List<string> childNodes = graph.GetNeighbours(currentNode);

                //For each child node...
                foreach (string childNode in childNodes)
                {
                    Step nextStep = new Step(); //Create a new step...
                    nextStep.nodeName = childNode; //With the name of the child node...
                    nextStep.previousStep = currentStep; //And set it's previous step to the current step...

                    openSet.Enqueue(nextStep); //Then add it to the openset
                }
            }

            //Return the (may) empty path list
            return path;
        }
    }
}
