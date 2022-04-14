using System;
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
            Console.ReadKey();

            bool pathPossible = BFSTraverser.BFSConfirmPath(graph, "A", "D");

            if(pathPossible)
            {
                BFSTraverser.BFSFindPath();
            }
        }

        static void Main(string[] args)
        {
            new UI_Manager().Run();
        }
    }
}
