using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] float minScaleX = 1f;
    [SerializeField] float maxScaleX = 10f;

    private void Start()
    {
        transform.localScale = new Vector3(Random.Range(minScaleX, maxScaleX), transform.localScale.y, transform.localScale.z);
    }
}