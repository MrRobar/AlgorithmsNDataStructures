using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Algorithms : MonoBehaviour
{
    [SerializeField] private Transform _elementsHolder;
    [SerializeField] private int _count = 0;
    [SerializeField] private Color _defaultColor;
    [SerializeField] private Color _chosenColor;
    [SerializeField] private float _timeToWait = 0.01f;

    public void SelectionSort()
    {
        StartCoroutine(SelectionSortCoroutine());
    }

    public void InsertionSort()
    {
        StartCoroutine(InsertionSortCoroutine());
    }

    public void BubbleSort()
    {
        StartCoroutine(BubbleSortCoroutine());
    }

    private IEnumerator SelectionSortCoroutine()
    {
        for (int i = 0; i < _count; i++)
        {
            int minimalIndex = i;
            var minRt = _elementsHolder.GetChild(minimalIndex).GetComponent<RectTransform>();
            var minY = minRt.sizeDelta.y;
            minRt.GetComponent<Image>().color = _chosenColor;

            yield return new WaitForSeconds(_timeToWait);

            for (int j = i + 1; j < _count; j++)
            {
                var currentRt = _elementsHolder.GetChild(j).GetComponent<RectTransform>();
                var y = currentRt.sizeDelta.y;
                if (y < minY)
                {
                    minimalIndex = j;
                    minY = y;
                }
            }

            var min = _elementsHolder.GetChild(minimalIndex);
            var current = _elementsHolder.GetChild(i);
            var minImage = min.GetComponent<Image>();
            var currentImage = current.GetComponent<Image>();
            minImage.color = _chosenColor;
            currentImage.color = _chosenColor;

            yield return new WaitForSeconds(_timeToWait);
            minRt = min.GetComponent<RectTransform>();
            var temp = minRt.sizeDelta;

            minRt.sizeDelta = current.GetComponent<RectTransform>().sizeDelta;
            current.GetComponent<RectTransform>().sizeDelta = temp;
            minImage.color = _defaultColor;
            currentImage.color = _defaultColor;
        }
    }

    private IEnumerator InsertionSortCoroutine()
    {
        for (int i = 0; i < _count; i++)
        {
            int currentIter = i;

            while (currentIter > 0)
            {
                var previousObj = _elementsHolder.GetChild(currentIter - 1).GetComponent<RectTransform>();
                var currentObj = _elementsHolder.GetChild(currentIter).GetComponent<RectTransform>();
                var currentImg = currentObj.GetComponent<Image>();
                var previousImg = previousObj.GetComponent<Image>();
                currentImg.color = _chosenColor;
                yield return new WaitForSeconds(_timeToWait);
                if (previousObj.sizeDelta.y > currentObj.sizeDelta.y)
                {
                    float tempY = previousObj.sizeDelta.y;
                    previousObj.sizeDelta = new Vector2(25f, currentObj.sizeDelta.y);
                    currentObj.sizeDelta = new Vector2(25f, tempY);
                    previousImg.color = _defaultColor;
                    currentImg.color = _defaultColor;
                    currentIter--;
                }
                else
                {
                    currentIter = 0;
                    currentImg.color = _defaultColor;
                }
            }
        }

        yield return null;
    }

    private IEnumerator BubbleSortCoroutine()
    {
        bool hasSwapped = true;
        while (hasSwapped)
        {
            hasSwapped = false;
            for (int i = 0; i < _count - 1; i++)
            {
                var current = _elementsHolder.GetChild(i).GetComponent<RectTransform>();
                var next = _elementsHolder.GetChild(i + 1).GetComponent<RectTransform>();
                var currentImg = current.GetComponent<Image>();
                var nextImg = next.GetComponent<Image>();
                currentImg.color = _chosenColor;
                yield return new WaitForSeconds(_timeToWait);
                if (current.sizeDelta.y > next.sizeDelta.y)
                {
                    nextImg.color = _chosenColor;
                    yield return new WaitForSeconds(_timeToWait);
                    float tempY = current.sizeDelta.y;
                    current.sizeDelta = new Vector2(25f, next.sizeDelta.y);
                    next.sizeDelta = new Vector2(25f, tempY);
                    hasSwapped = true;
                }

                currentImg.color = _defaultColor;
                nextImg.color = _defaultColor;
            }
        }

        yield return null;
    }
}