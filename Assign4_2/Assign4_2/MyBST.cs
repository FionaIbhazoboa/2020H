using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign4_2
{
    class Node<T> 
    {
        public T value;
        public Node<T> left;
        public Node<T> right;  
    }

    class MyBST<T> where T : IComparable<T>
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
                insertRecursive(root, v);
        }
        public Node<T> insertRecursive(Node<T> root, T v)
        {
            if (root == null)
            {
                root = new Node<T>();
                root.value = v;
            }
            // insertion logic, if the value (v )is < root, insert to the root.left
            // otherwise it's >=, so insert to the right
            else if (v.CompareTo(root.value) < 0)
            {
                root.left = insertRecursive(root.left, v);
            }
            else
            {
                root.right = insertRecursive(root.right, v);

            }
            return root;
        }
        //returns the inOrdera method
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
        //returns the preOrdera method
        public string preOrder()
        {
            return preOrdera(root);
        }
        private string preOrdera(Node<T> root)
        {
            if (root == null)
            {
                return "";
            }
            Console.WriteLine(root.value.ToString());
            preOrdera(root.left);
            preOrdera(root.right);
            return "";
        }
        //returns the postOrdera method
        public string postOrder()
        {
            return postOrdera(root);
        }
        private string postOrdera(Node<T> root)
        {
            if (root == null)
            {
                return "";
            }
            postOrdera(root.left);
            postOrdera(root.right);
            Console.WriteLine(root.value.ToString());
            return "";

        }
        //finds the smallest element in the tree
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
       
    }
}
