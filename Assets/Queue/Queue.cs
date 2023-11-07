using System;
using UnityEngine;

[Serializable]
public class Queue
{
    public int[] _array;
    public int _head, _tail, _capacity, _size;

    public Queue() : this(4)
    {
    }

    public Queue(int capacity)
    {
        _capacity = capacity;
        _size = 0;
        _array = new int[_capacity];
        ResetHeadNTail();
    }

    private void ResetHeadNTail()
    {
        _head = -1;
        _tail = -1;
    }

    public void Enqueue(int value)
    {
        if (_size == _capacity)
        {
            EnsureCapacity();
        }

        if (_tail < 0)
        {
            _tail++;
            _head++;
            _array[_tail] = value;
            _size++;
            return;
        }


        _tail = (_tail + 1) % _capacity;
        _array[_tail] = value;
        _size++;
    }

    public int Dequeue()
    {
        if (_head < 0)
        {
            throw new Exception("No elements in queue");
        }

        var element = _array[_head];
        if (_head == _tail)
        {
            ResetHeadNTail();
        }
        else
        {
            _head = (_head + 1) % _capacity;
        }

        _size--;
        return element;
    }

    public void DisplayQueue()
    {
        if (_head == -1)
        {
            Debug.Log("No elements");
            return;
        }

        for (int i = _head; i != _tail; i = (i + 1) % _capacity)
        {
            Debug.Log($"{_array[i]} ");
        }

        Debug.Log($"{_array[_tail]} ");
    }

    private void EnsureCapacity()
    {
        _capacity *= 2;
        int[] newArr = new int[_capacity];
        if (_head <= _tail)
        {
            Debug.Log("head <= tail");
            Array.Copy(_array, 0, newArr, 0, _array.Length);
        }
        else
        {
            Debug.Log("head > tail");
            Array.Copy(_array, _head, newArr, 0, _array.Length - _head);
            Array.Copy(_array, 0, newArr, _array.Length - _head, _tail + 1);
            _head = 0;
            _tail = _array.Length - 1;
        }

        _array = newArr;
    }
}