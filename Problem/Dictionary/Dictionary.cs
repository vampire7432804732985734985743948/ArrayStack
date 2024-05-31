using System;
using System.Collections;
using System.Collections.Generic;

namespace Problem.Dictionary
{
    internal class Dictionary<TKey, TValue>
    {
        private List<Node<TKey, TValue>> _items = new List<Node<TKey, TValue>>();
        public int Count { get; private set; }

        public void Add(TKey key, TValue value)
        {
            if (key != null && value != null) 
            {
                foreach (var item in _items)
                {
                    if (!item.Key.Equals(key))
                    {
                        _items.Add(new Node<TKey, TValue>(key, value));
                        Count = _items.Count;
                    }
                    else
                    {
                        throw new ArgumentException("Provide another key");
                    }
                }
            }
            else
            {
                throw new ArgumentNullException("Check your input");
            }
        }
        public void Show()
        {
            foreach (var item in _items)
            {
                Console.WriteLine($"{item.Key}, {item.Value}");
            }
        }
        public void DeleteByKey(TKey key)
        {
            if (_items.Count <= 0)
            {
                Console.WriteLine("Dictionary is empty");
                return;
            }
            else
            {
                if (key != null)
                {
                    for (int i = 0; i < _items.Count; i++)
                    {
                        if (key.Equals(_items[i].Key))
                        {
                            _items.RemoveAt(i);
                            Count = _items.Count; 
                            break;
                        }
                    }
                }
                else { Console.WriteLine("Provide a proper key, please"); }
            }
        }
        public void FindValueByKey(TKey key)
        {
            if (_items.Count <= 0)
            {
                Console.WriteLine("Dictionary is empty");
                return;
            }
            else
            {
                if (key != null)
                {
                    for (int i = 0; i < _items.Count; i++)
                    {
                        if (key.Equals(_items[i].Key))
                        {
                            Console.WriteLine(_items[i].Value);
                            break;
                        }
                    }
                }
                else { Console.WriteLine("Provide a prepper key, please"); }
            }
        }
    }
}
