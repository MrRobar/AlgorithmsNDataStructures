using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BinarySearch : MonoBehaviour
{
    [SerializeField] private ElementsCreator _elementsCreator;
    [SerializeField] private Transform _holder;
    [SerializeField] private Color _removed;
    [SerializeField] private Color _chosen;
    [SerializeField] private Color _target;
    [SerializeField] private float _delay = 0.1f;

    public void RunSearch()
    {
        StartCoroutine(SearchCoroutine());
    }

    public void ResetSearch()
    {
        StopAllCoroutines();
    }

    private void RemoveElements(int from, int to)
    {
        for (int i = from; i <= to; i++)
        {
            _holder.GetChild(i).GetComponent<Image>().color = _removed;
        }
    }

    private IEnumerator SearchCoroutine()
    {
        var array = _elementsCreator.Values;
        var target = array[_elementsCreator.TargetID];
        var left = 0;
        var right = array.Length - 1;

        _holder.GetChild(_elementsCreator.TargetID).GetComponent<Image>().color = _target;
        
        while (left <= right)
        {
            var middle = (left + right) / 2;
            _holder.GetChild(middle).GetComponent<Image>().color = _chosen;
            yield return new WaitForSeconds(_delay);
            if (array[middle] == target)
            {
                break;
            }

            if (target < array[middle])
            {
                RemoveElements(middle, right);
                right = middle - 1;
            }
            else
            {
                RemoveElements(left, middle);
                left = middle + 1;
            }
        }

        yield return null;
    }
}