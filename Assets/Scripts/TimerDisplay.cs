using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerDisplay : MonoBehaviour
{
    float timerDuration;
    float currentTime;

    float startX, startY;

    private void Start()
    {
        startX = GetComponent<RectTransform>().localScale.x;
        startY = GetComponent<RectTransform>().localScale.y;
    }

    private void Update()
    {
        GetComponent<RectTransform>().localScale = new Vector3(GetFraction() * startX, startY, 1f);
    }

    public float GetFraction()
    {
        timerDuration = FindObjectOfType<Timer>().timerDuration;
        currentTime = FindObjectOfType<Timer>().currentTime;
        return (timerDuration - currentTime) / timerDuration;
    }
}
