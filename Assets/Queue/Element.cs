using TMPro;
using UnityEngine;

public class Element : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    public void Init(int value)
    {
        _text.text = value.ToString();
    }
}