using System;
using Graphs;

namespace NodeGraphTestbed_lists
{
    public class UI_Manager
    {
        public void WriteHeader()
        {
            Console.WriteLine("GraphsTestbed v1.0");
        }

        public void WriteMenu()
        {
            Console.WriteLine("Main menu\n---------");
            Console.WriteLine("1 - Add node");
            Console.WriteLine("2 - Add connection");
            Console.WriteLine("3 - List graph");
            Console.WriteLine("0 - Exit");
        }

        public void Run()
        {
            /*
            WriteHeader();

            String s = "";

            while (!s.Equals("0")) {

                WriteMenu();

                Console.Write("Choice: ");

                s = Console.ReadLine();
            }
            */

            //Graph creation - Pass
            Graph graph = new Graph("banana");

            Console.ReadKey();

            //Adding nodes - Pass
            graph.AddNode("glyfada");
            Console.ReadKey();
            graph.AddNode("faliro");
            Console.ReadKey();
            graph.AddNode("Pireus");


            //Add Connection - Pass
            graph.AddConnection("banana", "glyfada");
            Console.ReadKey();

            //Connection duplication - Pass
            graph.AddConnection("banana", "glyfada");
            Console.ReadKey();

            //Connection invalid - Pass
            graph.AddConnection("gata", "glyfada");
            Console.ReadKey();

            graph.AddConnection("Pireus", "glyfada");

            /*//Node deletion - Pass
            graph.RemoveNode("glyfada");
            Console.ReadKey();

            //Connection is removed - Pass
            graph.RemoveConnection("banana", "glyfada");
            Console.ReadKey();*/

            //Correct info dumping - Pass
            graph.Dump();
            Console.ReadKey();

            graph.Empty();

            graph.CreateSampleGraph();
            graph.Dump();

            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            new UI_Manager().Run();
        }
    }
}
