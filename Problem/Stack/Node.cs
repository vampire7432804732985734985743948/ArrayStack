using System;
using System.Collections.Generic;

namespace Problem.Stack
{
    internal class Node<T>
    {
        public Node<T>? PreviousItem { get; set; }
        public T Data { get; private set; }

        public Node(T data)
        {
            Data = data;
        }
    }
}
