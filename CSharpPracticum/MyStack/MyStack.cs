using System;

// ============================================================
// MyStack<T> — LIFO, на массиве с удвоением
// ============================================================
public class MyStack<T>
{
    private T[] _items;
    private int _count;

    public MyStack(int capacity = 4)
    {
        if (capacity < 1) capacity = 4;
        _items = new T[capacity];
        _count = 0;
    }

    public int Count => _count;
    public bool IsEmpty => _count == 0;

    public void Push(T item)
    {
        if (_count == _items.Length)
            Resize(_items.Length * 2);      // удвоение при переполнении
        _items[_count++] = item;
    }

    public T Pop()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Стек пуст.");
        T item = _items[--_count];
        _items[_count] = default!;          // очистка ссылки для GC
        return item;
    }

    public T Peek()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Стек пуст.");
        return _items[_count - 1];
    }

    private void Resize(int newCapacity)
    {
        T[] bigger = new T[newCapacity];
        Array.Copy(_items, bigger, _count);
        _items = bigger;
    }
}

// ============================================================
// MyQueue<T> — FIFO, на массиве (кольцевой буфер)
// ============================================================
public class MyQueue<T>
{
    private T[] _items;
    private int _head;      // индекс первого элемента
    private int _count;

    public MyQueue(int capacity = 4)
    {
        if (capacity < 1) capacity = 4;
        _items = new T[capacity];
        _head = 0;
        _count = 0;
    }

    public int Count => _count;
    public bool IsEmpty => _count == 0;

    public void Enqueue(T item)
    {
        if (_count == _items.Length)
            Resize(_items.Length * 2);
        int tail = (_head + _count) % _items.Length;   // кольцевой сдвиг
        _items[tail] = item;
        _count++;
    }

    public T Dequeue()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Очередь пуста.");
        T item = _items[_head];
        _items[_head] = default!;                       // очистка для GC
        _head = (_head + 1) % _items.Length;
        _count--;
        return item;
    }

    public T Peek()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Очередь пуста.");
        return _items[_head];
    }

    private void Resize(int newCapacity)
    {
        T[] bigger = new T[newCapacity];
        for (int i = 0; i < _count; i++)
            bigger[i] = _items[(_head + i) % _items.Length];   // «выпрямляем» кольцо
        _items = bigger;
        _head = 0;
    }
}