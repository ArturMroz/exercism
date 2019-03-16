using System;
using System.Collections.Generic;

public class CircularBuffer<T>
{
    private readonly Queue<T> _buffer;
    private readonly int _capacity;

    public CircularBuffer(int capacity)
    {
        _capacity = capacity;
        _buffer = new Queue<T>(capacity);
    }

    public T Read() => _buffer.Dequeue();

    public void Write(T value)
    {
        if (_buffer.Count == _capacity) throw new InvalidOperationException();

        _buffer.Enqueue(value);
    }

    public void Overwrite(T value)
    {
        if (_buffer.Count == _capacity) _buffer.Dequeue();

        Write(value);
    }

    public void Clear() => _buffer.Clear();
}