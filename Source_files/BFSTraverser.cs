using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.BFSTraverse
{
    class BFSTraverser
    {
        public static void BFSTraverse_NonRecursive(Graph graph, string startingNode)
        {
            Queue<string> openset = new Queue<string>(); //FIFO
            Stack<> //CONTINUE HERE

            openset.Enqueue(startingNode); //insert the first node indo the openSet

            while (openset.Count != 0)
            {
                //remove the currently traversed node
                string currentNode = openset.Dequeue();

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
    }
}
