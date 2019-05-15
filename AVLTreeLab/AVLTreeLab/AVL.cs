using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLTreeLab
{
    class Node
    {
        //public int key;  //  we combine our key and value as the same thing but they could be distinct
        public int value;
        public Node left;
        public Node right;
        public int balance=0; // Students need to worry about this
        // public Node Parent;  //might be useful
    }

    class AVLTree
    {
        public Node insert(Node root, int v)
        {
            if (root == null)
            {
                root = new Node();
                root.value = v;
            }
            else if (v < root.value)
            {
                root.left = insert(root.left, v);
                root = balance_tree(root);
            }
            else
            {
                root.right = insert(root.right, v);
                root = balance_tree(root);
            }

            return root;
        }

        private Node balance_tree(Node root)
        {
            int b_factor = balance_factor(root);
            if (b_factor > 1)
            {
                if (balance_factor(root.left) > 0)
                {
                    root = RotateLeftLeft(root);
                }
                else
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
        public int getHeight(Node current)
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
        public int balance_factor(Node current)
        {
            int l = getHeight(current.left);
            int r = getHeight(current.right);
            int b_factor = l - r;
            return b_factor;
        }
        //Level order traversal repurposed from http://www.geeksforgeeks.org/level-order-tree-traversal/
        public void printLevelOrder(Node root)
        {
            int h = getHeight(root);
            int i;
            string temp;//formatting 
            for (i = 1; i <= h; i++)
            {
                Console.WriteLine();
                temp = new string(' ',4*( h-i));//formatting
                Console.Write(temp);//the formatting being printed
                printGivenLevel(root, i);
            }
        }
        public void printGivenLevel(Node root, int level)
        {
            //The formatting should probably happen here not in printLevelOrder
            //
            
            if (root == null)
            {
                Console.Write(" ni ");
                return;
            }
            if (level == 1)
                Console.Write(" " + root.value+ " ");
            else if (level > 1)
            {
                printGivenLevel(root.left, level - 1);
                printGivenLevel(root.right, level - 1);
                
            }
            
        }
        public string PreOrder(Node root)
        {
            if (root == null)
            {
                return "nil";
            }
            return root.value.ToString() + " " + PreOrder(root.left) + " " + PreOrder(root.right);


        }
        //AVL Lab

            //this is actually the rotate to the left, it's insert in the
            // right sub tree of a right subtree case
        public Node RotateRightRight(Node parent)
        {
            Node pivot = parent.right;
            parent.right = pivot.left;
            pivot.left = parent;
            return pivot;
        }
        public Node RotateLeftLeft(Node parent)
        {
            Node pivot = parent.left;
            parent.left = pivot.right;
            pivot.right = parent;
            return pivot;
        }
        public Node RotateLeftRight(Node parent)
        {
            Node pivot = parent.left;
            parent.left = RotateRightRight(pivot);
            return RotateLeftLeft(parent);
        }
        public Node RotateRightLeft(Node parent)
        {
            Node pivot = parent.right;
            parent.right = RotateLeftLeft(pivot);
            return RotateRightRight(parent);
        }







    }
}
