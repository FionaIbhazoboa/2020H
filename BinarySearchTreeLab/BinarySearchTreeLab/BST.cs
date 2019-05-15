using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeLab
{
    class Node
    {
        public int value;
        public Node left;
        public Node right;
    }

    class BinarySearchTree
    {
        public Node insert(Node root, int v)
        {
            if (root == null)
            {
                root = new Node();
                root.value = v;
            }


            // insertion logic, if the value (v )is < root, insert to the root.left
            // otherwise it's >=, so insert to the right
            else if (v < root.value)
            {
                root.left = insert(root.left, v);
            }
            else
            {
                root.right = insert(root.right, v);
            }

            return root;
        }
        // Lab:  Take the code from here, and implement 3 different traversals  as strings
        // public string traverse (Node root)

        public string Traverse(Node root)
        {
            if (root == null)
            {
                return "";
            }
            Console.WriteLine(root.value.ToString());
            Traverse(root.left);
            Traverse(root.right);
            return "";

        }
        // For students to implement in the lab 
        // note that in order, pre order and post order are all just rearranging the order
        // of the traverse method basically
        public string inOrder(Node root)
        {
            if(root == null)
            {
                return "";
            }
            inOrder(root.left);
            Console.WriteLine(root.value.ToString());
            inOrder(root.right);
            return "";


        }

        public string preOrder(Node root)
        {
            if (root == null)
            {
                return "";
            }
            Console.WriteLine(root.value.ToString());
            preOrder(root.left);
            preOrder(root.right);
            return "";

        }

        public string postOrder(Node root)
        {
            if (root == null)
            {
                return "";
            }
            postOrder(root.left);
            postOrder(root.right);
            Console.WriteLine(root.value.ToString());
            return "";

        }

        public string breadthFirst(Node root)
        { return ""; }

        public Node findsmallestbst(Node root)
        {
            if (root.left == null)
            {
                return root;
            }
            else
                return findsmallestbst(root.left);
        }

    }
}
