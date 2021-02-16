using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISwitchPanels : MonoBehaviour
{
    [SerializeField]
    private GameObject[] panelsToSlide;

    public void SlideToTheRight()
    {
        StartCoroutine(Slide(true));
    }

    public void SlideToTheLeft()
    {
        StartCoroutine(Slide(false));
    }

    private IEnumerator Slide(bool right)
    {
        int direction = right ? 1 : -1;
        int distance = Camera.main.pixelWidth;

        List<Vector3> originalPosition = new List<Vector3>();

        for (int i = 0; i < panelsToSlide.Length; i++)
        {
            originalPosition.Add(panelsToSlide[i].transform.position);
        }

        float t = 0;

        while (t <= 1)
        {
            for (int i = 0; i < panelsToSlide.Length; i++)
            {
                panelsToSlide[i].transform.position = originalPosition[i] + new Vector3(distance * t * direction, 0, 0);
            }

            t += Time.deltaTime;
            yield return null;
        }

        for (int i = 0; i < panelsToSlide.Length; i++)
        {
            panelsToSlide[i].transform.position = originalPosition[i] + new Vector3(distance * direction, 0, 0);
        }
    }
}
