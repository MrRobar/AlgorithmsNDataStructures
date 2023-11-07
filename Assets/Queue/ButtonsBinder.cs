using UnityEngine;
using UnityEngine.UI;

public class ButtonsBinder : MonoBehaviour
{

    [SerializeField] private Button _enqueueButton, _dequeueButton, _resetButton;
    [SerializeField] private QueueView _queueView;
    
    private void OnEnable()
    {
        _enqueueButton.onClick.AddListener(_queueView.Enqueue);
        _dequeueButton.onClick.AddListener(_queueView.Dequeue);
        _resetButton.onClick.AddListener(_queueView.ResetQueue);
    }

    private void OnDisable()
    {
        _enqueueButton.onClick.RemoveListener(_queueView.Enqueue);
        _dequeueButton.onClick.RemoveListener(_queueView.Dequeue);
        _resetButton.onClick.RemoveListener(_queueView.ResetQueue);
    }
}
