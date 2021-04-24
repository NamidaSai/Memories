using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [Tooltip("in seconds")]
    [SerializeField] float timerDuration = 5f;

    float currentTime = 0f;
    bool maxTimeReached = false;
    bool timerStarted = false;

    private void Update()
    {
        if (maxTimeReached || !timerStarted) { return; }

        if (currentTime < timerDuration)
        {
            Tick();
        }
        else
        {
            maxTimeReached = true;
            Debug.Log("Max Time Reached");
        }
    }

    private void Tick()
    {
        currentTime += Time.deltaTime;
    }

    public void StartTimer()
    {
        timerStarted = true;
    }
}
