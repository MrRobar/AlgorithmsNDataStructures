using System;
using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;

public class ElementsCreator : MonoBehaviour
{
    [SerializeField] private Transform _holder;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _count;
    private int[] _values;
    [SerializeField] private int _targetID;

    public int TargetID => _targetID;

    public int[] Values => _values;

    private void Awake()
    {
        CreateElements();
    }

    private void TakeRandomID()
    {
        Random random = new Random();
        _targetID = random.Next(0, _values.Length);
    }

    private void GenerateArray()
    {
        _values = new int[_count];
        Random random = new Random();
        for (int i = 0; i < _count; i++)
        {
            _values[i] = random.Next(0, 1000);
        }

        Array.Sort(_values);
    }

    private void DeleteElements()
    {
        if (_holder.childCount < 1)
        {
            return;
        }

        for (int i = 0; i < _holder.childCount; i++)
        {
            Destroy(_holder.GetChild(i).gameObject);
        }
    }

    public void CreateElements()
    {
        DeleteElements();
        GenerateArray();
        TakeRandomID();
        for (int i = 0; i < _count; i++)
        {
            var instance = Instantiate(_prefab, _holder);
            instance.GetComponent<Element>().Init(_values[i]);
        }
    }
}