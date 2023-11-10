using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _resetButton;
    [SerializeField] private TextMeshProUGUI _targetText;
    [SerializeField] private BinarySearch _binarySearch;
    [SerializeField] private ElementsCreator _elementsCreator;

    private void OnEnable()
    {
        _startButton.onClick.AddListener(_binarySearch.RunSearch);
        _startButton.onClick.AddListener(DisableStartButton);
        _resetButton.onClick.AddListener(_binarySearch.ResetSearch);
        _resetButton.onClick.AddListener(_elementsCreator.CreateElements);
        _resetButton.onClick.AddListener(EnableStartButton);
        _resetButton.onClick.AddListener(UpdateTargetText);
        UpdateTargetText();
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(_binarySearch.RunSearch);
        _startButton.onClick.RemoveListener(DisableStartButton);
        _resetButton.onClick.RemoveListener(_binarySearch.ResetSearch);
        _resetButton.onClick.RemoveListener(_elementsCreator.CreateElements);
        _resetButton.onClick.RemoveListener(EnableStartButton);
        _resetButton.onClick.RemoveListener(UpdateTargetText);
    }

    private void UpdateTargetText()
    {
        _targetText.text = $"Target: {_elementsCreator.Values[_elementsCreator.TargetID]}";
    }

    private void DisableStartButton()
    {
        _startButton.enabled = false;
    }

    private void EnableStartButton()
    {
        _startButton.enabled = true;
    }
}