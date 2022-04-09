using System;
using System.Collections.Generic;

//TODO: When we delete a node, all connections with THIS node should get deleted too to not get miss-matched connection Dumping()

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

        /// <summary>
        /// Call to delete a node from the nodes List with the supplied name.
        /// </summary>
        /// <param name="node">Name of the node to delete</param>
        public void RemoveNode(string node)
        {
            if (!IsNode(node))
            {
                Console.WriteLine($"{node} does not exist in the nodes list.");
                return;
            }

            //Grab the nodes index inside the list 
            int index = nodes.IndexOf(node);

            //Try removing the element at index...
            if (_TryRemoveAtIndex(nodes, index))
            {
                //Remove all connections between and towards this node.
                _RemoveConnectionsWithNode(index);

                Console.WriteLine($"Node \"{node}\" deleted.");
            }
            else
            {
                Console.WriteLine($"Node \"{node}\" could not be deleted.");
            }
        }

        /// <summary>
        /// Call to remove all connections that connect OR are connected to the to-be-deleted node.
        /// </summary>
        /// <param name="index">Index of the to-be-deleted node.</param>
        void _RemoveConnectionsWithNode(int index)
        {
            for (int i = 0; i < GetConnectionsCount(); i++)
            {
                if (connections[i].from_index == index || connections[i].to_index == index)
                {
                    _TryRemoveAtIndex(connections, i);
                }
            }
        }

        /// <summary>
        /// Call to Try and remove the node at index "index".
        /// <para>Prints a node deletion failure if the index is out of the given List bounds.</para>
        /// </summary>
        bool _TryRemoveAtIndex(List<string> list, int index)
        {
            try
            {
                list.RemoveAt(index);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine($"Given node index {index} is out of range.");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Call to Try and remove the element at index "index".
        /// <para>Prints a node deletion failure if the index is out of the given List bounds.</para>
        /// </summary>
        bool _TryRemoveAtIndex(List<Connection> list, int index)
        {
            try
            {
                list.RemoveAt(index);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine($"Given node index {index} is out of range.");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Call to create a new connection between from and to, ONLY if it does not already exist.
        /// </summary>
        public void AddConnection(string from, string to)
        {
            //Early exit if the given strings do not match a node.
            if (!IsNode(from) || !IsNode(to)) return;

            //Early exit if the connection already exists.
            if (IsConnected(from, to))
            {
                Console.WriteLine($"Connection from {from} to {to} already exists.");
                return;
            }

            int from_index = nodes.IndexOf(from);
            int to_index = nodes.IndexOf(to);

            //Create connection instance
            Connection newConnection = new Connection();

            newConnection.from_index = from_index;
            newConnection.to_index = to_index;

            connections.Add(newConnection);
        }

        public void RemoveConnection(string from, string to)
        {
            //Early exit if one or both of the supplied strings is not a node
            if (!IsNode(from) || !IsNode(to))
            { return; }

            //Grab the index of the nodes
            int fromIndex = nodes.IndexOf(from);
            int toIndex = nodes.IndexOf(to);

            //Itterate through the connections List and...
            for (int i = 0; i < GetConnectionsCount(); i++)
            {
                //If we find the exact same connection...
                if (connections[i].from_index == fromIndex && connections[i].to_index == toIndex)
                {
                    //Remove it
                    connections.RemoveAt(i);
                    Console.WriteLine($"Connection {from} to {to} deleted.");
                    return;
                }
            }

            //Writes this in the console if we did NOT find the supplied connection.
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
            //EARLY EXIT if one of the supplied values is not a node
            if (!IsNode(from) || !IsNode(to))
            {
                return false;
            }

            int fromIndex = nodes.IndexOf(from);
            int toIndex = nodes.IndexOf(to);

            for (int i = 0; i < GetConnectionsCount(); i++)
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
        public int GetNodeCount()
        {
            return nodes.Count;
        }

        /// <returns>The connections List element count.</returns>
        public int GetConnectionsCount()
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
            int nodeCount = GetNodeCount();

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
            int nodeConnectionsCount = GetConnectionsCount();

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
