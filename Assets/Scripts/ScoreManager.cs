using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] int currentScore = 0;
    [SerializeField] int scoreMultiplier = 2;

    private List<MemType> typesHeld = new List<MemType>();
    private List<MemType> uniqueTypesHeld = new List<MemType>();

    public int GetScore()
    {
        int comboScore = uniqueTypesHeld.Count * scoreMultiplier;
        if (comboScore == 0) { comboScore = 1; }
        return currentScore * comboScore;
    }

    public void AddToScore(int scoreValue, MemType type)
    {
        currentScore += scoreValue;
        typesHeld.Add(type);

        int typeCount = 1;

        foreach (MemType memType in typesHeld)
        {
            if (memType == type)
            {
                if (typeCount > 1) { return; }
                else { typeCount++; }
            }
        }

        uniqueTypesHeld.Add(type);

        // Debug.Log("Types Held: " + typesHeld.Count);
        // Debug.Log("Unique Held: " + uniqueTypesHeld.Count);
    }

    public void RemoveFromScore(int scoreValue, MemType type)
    {
        currentScore -= scoreValue;

        typesHeld.Remove(type);

        foreach (MemType memType in typesHeld)
        {
            if (memType == type)
            {
                return;
            }
        }

        uniqueTypesHeld.Remove(type);

        // Debug.Log("Types Held: " + typesHeld.Count);
        // Debug.Log("Unique Held: " + uniqueTypesHeld.Count);
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}