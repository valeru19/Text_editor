using System;
using System.Collections.Generic;
using System.IO;
using System;

public class BadIndexException : Exception
{
    public BadIndexException() : base("Invalid index.")
    {
    }

    public BadIndexException(string message) : base(message)
    {
    }
}

public class BadFileException : Exception
{
    public BadFileException() : base("File operation failed.")
    {
    }

    public BadFileException(string message) : base(message)
    {
    }
}


public abstract class BaseList<T>
{
    public delegate void ChangeHandler();
    public event ChangeHandler event_Change;

    protected void OnChange()
    {
        if (event_Change != null)
            event_Change();
    }

    public abstract void Add(T item);
    public abstract void Insert(int index, T item);
    public abstract void Delete(int index);
    public abstract void Clear();
    public abstract int Find(T item);
    public abstract T this[int index] { get; set; }
    public abstract int Count { get; }
    public abstract void SaveToFile(string fileName);
    public abstract void LoadFromFile(string fileName);
    public abstract void PrintList();
}


