using System;
using System.Collections.Generic;

namespace TestProject.ClassesUnderTest
{
    public class Node<T> where T : IComparable<T>
    {
        public T Data { get; set; }
        public Node<T> Parent { get; set; }
        public int Rank { get; set; }

        public Node(T data)
        {
            Data = data;
            Parent = this;
            Rank = 0;
        }
    }

    public class DisjointSet<T> where T : IComparable<T>
    {
        private readonly Dictionary<T, Node<T>> _nodes = new Dictionary<T, Node<T>>();

        public bool ContainsData(T data)
        {
            return _nodes.ContainsKey(data);
        }

        public bool MakeSet(T data)
        {
            if (ContainsData(data))
            {
                return false;
            }

            _nodes.Add(data, new Node<T>(data));
            return true;
        }

        public T FindSet(T data)
        {
            return FindSet(_nodes[data]).Data;
        }

        public void Union(T dataX, T dataY)
        {
            Node<T> nodeX = _nodes[dataX];
            Node<T> nodeY = _nodes[dataY];

            Link(FindSet(nodeX), FindSet(nodeY));
        }

        private void Link(Node<T> nodeX, Node<T> nodeY)
        {
            if (nodeX.Rank > nodeY.Rank)
            {
                nodeY.Parent = nodeX;
            }
            else
            {
                nodeX.Parent = nodeY;
                if (nodeX.Rank == nodeY.Rank)
                {
                    nodeY.Rank++;
                }
            }
        }

        private Node<T> FindSet(Node<T> node)
        {
            if (node != node.Parent)
            {
                node.Parent = FindSet(node.Parent);
            }
            return node.Parent;
        }
    }
}
