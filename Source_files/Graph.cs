using System;
using System.Collections.Generic;

namespace Graphs
{
    public class Graph
    {
        private struct Connection
        {
            public int from_index;
            public int to_index;

            public override string ToString()
            {
                return $"{from_index} conects to {to_index}";
            }
        }

        private List<string> nodes = new List<string>();

        private List<Connection> connections = new List<Connection>();

        public Graph(string node)
        {
            //We have to initialize the graph with at least ONE node.
            AddNode(node);
        }

        /// <summary>
        /// Call to add a new node in the list ONLY if it not already in the list.
        /// </summary>
        /// <param name="node">The new node's name.</param>
        public void AddNode(string node)
        {
            if (!IsNode(node))
            {
                nodes.Add(node);

                Console.WriteLine($"Node {node} created in the nodes list.");
            }
            else
            {
                Console.WriteLine($"Node {node} already exists in the nodes list.");
            }
        }

        public void RemoveNode(string node)
        {
            if (IsNode(node))
            {
                int index = nodes.IndexOf(node);

                _TryNodeDeletion(index);
            }
            else
            {
                Console.WriteLine($"{node} does not exist in the nodes list.");
            }
        }

        void _TryNodeDeletion(int nodeIndex)
        {
            string tempString = nodes[nodeIndex]; //Cache the node name to display it 

            try
            {
                nodes.RemoveAt(nodeIndex);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine($"Given index {nodeIndex} is out of range.");
                throw;
            }

            //Deletion successful
            Console.WriteLine($"Node \"{tempString}\" deleted.");
        }

        /// <summary>
        /// Call to create a new connection between from and to, ONLY if it does not already exist.
        /// </summary>
        public void AddConnection(string from, string to)
        {
            //Early exit if the connection already exists.
            if (IsConnected(from, to))
            {
                Console.WriteLine($"Connection from {from} to {to} already exists.");
                return;
            }

            int from_index = nodes.IndexOf(from);

            if (from_index == -1)
            {
                throw new IndexOutOfRangeException();
            }

            int to_index = nodes.IndexOf(to);

            if (to_index == -1)
            {
                throw new IndexOutOfRangeException();
            }

            //Create connection instance
            Connection newConnection = new Connection();

            newConnection.from_index = from_index;
            newConnection.to_index = to_index;

            connections.Add(newConnection);
        }

        public void RemoveConnection(string from, string to)
        {
            if (!IsNode(from))
            {
                Console.WriteLine($"{from} is not a node.");
                return;
            }

            if (!IsNode(to))
            {
                Console.WriteLine($"{to} is not a node.");
                return;
            }

            int fromIndex = nodes.IndexOf(from);
            int toIndex = nodes.IndexOf(to);

            for (int i = 0; i < ConnectionCount(); i++)
            {
                if (connections[i].from_index == fromIndex && connections[i].to_index == toIndex)
                {
                    connections.RemoveAt(i);
                    Console.WriteLine($"Connection {from} to {to} deleted.");
                    return;
                }
            }

            Console.WriteLine($"Connection {from} to {to} could not be found.");
        }

        /// <returns>True if the node exists inside the nodes list, false if not.</returns>
        public bool IsNode(string node)
        {
            return nodes.Contains(node);
        }

        /// <returns>True if the connection exists inside the connections list, false if not.</returns>
        public bool IsConnected(string from, string to)
        {
            if (!IsNode(from))
            {
                Console.WriteLine($"{from} is not a node.");
                return false;
            }

            if (!IsNode(to))
            {
                Console.WriteLine($"{to} is not a node.");
                return false;
            }

            int fromIndex = nodes.IndexOf(from);
            int toIndex = nodes.IndexOf(to);

            for (int i = 0; i < ConnectionCount(); i++)
            {
                if (_EvaluateConnection(connections[i], fromIndex, toIndex))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Call to check if the supplied connection ints match the from and to ints in both directions.
        /// </summary>
        /// <returns>True if the connection ints match the supplied ints, false otherwise.</returns>
        bool _EvaluateConnection(Connection connection, int from, int to)
        {
            if ((connection.from_index == from && connection.to_index == to)
                || (connection.from_index == to && connection.to_index == from))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <returns>The nodes List element count.</returns>
        public int NodeCount()
        {
            return nodes.Count;
        }

        /// <returns>The connections List element count.</returns>
        public int ConnectionCount()
        {
            return connections.Count;
        }

        /// <summary>
        /// Call to write all the nodes and node connections info to the console.
        /// </summary>
        public void Dump()
        {
            _PrintNodes();
            _PrintNodeConnections();
        }

        /// <summary>
        /// Prints the nodes list elements to the console.
        /// </summary>
        void _PrintNodes()
        {
            int nodeCount = NodeCount();

            Console.WriteLine($"Total nodes in the list: {nodeCount}");

            for (int i = 0; i < nodeCount; i++)
            {
                Console.WriteLine($"{i + 1}: {nodes[i]}");
            }
        }

        /// <summary>
        /// Prints the connections list elements to the console.
        /// </summary>
        void _PrintNodeConnections()
        {
            int nodeConnectionsCount = ConnectionCount();

            Console.WriteLine($"Total connections in the list: {nodeConnectionsCount}");

            for (int i = 0; i < nodeConnectionsCount; i++)
            {
                int fromIndex = 0, toIndex = 0;

                fromIndex = connections[i].from_index;
                toIndex = connections[i].to_index;

                Console.WriteLine($"{i + 1}: {nodes[fromIndex]} connects to {nodes[toIndex]}");
            }
        }
    }
}
