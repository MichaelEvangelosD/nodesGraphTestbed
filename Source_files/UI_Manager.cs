using System;
using System.Collections.Generic;
using GraphSearch;
using GraphSearch.DFS;
using GraphSearch.BFS;

namespace NodeGraphTestbed
{
    public class UI_Manager
    {
        static void Main(string[] args)
        {
            new UI_Manager().Run();
        }

        public void Run()
        {
            //Initialize the graph
            Graph graph = new Graph("");
            string from = "A";
            string to = "G";

            //Populate the graph
            graph.CreateSampleGraph();
            graph.Dump();
            Console.ReadKey();

            #region BFS_TESTS
            Console.WriteLine("Start of BFS Tests");
            //Test 1
            Test_BFSTraverse(graph, from);

            //Test 2

            Test_BFSConfirmPath(graph, from, to);

            //Test 3
            Test_BFSPathfind(graph, from, to);

            Console.WriteLine("End of BFS Tests!");
            Console.ReadKey();
            #endregion

            Console.WriteLine();

            #region DFS_TESTS
            Console.WriteLine("Start of DFS Tests");

            //Test 1
            Test_DFSTraverse_NR(graph, from);

            //Test 2
            Test_DFSConfirmPath(graph, from, to);

            //Test 3
            Test_DFSPathfind(graph, from, to);

            Console.WriteLine("End of DFS Tests!");
            Console.ReadKey();
            #endregion

            Console.WriteLine();

            #region DFSR_TESTS

            Console.WriteLine("Start of DFSR Tests.");

            //Test 1
            Test_DFSRTraverse(graph, from);

            //Test 2
            Test_DFSRConfirmPath(graph, from, to);

            //todo: Test 3 - Pathfind
            #endregion
        }

        #region BFS_TEST_METHODS
        void Test_BFSTraverse(Graph graph, string startNode)
        {
            Console.WriteLine();
            Console.Write("BFS Traverse:\t");
            BFS.BFSTraverse(graph, startNode);
            Console.WriteLine();
            Console.ReadKey();
        }

        void Test_BFSConfirmPath(Graph graph, string from, string to)
        {
            bool pathPossible = BFS.BFSConfirmPath(graph, from, to);

            Console.WriteLine($"Path Available {from} -> {to}: {pathPossible}");
            Console.ReadKey();
        }

        void Test_BFSPathfind(Graph graph, string from, string to)
        {
            List<string> pathfinding = BFS.BFSPathfind(graph, from, to);

            Console.WriteLine($"Pathfinding of {from} -> {to} " +
                $"(Should be printed reversed)");
            if (pathfinding.Count > 0)
            {
                foreach (string step in pathfinding)
                {
                    Console.Write(step);
                    Console.Write(" ");
                }
            }
            else
            {
                Console.WriteLine($"A path towards {to} does not exist");
            }

            Console.WriteLine();
            Console.ReadKey();
        }
        #endregion

        #region DFS_TEST_METHODS
        void Test_DFSTraverse_NR(Graph graph, string from)
        {
            Console.WriteLine();
            Console.Write("DFS Traverse:\t");
            DFS.DFSTraverse(graph, from);
            Console.WriteLine();
            Console.ReadKey();
        }

        void Test_DFSConfirmPath(Graph graph, string from, string to)
        {
            bool pathPossible = DFS.DFSConfirmPath(graph, from, to);

            Console.WriteLine($"Path Available {from} -> {to}: {pathPossible}");
            Console.ReadKey();
        }

        void Test_DFSPathfind(Graph graph, string from, string to)
        {
            List<string> pathfinding = DFS.DFSPathfind(graph, from, to);

            Console.WriteLine($"Pathfinding of {from} -> {to} " +
                $"(Should be printed reversed)");
            if (pathfinding.Count > 0)
            {
                foreach (string step in pathfinding)
                {
                    Console.Write(step);
                    Console.Write(" ");
                }
            }
            else
            {
                Console.WriteLine($"A path towards {to} does not exist");
            }

            Console.WriteLine();
            Console.ReadKey();
        }
        #endregion

        #region DFSR_TEST_METHODS
        void Test_DFSRTraverse(Graph graph, string startNode)
        {
            Console.WriteLine();
            Console.Write("DFSR Traverse:\t");
            DFS_R.DFSR_Traverse(graph, startNode);
            Console.WriteLine();
            Console.ReadKey();
        }

        void Test_DFSRConfirmPath(Graph graph, string from, string to)
        {
            bool pathPossible = DFS_R.DFSR_PathConfirmation(graph, from, to);

            Console.WriteLine($"Path Available {from} -> {to}: {pathPossible}");
            Console.ReadKey();
        }
        #endregion
    }
}
