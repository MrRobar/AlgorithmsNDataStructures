using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Randomizer : MonoBehaviour
{
    [SerializeField] private Transform _lineElement;
    [SerializeField] private Transform _elementsHolder;
    [SerializeField] private int _count = 0;
    [SerializeField] private int _offset = 50;
    [SerializeField] private Button _resetButton;
    [SerializeField] private Algorithms _algorithms;

    private void Awake()
    {
        Randomize();
    }

    private void OnEnable()
    {
        _resetButton.onClick.AddListener(ResetMethod);
    }

    private void OnDisable()
    {
        _resetButton.onClick.RemoveListener(ResetMethod);
    }

    private void ResetMethod()
    {
        _algorithms.StopAllCoroutines();
        Randomize();
    }

    private void Randomize()
    {
        if (_elementsHolder.childCount > 0)
        {
            for (int i = 0; i < _count; i++)
            {
                DestroyImmediate(_elementsHolder.GetChild(0).gameObject);
            }
        }

        for (int i = 0; i < _count; i++)
        {
            var rt = Instantiate(_lineElement, _elementsHolder, false).GetComponent<RectTransform>();
            rt.localPosition = new Vector3(25f + (i * _offset), 0f, 0f);
            rt.localScale = Vector3.one;
            rt.sizeDelta = new Vector2(25f, Random.Range(25f, 300f));
            rt.name = i.ToString();
        }
    }
}