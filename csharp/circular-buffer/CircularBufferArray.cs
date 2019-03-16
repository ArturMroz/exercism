using System;
using System.Collections.Generic;

public class CircularBuffer_Array<T> where T : struct
{
    private readonly T?[] _buffer;
    private int _current;

    public CircularBuffer_Array(int capacity) => _buffer = new T?[capacity];

    public T Read()
    {
        var result = SeekLast();

        if (result == null) throw new InvalidOperationException();

        return result.Value;
    }

    public void Write(T value)
    {
        if (_buffer[_current] != null) throw new InvalidOperationException();

        Overwrite(value);
    }

    public void Overwrite(T value)
    {
        _buffer[_current] = value;
        _current = GetNext(_current);
    }

    public void Clear()
    {
        SeekLast();
    }

    private int GetNext(int current) =>
        current + 1 >= _buffer.Length ? 0 : current + 1;

    private T? SeekLast()
    {
        var curr = _current;

        do
        {
            var last = _buffer[curr];

            if (last != null)
            {
                _buffer[curr] = null;
                return last;
            }

            curr = GetNext(curr);
        }
        while (_current != curr);

        return null;
    }
}