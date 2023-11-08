using System;
using System.Collections.Generic;
using UnityEngine;

public class DelegatesSetup : MonoBehaviour
{
    [SerializeField] private Algorithms _algorithms;
    [SerializeField] private OptionSelector _optionSelector;

    public delegate void SortingAlgorithmDelegate();

    public event Action OnDictionarySet;

    private SortingAlgorithmDelegate _bubbleSort;
    private SortingAlgorithmDelegate _insertionSort;
    private SortingAlgorithmDelegate _selectionSort;

    private Dictionary<string, SortingAlgorithmDelegate> _options;

    public Dictionary<string, SortingAlgorithmDelegate> Options => _options;

    private void Start()
    {
        FillDictionary();
    }

    private void OnEnable()
    {
        _bubbleSort += _algorithms.BubbleSort;
        _insertionSort += _algorithms.InsertionSort;
        _selectionSort += _algorithms.SelectionSort;
        _optionSelector.OnStartButtonClicked += DispatchDelegate;
    }

    private void OnDisable()
    {
        _bubbleSort -= _algorithms.BubbleSort;
        _insertionSort -= _algorithms.InsertionSort;
        _selectionSort -= _algorithms.SelectionSort;
        _optionSelector.OnStartButtonClicked -= DispatchDelegate;
    }

    private void DispatchDelegate(string delName)
    {
        _options[delName]?.Invoke();
    }

    private void FillDictionary()
    {
        _options = new Dictionary<string, SortingAlgorithmDelegate>()
        {
            { "BubbleSort", _bubbleSort },
            { "InsertionsSort", _insertionSort },
            { "SelectionSort", _selectionSort }
        };

        OnDictionarySet?.Invoke();
    }
}