using UnityEngine;
using Random = System.Random;

public class QueueView : MonoBehaviour
{
    [SerializeField] private GameObject _elementPrefab;
    [SerializeField] private Transform _holder;
    [SerializeField] private Queue _myQueue = new Queue();

    [ContextMenu("ResetQueue")]
    public void ResetQueue()
    {
        _myQueue = new Queue();
        for (int i = 0; i < _holder.childCount; i++)
        {
            Destroy(_holder.GetChild(i).gameObject);
        }
    }

    public void Enqueue()
    {
        Random rnd = new Random();
        var value = rnd.Next(0, 100);
        _myQueue.Enqueue(value);
        var instance = Instantiate(_elementPrefab, _holder);
        instance.GetComponent<Element>().Init(value);
    }

    public void Dequeue()
    {
        if (_holder.childCount < 1)
        {
            return;
        }

        var element = _holder.GetChild(0).gameObject;
        _myQueue.Dequeue();
        Destroy(element);
    }
}