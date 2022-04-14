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
                        return false;
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

        public class  Step
        {
            public string nodeName;
            public Step previousStep;
        }

        public static List<string> BFSFindPath(Graph graph, string startingNode,string toNode )
        {
            //Fast return if the starting node does not exist in the node graph
            if (!graph.IsNode(startingNode))
            {
                return null;
            }

            //Fast return if the starting node is the goal node
            if (startingNode.Equals(toNode))
            {
                return null;
            }

            List<string> path = new List<string>();
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

                if(!closedSet.Contains(currentNode))
                {
                    //CONTINUE HERE
                }
            }

            return path;
        }
    }
}
