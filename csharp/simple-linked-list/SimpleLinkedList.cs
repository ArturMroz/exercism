using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SimpleLinkedList<T> : IEnumerable<T>
{
    public SimpleLinkedList(T value)
    {
        Value = value;
    }

    public SimpleLinkedList(IEnumerable<T> values) : this(values.First())
    {
        foreach (var value in values.Skip(1))
        {
            Add(value);
        }
    }

    public T Value { get; }
    public SimpleLinkedList<T> Next { get; private set; }

    public SimpleLinkedList<T> Add(T value)
    {
        var current = this;
        while (current.Next != null)
        {
            current = current.Next;
        }

        current.Next = new SimpleLinkedList<T>(value);
        return this;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var current = this;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}