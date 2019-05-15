using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign5
{
    class MyBST<T> where T : IComparable<T>
    {
        private Node<T> root = null;
        public void insert(T v)
        {
            if (root == null)
            {
                root = new Node<T>(v);
                root.value = v;
            }
            else
                insertRecursive(root, v);
        }
        public Node<T> insertRecursive(Node<T> root, T v)
        {
            if (root == null)
            {
                root = new Node<T>(v);
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
        public bool find(T v)
        {
            if (root != null && Contains(root, v) != false)
            {
                Console.WriteLine("Found it!");
                return true;
            }
            else
            {
                Console.WriteLine("Nope, DNE");
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
        // https://www.cs.cmu.edu/~adamchik/15-121/lectures/Trees/code/BST.java
        private Node<T> deleteNode(Node<T> root, T v)
        {
            if (root == null)
                return root;

            if (v.CompareTo(root.value) < 0)
               root.left = deleteNode(root.left, v);
            else if (v.CompareTo(root.value) > 0)
                root.right = deleteNode(root.right, v);
            else
            {
                if (root.left == null) return root.right;
                else
                if (root.right == null) return root.left;
                else
                {
                    // get data from the rightmost node in the left subtree
                    root.value = retrieveData(root.left);
                    // delete the rightmost node in the left subtree
                    root.left = deleteNode(root.left, root.value);
                }
            }
            return root;
        }

        private T retrieveData(Node<T> root)
        {
            while (root.right != null) root = root.right;

            return root.value;
        }

    }
}
