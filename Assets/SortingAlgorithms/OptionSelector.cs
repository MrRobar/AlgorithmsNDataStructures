using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionSelector : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _dropdown;
    [SerializeField] private Button _startButton;
    [SerializeField] private DelegatesSetup _setup;

    public event Action<string> OnStartButtonClicked;

    private void OnEnable()
    {
        _setup.OnDictionarySet += FillDropDownOptions;
        _startButton.onClick.AddListener(OnStartButtonPressed);
    }

    private void OnDisable()
    {
        _setup.OnDictionarySet -= FillDropDownOptions;
        _startButton.onClick.RemoveListener(OnStartButtonPressed);
    }

    private void OnStartButtonPressed()
    {
        OnStartButtonClicked?.Invoke(_dropdown.options[_dropdown.value].text);
    }

    private void FillDropDownOptions()
    {
        List<TMP_Dropdown.OptionData> datas = new List<TMP_Dropdown.OptionData>();

        foreach (var option in _setup.Options)
        {
            TMP_Dropdown.OptionData data = new TMP_Dropdown.OptionData(option.Key);
            datas.Add(data);
        }

        _dropdown.AddOptions(datas);
    }
}