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

        public Graph(string nodeName)
        {
            //We have to initialize the graph with at least ONE node.
            AddNode(nodeName);
        }

        /// <summary>
        /// Call to add a new node in the list ONLY if it not already in the list.
        /// </summary>
        /// <param name="nodeName">The new node's name.</param>
        public void AddNode(string nodeName)
        {
            PrintSeparators();

            if (!IsNode(nodeName))
            {
                nodes.Add(nodeName);

                Console.WriteLine($"Node {nodeName} created in the nodes list.");
            }
            else
            {
                Console.WriteLine($"Node {nodeName.ToUpper()} already exists in the nodes list.");
            }
        }

        #region Node_Deletion
        /// <summary>
        /// Call to delete a node from the nodes List with the supplied name.
        /// </summary>
        /// <param name="node">Name of the node to delete</param>
        public void RemoveNode(string node)
        {
            PrintSeparators();

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
                //_RemoveConnectionsWithNode(index);

                Console.WriteLine($"Node \"{node.ToUpper()}\" deleted.");
            }
            else
            {
                Console.WriteLine($"Node \"{node.ToUpper()}\" could not be deleted.");
            }
        }

        /// <summary>
        /// Call to remove all connections that connect OR are connected to the to-be-deleted node.
        /// </summary>
        /// <param name="index">Index of the to-be-deleted node.</param>
        /*void _RemoveConnectionsWithNode(int index)
        {
            for (int i = 0; i < GetConnectionsCount(); i++)
            {
                if (connections[i].from_index == index || connections[i].to_index == index)
                {
                    _TryRemoveAtIndex(connections, i);
                }
            }
        }*/

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
        #endregion

        #region Node_Connecting
        /// <summary>
        /// Call to create a new connection between from and to, ONLY if it does not already exist.
        /// </summary>
        public void AddConnection(string fromNode, string toNode)
        {
            PrintSeparators();

            //Early exit if the given strings do not match a node.
            if (!IsNode(fromNode) || !IsNode(toNode))
            {
                Console.WriteLine($"\tERROR: Invalid nodes passed for connection creation.\n\t{fromNode} + {toNode}");
                return;
            }
            //Early exit if the connection already exists.
            if (IsConnected(fromNode, toNode))
            {
                Console.WriteLine($"Connection from {fromNode.ToUpper()} to {toNode.ToUpper()} already exists.");
                return;
            }

            int from_index = nodes.IndexOf(fromNode);
            int to_index = nodes.IndexOf(toNode);

            //Create connection instance
            Connection newConnection = new Connection();

            newConnection.from_index = from_index;
            newConnection.to_index = to_index;

            connections.Add(newConnection);

            Console.WriteLine($"Created connection from {fromNode} to {toNode}");
        }

        /// <summary>
        /// Call to check if the given parameters ARE nodes and then 
        /// remove the connection that corresponds to them.
        /// </summary>
        public void RemoveConnection(string fromNode, string toNode)
        {
            PrintSeparators();

            //Early exit if one or both of the supplied strings is not a node
            if (!IsNode(fromNode) || !IsNode(toNode))
            { return; }

            //Grab the index of the nodes
            int fromIndex = nodes.IndexOf(fromNode);
            int toIndex = nodes.IndexOf(toNode);

            //Itterate through the connections List and...
            for (int i = 0; i < GetConnectionsCount(); i++)
            {
                //If we find the exact same connection...
                if (connections[i].from_index == fromIndex && connections[i].to_index == toIndex)
                {
                    //Remove it
                    connections.RemoveAt(i);
                    Console.WriteLine($"Connection {fromNode} to {toNode} deleted.");
                    return;
                }
            }

            //Writes this in the console if we did NOT find the supplied connection.
            Console.WriteLine($"Connection {fromNode} to {toNode} could not be found.");
        }
        #endregion

        #region Node_Validation
        /// <returns>True if the node exists inside the nodes list, false if not.</returns>
        public bool IsNode(string node)
        {
            return nodes.Contains(node);
        }

        /// <returns>True if the connection exists inside the connections list, false if not.</returns>
        public bool IsConnected(string fromNode, string toNode)
        {
            //EARLY EXIT if one of the supplied values is not a node
            if (!IsNode(fromNode) || !IsNode(toNode))
            {
                return false;
            }

            int fromIndex = nodes.IndexOf(fromNode);
            int toIndex = nodes.IndexOf(toNode);

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
        bool _EvaluateConnection(Connection connection, int fromIndex, int toIndex)
        {
            if ((connection.from_index == fromIndex && connection.to_index == toIndex))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Node_Counting
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
        #endregion

        #region Graph_InfoDumping
        /// <summary>
        /// Call to write all the nodes and node connections info to the console.
        /// </summary>
        public void Dump()
        {
            _PrintNodes(nodes);
            _PrintNodeConnections(connections);
        }

        /// <summary>
        /// Prints the nodes list elements to the console.
        /// </summary>
        void _PrintNodes(List<string> nodesList)
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
        void _PrintNodeConnections(List<Connection> connectionsList)
        {
            int nodeConnectionsCount = connectionsList.Count;

            Console.WriteLine($"Total connections in the list: {nodeConnectionsCount}");

            for (int i = 0; i < nodeConnectionsCount; i++)
            {
                int fromIndex = 0, toIndex = 0;

                fromIndex = connections[i].from_index;
                toIndex = connections[i].to_index;

                //Check if the index is out of list range due to node deletion
                if (!_TryIsNodeWithIndex(fromIndex) || !_TryIsNodeWithIndex(toIndex))
                { continue; }

                Console.WriteLine($"{i + 1}: {nodes[fromIndex]} connects to {nodes[toIndex]}");
            }
        }

        bool _TryIsNodeWithIndex(int index)
        {
            try
            {
                IsNode(nodes[index]);
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
                throw;
            }

            return true;
        }
        #endregion

        #region Utilities
        void PrintSeparators()
        {
            for (int i = 0; i < 50; i++)
            {
                Console.Write("-");
            }

            Console.WriteLine("");
        }

        /// <summary>
        /// Call to empty both the nodes and connections Lists
        /// </summary>
        public void Empty()
        {
            //string tempStr = nodes[0];

            nodes = new List<string>();
            connections = new List<Connection>();

            //nodes.Add(tempStr);
        }

        /// <summary>
        /// Call to get all the child nodes of the passed node parameter
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public List<string> GetNeighbours(string node)
        {
            int from_index = nodes.IndexOf(node);

            if (from_index == -1)
            {
                // TODO: throw error, exit...
                return null;
            }

            List<string> neighbours = new List<string>();

            foreach (Connection connection in connections)
            {
                if (connection.from_index == from_index)
                {
                    int to_index = connection.to_index;
                    string neighbour = nodes[to_index];
                    neighbours.Add(neighbour);
                }
            }

            return neighbours;
        }
        #endregion

        public void CreateSampleGraph()
        {
            //Clear the whole graph lists first
            Empty();

            //Create the nodes
            AddNode("A");
            AddNode("B");
            AddNode("C");
            AddNode("D");
            AddNode("E");
            AddNode("F");
            AddNode("G");

            //Create the connections
            AddConnection("A", "B");
            AddConnection("B", "C");
            AddConnection("C", "F");
            AddConnection("F", "G");
            AddConnection("F", "E");
            AddConnection("E", "D");
            AddConnection("D", "G");
            AddConnection("A", "G");
            AddConnection("B", "E");

            //Cycle connection...
            AddConnection("D", "A");
        }
    }
}
