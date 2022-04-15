using System;
using System.Collections.Generic;

namespace GraphSearch.BFS
{
    class BFS
    {
        /// <summary>
        /// Call to visit and print all the nodes contained inside the passed graph.
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="startingNode"></param>
        public static void BFSTraverse(Graph graph, string startingNode)
        {
            //Fast return if the node doesn't exists in the node graph.
            if (!graph.IsNode(startingNode))
            {
                Console.WriteLine($"Node: {startingNode} not present in node graph.");
                return;
            }

            //Create the necessary collections
            Queue<string> openSet = new Queue<string>();
            List<string> closedSet = new List<string>(); //Keeps track of the visited nodes so we don't visit them again

            openSet.Enqueue(startingNode); //insert the first node into the openSet

            while (openSet.Count != 0)
            {
                //remove the currently traversed node
                string currentNode = openSet.Dequeue();

                //Checks if we've already visited this node and bypasses it...
                if (closedSet.Contains(currentNode))
                { continue; }

                //Add the curently visited node to the visited list
                //so we don't end up doing cycles
                closedSet.Add(currentNode);

                //Print the visited node
                Console.Write(currentNode);
                Console.Write(" ");

                //get the children nodes of the currently traversed node
                List<string> childNodes = graph.GetNeighbours(currentNode);

                foreach (string child in childNodes)
                {
                    //Populate the collection with the next child nodes to search
                    openSet.Enqueue(child);
                }
            }
        }

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

        /// <summary>
        /// Call to get a possible path starting from the startingNode towards the toNode.
        /// </summary>
        /// <returns>A List containing the names of the nodes before the toNode (IF FOUND).
        /// <para>Returns a List of count 1 if the startingNode is the toNode.</para>
        /// <para>Returns null if the startingNode does not exist inside the passed graph.</para>
        /// <para>Returns an empty list if the goal node was not found.</para></returns>
        public static List<string> BFSPathfind(Graph graph, string startingNode, string toNode)
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
            Queue<Step> openSet = new Queue<Step>();
            List<string> closedSet = new List<string>();

            /*
             * We begin with a step that points towards nothing behind it,
             * thus is the first step on the Search Tree.
             */
            Step startingStep = new Step();
            startingStep.nodeName = startingNode;
            startingStep.previousStep = null; //null is used to check if we are in the last node...

            openSet.Enqueue(startingStep);

            while (openSet.Count != 0)
            {
                Step currentStep = openSet.Dequeue();

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

                    openSet.Enqueue(nextStep); //Then add it to the openset
                }
            }

            //Return the (may) empty path list
            return path;
        }
    }
}
