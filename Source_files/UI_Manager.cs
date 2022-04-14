using System;
using System.Collections.Generic;
using Graphs;
using Graphs.DFSTraverse;
using Graphs.BFSTraverse;

namespace NodeGraphTestbed_lists
{
    public class UI_Manager
    {
        public void Run()
        {
            Graph graph = new Graph("");

            graph.Empty();

            graph.CreateSampleGraph();
            graph.Dump();

            Console.WriteLine();
            Console.Write("BFS:\t");
            BFSTraverser.BFSTraverse(graph, "A");
            Console.WriteLine();
            Console.ReadKey();

            string from = "A";
            string to = "G";

            bool pathPossible = BFSTraverser.BFSConfirmPath(graph, from, to);

            Console.WriteLine($"{from} -> {to}: {pathPossible}");

            if (pathPossible)
            {

                List<string> pathfinding = BFSTraverser.BFSFindPath(graph, from, to);

                Console.WriteLine($"Pathfinding of {from} -> {to}");
                foreach (string step in pathfinding)
                {
                    Console.Write(step);
                    Console.Write(" ");
                }
            }

            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            new UI_Manager().Run();
        }
    }
}
