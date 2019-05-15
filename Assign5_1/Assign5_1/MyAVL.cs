using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign5_1
{
    class MyAVL<T> where T : IComparable<T>
    {
        private Node<T> root = null;

        public void insert(T v)
        {

            if (root == null)
            {
                root = new Node<T>();
                root.value = v;
            }
            else
                root = insertRecursive(root, v);
        }
        private Node<T> insertRecursive(Node<T> root, T v)
        {
            if (root == null)
            {
                root = new Node<T>();
                root.value = v;
            }
            else if (v.CompareTo(root.value) < 0)
            {
                root.left = insertRecursive(root.left, v);
                root = balance_tree(root);
            }
            else
            {
                root.right = insertRecursive(root.right, v);
                root = balance_tree(root);
            }
            return root;
        }

        private Node<T> balance_tree(Node<T> root)
        {
            int b_factor = balance_factor(root);
            if (b_factor > 1)
            {
                //left left case
                if (balance_factor(root.left) > 0)
                {
                    root = RotateLeftLeft(root);
                }
                else //left right case
                {
                    root = RotateLeftRight(root);
                }
            }
            else if (b_factor < -1)
            {
                if (balance_factor(root.right) > 0)
                {
                    root = RotateRightLeft(root);
                }
                else
                {
                    root = RotateRightRight(root);
                }
            }
            return root;
        }
        private Node<T> afterdelete_balance(Node<T> root)
        {
            int b_factor = balance_factor(root);
            if (b_factor == -2)//here
            {
                if (balance_factor(root.right) <= 0)
                {
                    root = RotateRightRight(root);
                }
                else
                {
                    root = RotateRightLeft(root);
                }
            }
            else if (b_factor == 2)
            {
                if (balance_factor(root.left) >= 0)
                {
                    root = RotateLeftLeft(root);
                }
                else
                {
                    root = RotateLeftRight(root);
                }
            }
            else if (balance_factor(root) == 2)//rebalancing
            {
                if (balance_factor(root.left) >= 0)
                {
                    root = RotateLeftLeft(root);
                }
                else
                {
                    root = RotateLeftRight(root);
                }
            }
            return root;
        }

        public int getHeight(Node<T> current)
        {
            int height = 0;
            if (current != null)
            {
                int l = getHeight(current.left);
                int r = getHeight(current.right);
                int m = Math.Max(l, r);
                height = m + 1;
            }
            return height;
        }
        public int balance_factor(Node<T> current)
        {
            //Null exception
            int l = getHeight(current.left);
            int r = getHeight(current.right);
            int b_factor = l - r;
            return b_factor;
        }
        //Level order traversal repurposed from http://www.geeksforgeeks.org/level-order-tree-traversal/
        public void printLevelOrder(Node<T> root)
        {
            int h = getHeight(root);
            int i;
            string temp;//formatting 
            for (i = 1; i <= h; i++)
            {
                Console.WriteLine();
                temp = new string(' ', 4 * (h - i));//formatting
                Console.Write(temp);//the formatting being printed
                printGivenLevel(root, i);
            }
        }
        public void printGivenLevel(Node<T> root, int level)
        {
            //The formatting should probably happen here not in printLevelOrder
            //

            if (root == null)
            {
                Console.Write(" ni ");
                return;
            }
            if (level == 1)
                Console.Write(" " + root.value + " ");
            else if (level > 1)
            {
                printGivenLevel(root.left, level - 1);
                printGivenLevel(root.right, level - 1);

            }

        }
        public string preOrder()
        {
            return PreOrdera(root);
        }
        public string PreOrdera(Node<T> root)
        {
            /* if (root == null)
            {
                return "nil";
            }
            return root.value.ToString() + " " + PreOrdera(root.left) + " " + PreOrdera(root.right); */
            if (root == null)
            {
                return "";
            }
            Console.WriteLine(root.value.ToString());
            PreOrdera(root.left);
            PreOrdera(root.right);
            return "";

        }
        public string inOrder()
        {
            return inOrdera(root);
        }
        private string inOrdera(Node<T> root)
        {
            if (root == null)
            {
                return "";
            }
            inOrdera(root.left);
            Console.WriteLine(root.value.ToString());
            inOrdera(root.right);
            return "";
        }
        //AVL Lab

        //this is actually the rotate to the left, it's insert in the
        // right sub tree of a right subtree case
        public Node<T> RotateRightRight(Node<T> parent)
        {
            Node<T> pivot = parent.right;
            parent.right = pivot.left;
            pivot.left = parent;
            return pivot;
        }
        public Node<T> RotateLeftLeft(Node<T> parent)
        {
            Node<T> pivot = parent.left;
            parent.left = pivot.right;
            pivot.right = parent;
            return pivot;
        }
        public Node<T> RotateLeftRight(Node<T> parent)
        {
            Node<T> pivot = parent.left;
            parent.left = RotateRightRight(pivot);
            return RotateLeftLeft(parent);
        }
        public Node<T> RotateRightLeft(Node<T> parent)
        {
            Node<T> pivot = parent.right;
            parent.right = RotateLeftLeft(pivot);
            return RotateRightRight(parent);
        }
        public Node<T> findsmallestbst()
        {
            return findsmallestbsta(root);
        }
        private Node<T> findsmallestbsta(Node<T> root)
        {

            if (root.left == null)
            {
                return root;
            }
            else
                return findsmallestbsta(root.left);
        }
        public bool find(T v)
        {
            if (root != null && Contains(root, v) != false)
            {
                Console.WriteLine("Object exists!");
                return true;
            }
            else
            {
                Console.WriteLine("Object does not exist!");
                return false;
            }

        }
        private bool Contains(Node<T> root, T v)
        {
            if (root == null)
            {
                return false;
            }
            else if (root.value.CompareTo(v) == 0)
            {
                return true;
            }
            else if (root.value.CompareTo(v) < 0)
            {
                return Contains(root.right, v);
            }
            else
            {
                return Contains(root.left, v);
            }
        }


        public Node<T> delete(T v)
        {
            return deleteNode(root, v);
        }
        //https://simpledevcode.wordpress.com/2014/09/16/avl-tree-in-c/ delete method.
        private Node<T> deleteNode(Node<T> root, T v)
        {
            Node<T> parent;
            if (root == null)
            {
                return null;
            }
            else
            {
                //left subtree
                if (v.CompareTo(root.value) < 0)
                {
                    root.left = deleteNode(root.left, v);
                    root = afterdelete_balance(root);
                }
                //right subtree
                else if (v.CompareTo(root.value) > 0)
                {
                    root.right = deleteNode(root.right, v);
                    root = afterdelete_balance(root);
                }
                //if v is found
                else
                {
                    if (root.right != null)
                    {
                        //delete its inorder successor
                        parent = root.right;
                        while (parent.left != null)
                        {
                            parent = parent.left;
                        }
                        root.value = parent.value;
                        root.right = deleteNode(root.right, parent.value);
                        root = afterdelete_balance(root);
                    }
                    else
                    {   //if root.left != null
                        return root.left;
                    }
                }
            }
            return root;
        }
    }
}
