using System;
using System.Text;
using System.ComponentModel;
using System.Collections;

namespace Problem.List
{
    internal class Vector<T> : IEnumerable<T>
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
        public Vector<T> Union(Vector<T> vector)
        {
            Vector<T> result = new Vector<T>();

            foreach (var item in this)
            {
                if (item != null && !result.Contains(item))
                {
                    result.Add(item);
                }
            }

            foreach (var item in vector)
            {
                if (item != null && !result.Contains(item))
                {
                    result.Add(item);
                }
            }

            return result;
        }
        public Vector<T> Intersect(Vector<T> vector)
        {
            Vector<T> result = new Vector<T>();

            foreach (var item in this)
            {
                if (item != null && vector.Contains(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }
        public Vector<T> Difference(Vector<T> vector)
        {
            Vector<T> result = new Vector<T>();

            foreach (var item in this)
            {
                if (item != null && !vector.Contains(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }
        public bool Contains(T data)
        {
            foreach (var item in _elements)
            {
                if (item != null && item.Data != null && item.Data.Equals(data))
                {
                    return true;
                }
            }
            return false;
        }
       
        public void Add(T data)
        {
            if (data != null)
            {
                if (Count == _elements.Length)
                {
                    _elements = RearrangeArray();
                }
                Node<T> node = new Node<T>(data, Count);
                _elements[Count] = node;
                Count++;
            }
        }

        public void Insert(T data, int index)
        {
            if (data != null && index >= 0 && index <= Count)
            {
                if (Count == _elements.Length)
                {
                    _elements = RearrangeArray();
                }
                for (int i = Count; i > index; i--)
                {
                    _elements[i] = _elements[i - 1];
                }
                _elements[index] = new Node<T>(data, index);
                Count++;
                for (int i = index + 1; i < Count; i++)
                {
                    if (_elements[i] != null)
                    {
                        _elements[i].Index = i;
                    }
                }
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
            if (_elements.Length > 0 && _elements[0] != null)
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

        private Node<T>[] RearrangeArray()
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

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                if (_elements[i].Data != null)
                {
                    yield return _elements[i].Data!;
                }
                else
                {
                    throw new InvalidOperationException("Data is null at index " + i);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
