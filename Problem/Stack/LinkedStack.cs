using System;
using System.Collections;
using System.Collections.Generic;

namespace Problem.Stack
{
    internal class LinkedStack<T> : IEnumerable<T>
    {
        public Node<T>? Head { get; private set; }
        public int Count { get; private set; }

        public LinkedStack()
        {
            Count = 0;
            Head = null;
        }

        private void InitiateLinkedStack(T data)
        {
            if (data != null)
            {
                Head = new Node<T>(data);
                Count = 1;
            }
            else
            {
                throw new Exception("Stack can't be initialized");
            }
        }

        public void Push(T data)
        {
            if (data != null)
            {
                if (Head == null)
                {
                    InitiateLinkedStack(data);
                }
                else
                {
                    var current = new Node<T>(data);
                    current.PreviousItem = Head;
                    Head = current;
                    Count++;
                }
            }
            else
            {
                throw new Exception("There is no data to add");
            }
        }

        public T Pop()
        {
            if (Head != null)
            {
                var current = Head;
                Head = Head?.PreviousItem;
                Count--;
                return current.Data;
            }
            else
            {
                throw new Exception("The Stack is empty");
            }
        }

        public void Peek()
        {
            if (Head != null)
            {
                Console.WriteLine(Head.Data);
            }
            else
            {
                throw new Exception("The Stack is empty");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.PreviousItem;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
