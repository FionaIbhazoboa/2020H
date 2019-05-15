using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign5_1
{
    class Node<T> where T : IComparable<T>
    {
        public T value;
        public Node<T> left;
        public Node<T> right;
        public int balance = 0;
    }
}
