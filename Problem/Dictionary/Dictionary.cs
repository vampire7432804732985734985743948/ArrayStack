using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

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
                    if (item.Key.Equals(key))
                    {
                        Console.WriteLine( new StringBuilder("Provide another set of values"));
                        return;
                    }
                }
                _items.Add(new Node<TKey, TValue>(key, value));
                Count = _items.Count;
            }
            else
            {
                Console.WriteLine(new StringBuilder("Check your input"));
            }
        }
        public void OrderByAscending()
        {
            if (_items[0].Key is int)
            {
                for (int i = 0; i < Count; i++)
                {
                    for(int j = i + 1; j < Count; j++)
                    {
                        if (Convert.ToInt32(_items[i].Key) > Convert.ToInt32(_items[j].Key))
                        {
                            var temp = _items[i];

                            _items[i] = _items[j];
                            _items[j] = temp;
                        }
                    }
                }  
            }
        }
        public int FindTheBiggestNumber(int[] ints)
        {
            for (int i = 0; i < ints.Length; i++)
            {
                for (int j = i + 1; j < ints.Length; j++)
                {
                    if (ints[i] > ints[j])
                    {
                        var temp = ints[i];
                        ints[i] = ints[j];
                        ints[j] = temp;
                    }
                }
            }
            return ints[^1];
        }
        public void Show()
        {
            foreach (var item in _items)
            {
                Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
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
