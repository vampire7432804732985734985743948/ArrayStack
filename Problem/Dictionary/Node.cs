using System;
using System.Collections.Generic;

namespace Problem.Dictionary
{
    internal class Node<TKey, TValue>
    {
        public TKey? Key { get; private set; }
        public TValue? Value { get; private set; }

        public Node(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
    }
}