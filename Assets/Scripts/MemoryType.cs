using UnityEngine;

[CreateAssetMenu(fileName = "MemoryType", menuName = "Memories/MemoryType", order = 0)]
public class MemoryType : ScriptableObject
{
    [SerializeField] Color[] colorOptions = default;
    [SerializeField] float minScale = 1f;
    [SerializeField] float maxScale = 2f;
    [SerializeField] float minWeight = 1f;
    [SerializeField] float maxWeight = 2f;
    [SerializeField] int minScore = 5;
    [SerializeField] int maxScore = 10;

    public float GetScale()
    {
        return Random.Range(minScale, maxScale);
    }

    public float GetWeight()
    {
        return Random.Range(minWeight, maxWeight);
    }

    public int GetScore()
    {
        return Random.Range(minScore, maxScore);
    }

    public Color GetColor()
    {
        return colorOptions[Random.Range(0, colorOptions.Length)];
    }
}