using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign5
{
    //class 
        class My2_3_4Tree<T> where T : IComparable<T>
        {
            public Node<T> root = null;
            public void insert(T value)
            {
                if (root == null)
                {
                    root = new Node<T>(value);
                    return;
                }

                Node<T> curr = root;
                Node<T> parent = null;

                while (curr != null)
                {
                    //If we encounter a Node<T> with 3 keys, restructure the Node<T>, pushing the middle key upwards, 
                    if (curr.Keys.Count == 3)
                    {
                        if (parent == null)//the only time when the parent is null is when we are at the root Node<T>
                        {
                            T k = curr.Pop(1).value;
                            Node<T> newroot = new Node<T>(k);
                            Node<T>[] newNodes = curr.Split();
                            newroot.InsertEdge(newNodes[0]);
                            newroot.InsertEdge(newNodes[1]);
                            root = newroot;//make the new subtree's root Node the entire tree's root Node
                                           //curr now points to the left Node

                            curr = newroot;
                        }
                        else
                        {
                            Node<T> k = curr.Pop(1);//pop middle key and push it up

                            if (k != null)
                            {
                                parent.Push(k.value);//push the value up to the parent
                            }

                            Node<T>[] newNodes = curr.Split();

                            //int pos0=parent.FindEdgePosition(newNode<T>s[0].Keys[0].Value);
                            //parent.SetEdge(pos0, newNode<T>s[0]);

                            int pos1 = parent.FindEdgePosition(newNodes[1].Keys[0]);
                            parent.InsertEdge(newNodes[1]);

                            int posCurr = parent.FindEdgePosition(value);
                            curr = parent.GetEdge(posCurr);
                        }
                    }

                    parent = curr;
                    curr = curr.Traverse(value);
                    if (curr == null)//leave Node<T>
                    {
                        parent.Push(value);
                    }
                }
            }

            public Node<T> Find(T k)
            {
                Node<T> curr = root;

                while (curr != null)
                {
                    if (curr.HasKey(k) >= 0)
                    {
                        return curr;
                    }
                    else
                    {
                        int p = curr.FindEdgePosition(k);
                        curr = curr.GetEdge(p);
                    }
                }

                return null;
            }

            public void Remove(T k)
            {
                //1 if in the leaf Node<T>, simply remove it.
                //2 as we encounter 1 key Node<T>s,
                // a) pull the key from the siblings if they have 2 or more keys, via rotation
                // b) if both siblings have only 1 key, the parent (except if it is root) will always have 2 or more keys, 
                //    so pull a key from parent and fuse with it's sibling.
                // c) if siblings have only 1 key and parent is a 1 key root Node<T>, fuse all 3 Node<T>s into 1

                Node<T> curr = root;
                Node<T> parent = null;
                while (curr != null)
                {
                    //check for 1 key Node<T>s
                    if (curr.Keys.Count == 1)
                    {
                        if (curr != root)//skip root Node<T>
                        {
                            T cK = curr.Keys[0];
                            int edgePos = parent.FindEdgePosition(cK);

                            bool? takeRight = null;
                            Node<T> sibling = null;

                            if (edgePos > -1)//edge is found
                            {
                                if (edgePos < 3)//use right sibling if it is not the right most node
                                {
                                    sibling = parent.GetEdge(edgePos + 1);
                                    if (sibling.Keys.Count > 1)
                                    {
                                        takeRight = true;
                                    }
                                }

                                if (takeRight == null)//if this is the right most node, or there wasn't any left sibling with >1 keys
                                {
                                    if (edgePos > 0)//use left sibling if it is not the left most node
                                    {
                                        sibling = parent.GetEdge(edgePos - 1);
                                        if (sibling.Keys.Count > 1)
                                        {
                                            takeRight = false;//use left
                                        }
                                    }
                                }

                                if (takeRight != null)//case 2a) perform rotation with sibling
                                {
                                    T pK = default(T);
                                    T sK = default(T);

                                if (takeRight.Value)//take from right sibling
                                    {
                                        pK = parent.Pop(edgePos).value;//take parent's key (corresponding to this edge)
                                        sK = sibling.Pop(0).value;//take sibling's left most key

                                        if (sibling.Edges.Count > 0)
                                        {
                                            Node<T> edge = sibling.RemoveEdge(0);//move left most edge
                                            curr.InsertEdge(edge);
                                        }
                                    }
                                    else//take from left sibling
                                    {
                                        pK = parent.Pop(edgePos).value;//take parent's key (corresponding to this edge)
                                        sK = sibling.Pop(sibling.Keys.Count - 1).value;//take sibling's right most key

                                        if (sibling.Edges.Count > 0)
                                        {
                                            Node<T> edge = sibling.RemoveEdge(sibling.Edges.Count - 1);//move right most edge
                                            curr.InsertEdge(edge);
                                        }
                                    }

                                    parent.Push(sK);
                                    curr.Push(pK);
                                }
                                else//case 2b) or 2c) no siblings with >1 keys available
                                {
                                    Node<T> pK = null;
                                    if (parent.Edges.Count >= 2)//case 2b
                                    {
                                        if (edgePos == 0)//if n is left most node, take parent's first key
                                        {
                                            pK = parent.Pop(0);
                                        }
                                        else if (edgePos == parent.Edges.Count)//if n is the right most node take parent's right most key
                                        {
                                            pK = parent.Pop(parent.Keys.Count - 1);
                                        }
                                        else//take parent's middle key
                                        {
                                            pK = parent.Pop(1);
                                        }

                                        if (pK != null)
                                        {
                                            curr.Push(pK.value);
                                            Node<T> sib = null;
                                            if (edgePos != parent.Edges.Count)//use right sibling if it is not the rightmost node
                                            {
                                                sib = parent.RemoveEdge(edgePos + 1);
                                            }
                                            else
                                            {
                                                sib = parent.RemoveEdge(parent.Edges.Count - 1);
                                            }

                                            curr.Fuse(sib);
                                        }
                                    }
                                    else//case 2c
                                    {
                                        curr.Fuse(parent, sibling);
                                        root = curr;
                                        parent = null;
                                    }
                                }
                            }
                        }
                    }

                    int rmPos = -1;
                    if ((rmPos = curr.HasKey(k)) >= 0)
                    {
                        //if it is a leaf node, remove the key
                        if (curr.Edges.Count == 0)
                        {
                            if (curr.Keys.Count == 0)
                            {
                                parent.Edges.Remove(curr);
                            }
                            else
                            {
                                curr.Pop(rmPos);
                            }
                        }
                        else//otherwise, replace it with the next higher key
                        {
                            Node<T> successor = Min(curr.Edges[rmPos]);
                            T sK = successor.Keys[0];
                            if (successor.Keys.Count > 1)
                            {
                                successor.Pop(0);
                            }
                            else
                            {
                                if (successor.Edges.Count == 0)//just remove it if it is leaf
                                {
                                    Node<T> p = successor.Parent;
                                    p.RemoveEdge(successor);
                                }
                                else
                                {
                                    //not leaf so we have to rotate
                                }
                            }
                        }

                        curr = null;
                    }
                    else
                    {
                        //not found, so we move down the tree
                        int p = curr.FindEdgePosition(k);
                        parent = curr;
                        curr = curr.GetEdge(p);
                    }
                }
            }

            public Node<T>[] Inorder(Node<T> n = null)
            {
                if (n == null)
                {
                    n = root;
                }

                List<T> items = new List<T>();
                Tuple<Node<T>, int> curr = new Tuple<Node<T>, int>(n, 0);
                Stack<Tuple<Node<T>, int>> stack = new Stack<Tuple<Node<T>, int>>();
                while (stack.Count > 0 || curr.Item1 != null)
                {
                    if (curr.Item1 != null)//Case 1
                    {
                        stack.Push(curr);
                        Node<T> leftChild = curr.Item1.GetEdge(curr.Item2);//move to leftmost unvisited child
                        curr = new Tuple<Node<T>, int>(leftChild, 0);
                    }
                    else//Case 2
                    {
                        curr = stack.Pop();
                        Node<T> currNode = curr.Item1;

                        //because for every node, it can possibly have more edges than key
                        //if the current index corresponds to a key, we want to add the key into the list.
                        //else we just want to traverse it's edges.
                        if (curr.Item2 < currNode.Keys.Count)
                        {
                            items.Add(currNode.Keys[curr.Item2]);
                            curr = new Tuple<Node<T>, int>(currNode, curr.Item2 + 1);
                        }
                        else
                        {
                            Node<T> rightChild = currNode.GetEdge(curr.Item2 + 1);//get the rightmost child, may be null

                            //if right most child is null, we will visit 'Case 2' again in the next loop,
                            //and the parent will be popped off the stack
                            curr = new Tuple<Node<T>, int>(rightChild, curr.Item2 + 1);
                        }
                    }
                }
                return items.ToArray();
            }

            public Node<T> Min(Node<T> n = null)
            {
                if (n == null)
                {
                    n = root;
                }

                Node<T> curr = n;
                if (curr != null)
                {
                    while (curr.Edges.Count > 0)
                    {
                        curr = curr.Edges[0];
                    }
                }

                return curr;
            }
        }

        
}
