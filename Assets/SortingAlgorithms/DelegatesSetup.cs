using System;
using System.Collections.Generic;
using UnityEngine;

public class DelegatesSetup : MonoBehaviour
{
    [SerializeField] private Randomizer _randomizer;
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
        _bubbleSort += _randomizer.BubbleSort;
        _insertionSort += _randomizer.InsertionSort;
        _selectionSort += _randomizer.SelectionSort;
        _optionSelector.OnStartButtonClicked += DispatchDelegate;
    }

    private void OnDisable()
    {
        _bubbleSort -= _randomizer.BubbleSort;
        _insertionSort -= _randomizer.InsertionSort;
        _selectionSort -= _randomizer.SelectionSort;
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