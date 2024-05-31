using System;
using System.Text;
using System.ComponentModel;
using System.Collections;

namespace Problem.List
{
    internal class Vector<T> : IEnumerable<Node<T>>
    {
        private Node<T>[] _elements; 
        public int Count { get; private set; }

        public Vector(int numberOfElements = 1)
        {
            _elements = new Node<T>[numberOfElements];
        }

        public Vector(Node<T>[] copy)
        {
            if (copy != null)
            {
                _elements = copy;
            }
            else
            {
                throw new ArgumentException("Signed list is empty or null");
            }
        }
        public void Add(T data)
        {
            if (data != null)
            {
                if (Count == _elements.Length)
                {
                    _elements = RewriteData();
                }
                Node<T> node = new Node<T>(data, Count);
                _elements[Count] = node;
                Count++;
            }
        }
        public T? FindElementById(int target)
        {
            int left = 0;
            int right = Count - 1;

            while (left <= right)
            {
                int middle = left + (right - left) / 2;

                if (_elements[middle].Index == target)
                    return _elements[middle].Data;
                if(_elements[middle].Index < target)
                    left = middle + 1;

                else
                    right = middle - 1;
            }
            Console.WriteLine(new StringBuilder("Vector is empty"));
            return default(T);
        }
        public T? GetFirstElement()
        {
            if (_elements.Length > 0)
            {
                return _elements[0].Data;
            }
            else
            {
                Console.WriteLine(new StringBuilder("Vector is empty"));
                return default(T);
            }
        }
        public T? GetLastElement()
        {
            if (_elements.Length > 0)
            {
                return _elements[Count - 1].Data;
            }
            else
            {
                Console.WriteLine(new StringBuilder("Vector is empty"));
                return default(T);
            }
        }
        public void RemoveLast()
        {
            if (Count > 0)
            {
                Count--;
                _elements[Count] = new Node<T>(default);
            }
        }

        public void ShowData()
        {
            for (int i = 0; i < Count; i++)
            {
                Console.WriteLine(_elements[i].Data);
            }
        }

        public void Clear()
        { 
            _elements = new Node<T>[_elements.Length];
            Count = 0;
        }
        public void ClearAll()
        {
            _elements = new Node<T>[1];
            Count = 0;
        }
        public void Reverse()
        {
            int leftIndex = 0;
            int rightIndex = Count - 1;

            while (leftIndex < rightIndex)
            {
                var temp = _elements[leftIndex];
                _elements[leftIndex] = _elements[rightIndex];
                _elements[rightIndex] = temp;

                leftIndex++;
                rightIndex--;
            }
        }

        private Node<T>[] RewriteData()
        {
            int doubledLength = _elements.Length * 2;
            var redistributedArray = new Node<T>[doubledLength];
            for (int i = 0; i < _elements.Length; i++)
            {
                redistributedArray[i] = _elements[i];
            }
            return redistributedArray;
        }

        private bool IsEmpty() => _elements == null || _elements.Length == 0 ? true : false;

        public IEnumerator<Node<T>> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
