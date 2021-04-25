using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [Tooltip("in seconds")]
    [SerializeField] public float timerDuration = 5f;
    [SerializeField] GameObject gameOverScreen = default;
    [SerializeField] GameObject timerDisplay = default;

    [HideInInspector]
    public float currentTime = 0f;
    bool maxTimeReached = false;
    bool timerStarted = false;

    private void Start()
    {
        StartCoroutine(StartTimer());
    }

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
            gameOverScreen.SetActive(true);
            FindObjectOfType<PlayerController>().enabled = false;
            FindObjectOfType<PlayerController>().GetComponent<Mover>().targetPosition = FindObjectOfType<PlayerController>().transform.position;
            timerDisplay.SetActive(false);
        }
    }

    private void Tick()
    {
        currentTime += Time.deltaTime;
    }

    IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(2f);
        timerStarted = true;
    }
}
