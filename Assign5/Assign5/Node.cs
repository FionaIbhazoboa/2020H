using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign5
{
    class Node<T> where T : IComparable<T>
    {
        public T value;
        public Node<T> left;
        public Node<T> right;
        public Color colour;
        public Node<T> parent;
        public int balance = 0;
        private T v;

        public Node(T v)
        {
            this.v = v;
            //using a fixed array is more conveinient but wasteful as we need a little more loops to compare and reshuffle the keys and edges
            Keys = new List<T>();
            Keys.Add(v);
            Edges = new List<Node<T>>();
        }
        public Node(Color colour) { this.colour = colour; }
        public Node(T value, Color colour) { this.value = value; this.colour = colour; }
        public List<Node<T>> Edges { get; private set; }
        public List<T> Keys { get; private set; }
        public Node<T> Parent { get; set; }
        

        /// <summary>
        /// Finds a key's position if it exists
        /// </summary>
        /// <returns>Key position 0,1 or 2 if found, otherwise -1</returns>
        public int HasKey(T k)
        {
            for (int x = 0; x < Keys.Count; x++)
            {
                if (Keys[x].CompareTo(k) == 0)
                {
                    return x;
                }
            }

            return -1;
        }

        public void InsertEdge(Node<T> edge)
        {
            for (int x = 0; x < Edges.Count; x++)
            {
                if (Edges[x].Keys[0].CompareTo(edge.Keys[0]) > 0 )
                {
                    Edges.Insert(x, edge);
                    return;
                }
            }

            Edges.Add(edge);
            edge.Parent = this;
        }

        public bool RemoveEdge(Node<T> n)
        {
            return Edges.Remove(n);
        }

        public Node<T> RemoveEdge(int position)
        {
            Node<T> edge = null;
            if (Edges.Count > position)
            {
                edge = Edges[position];
                edge.Parent = null;
                Edges.RemoveAt(position);
            }

            return edge;
        }

        public Node<T> Traverse(T k)
        {
            int pos = FindEdgePosition(k);

            if (pos < Edges.Count && pos > -1)
            {
                return Edges[pos];
            }
            else
            {
                return null;
            }
        }
        public Node<T> GetEdge(int position)
        {
            if (position < Edges.Count)
            {
                return Edges[position];
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Find the position (edge) where k's value falls between 2 keys.
        /// </summary>
        /// <param name="k"></param>
        /// <returns>0,1,2 or 3, unless one of the keys equals k, returns -1</returns>
        public int FindEdgePosition(T k)
        {
            if (Keys.Count != 0)
            {
                T left = default(T);
                for (int x = 0; x < Keys.Count; x++)
                {
                    if (left.CompareTo(k) <= 0 && k.CompareTo(Keys[x]) < 0 )
                    {
                        return x;
                    }
                    else
                    {
                        left = Keys[x];
                    }
                }

                if (k.CompareTo(Keys[Keys.Count - 1]) > 0)
                {
                    return Keys.Count;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return 0;
            }
        }

        public void Fuse(Node<T> n1)
        {
            int totalKeys = n1.Keys.Count;
            int totalEdges = n1.Edges.Count;

            totalKeys += this.Keys.Count;
            totalEdges += this.Edges.Count;

            if (totalKeys > 3)
            {
                throw new InvalidOperationException("Total keys of all nodes exceeded 3");
            }


            if (totalEdges > 4)
            {
                throw new InvalidOperationException("Total edges of all nodes exceeded 4");
            }


            for (int x = 0; x < n1.Keys.Count; x++)
            {
                T k = n1.Keys[x];
                this.Push(k);
            }

            for (int x = Edges.Count - 1; x >= 0; x--)
            {
                Node<T> e = n1.RemoveEdge(x);
                this.InsertEdge(e);
            }
        }

        public void Fuse(Node<T> n1, Node<T> n2)
        {
            int totalKeys = n1.Keys.Count;
            int totalEdges = n1.Edges.Count;

            totalKeys += n2.Keys.Count;
            totalEdges += n2.Edges.Count;
            totalKeys += this.Keys.Count;
            totalEdges += this.Edges.Count;

            if (totalKeys > 3)
            {
                throw new InvalidOperationException("Total keys of all nodes exceeded 3");
            }

            if (totalEdges > 4)
            {
                throw new InvalidOperationException("Total edges of all nodes exceeded 4");
            }

            this.Fuse(n1);
            this.Fuse(n2);
        }

        /// <summary>
        /// Restructure the node spliting the left and right keys into 2 single nodes
        /// </summary>
        /// <returns>Restructured subtree by the order: left, right</returns>
        public Node<T>[] Split()
        {
            if (Keys.Count != 2)
            {
                throw new InvalidOperationException(string.Format("This node has {0} keys, can only split a 2 keys node", Keys.Count));
            }

            Node<T> newRight = new Node<T>(Keys[1]);

            for (int x = 2; x < Edges.Count; x++)
            {
                newRight.Edges.Add(this.Edges[x]);
            }

            for (int x = Edges.Count - 1; x >= 2; x--)
            {
                this.Edges.RemoveAt(x);
            }

            for (int x = 1; x < Keys.Count; x++)
            {
                Keys.RemoveAt(x);
            }

            return new Node<T>[] { this, newRight };
        }

        public Node<T> Pop(int position)
        {
            if (Keys.Count == 1)
            {
                throw new InvalidOperationException("Cannot pop value from a 1 key node");
            }

            if (position < Keys.Count)
            {
                T k = Keys[position];
                Keys.RemoveAt(position);

                //return k;
            }

            return null;
        }

        public void Push(T k)
        {
            if (Keys.Count == 3)
            {
                throw new InvalidOperationException("Cannot push value into a 3 keys node");
            }

            if (Keys.Count == 0)
            {
                Keys.Add(k);
            }
            else
            {
                T left = default(T);
                for (int x = 0; x < Keys.Count; x++)
                {
                    if (left.CompareTo(k) <= 0 && k.CompareTo(Keys[x]) < 0)
                    {
                        Keys.Insert(x, k);
                        return;
                    }
                    else
                    {
                        left = Keys[x];
                    }
                }
                Keys.Add(k);
            }
        }
        public override string ToString()
        {
            string comma = "";
            StringBuilder sb = new StringBuilder();
            for (int x = 0; x < Keys.Count; x++)
            {
                sb.Append(comma + Keys[x]);
                comma = ",";
            }

            return sb.ToString();
        }


    }
}
