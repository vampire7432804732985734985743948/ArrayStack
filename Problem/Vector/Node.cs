﻿using System;
using System.Collections.Generic;

internal class Node<T>
{
    private T? _data;
    public int Index { get; set; }
    public T? Data
    {
        get { return _data; }
        set { _data = value; }
    }

    public Node(T? data, int index)
    {
        Data = data;
        Index = index;
    }
    public Node(T? data)
    {
        Data = data;
    }
}
