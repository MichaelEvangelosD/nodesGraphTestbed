using System;
using Graphs;

namespace NodeGraphTestbed_lists
{
    public class Program
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

            Graph graph = new Graph("banana");
            graph.Dump();

            Console.ReadKey();
        }

        static void Main(string[] args)
        {

            new Program().Run();
        }
    }
}
