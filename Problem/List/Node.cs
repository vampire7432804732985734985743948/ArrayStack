﻿internal class Node<T>
{
    private T? _data;
    public int Index { get; private set; }
    public T? Data
    {
        get { return _data; }
        set { _data = value; }
    }

    public Node(T? data, int index)
    {
        Data = dataж
        Index = index;
    }
    public Node(T? data)
    {
        Data = data;
    }
}
