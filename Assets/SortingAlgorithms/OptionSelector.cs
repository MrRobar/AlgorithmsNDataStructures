using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OptionSelector : MonoBehaviour
{

    [SerializeField] private TMP_Dropdown _dropdown;
    [SerializeField] private AlgorithmType _algorithmType;

    private void Awake()
    {
       FillDropDown();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log(_dropdown.options[_dropdown.value].text);
        }
    }

    private void FillDropDown()
    {
        List<TMP_Dropdown.OptionData> datas = new List<TMP_Dropdown.OptionData>();
        var values = Enum.GetValues(typeof(AlgorithmType));
        foreach (var variant in values)
        {
            datas.Add(new TMP_Dropdown.OptionData(variant.ToString()));
        }
        _dropdown.AddOptions(datas);
    }
}

public enum AlgorithmType
{
    BubbleSort,
    SelectionSort,
    InsertionSort
}