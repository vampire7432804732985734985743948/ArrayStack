using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Channels;

namespace Problem.Stack
{
    internal class ArrayStack<T> : IEnumerable<T>
    {
        private int _numberOfElements;

        public int NumberOfElements
        {
            get { return _numberOfElements; }
            private set
            {
                if (value > 0)
                    _numberOfElements = value;
                else
                    throw new ArgumentException("Invalid value");
            }
        }

        public Node<T>? Head { get; private set; }
        public int Count { get; private set; }
        private T[]? _elements;

        public ArrayStack(int numberOfElements = 0)
        {
            Count = 0;
            Head = null;
            _numberOfElements = numberOfElements;
        }

        private void InitializeStack() => _elements = new T[_numberOfElements];

        public void Push(T data)
        {
            if (data != null)
            {
                var current = new Node<T>(data);
                if (_elements == null)
                {
                    InitializeStack();
                    Head = current;
                }
                else
                {
                    if (Count < _numberOfElements)
                    {
                        current.PreviousItem = Head;
                        Head = current;
                        Count++;
                    }
                    else
                    {
                        throw new ArgumentException("The stack is full");
                    }
                }
            }
            else
            {
                throw new ArgumentException("There is no data");
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
                throw new ArgumentException("Stack is empty");
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
                throw new ArgumentException("Stack is empty");
            }
        }
        public void Reverse()
        {
            int count = Count;
            List<T> list = new List<T>();
            for (int i = 0; i < count; i++)
            {
                if (Head != null)
                {
                    list.Add(Head.Data);
                }
                Pop();
            }
            for (int i = 0; i < count; i++)
            {
                Push(list[i]);
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
