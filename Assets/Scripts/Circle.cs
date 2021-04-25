using UnityEngine;

public class Circle : MonoBehaviour
{
    [SerializeField] float minScale = 2f;
    [SerializeField] float maxScale = 5f;
    [SerializeField] Color[] colorOptions = default;
    private void Start()
    {
        float newScaleX = Random.Range(minScale, maxScale);
        float newScaleY = newScaleX;
        transform.localScale = new Vector3(newScaleX, newScaleY, transform.localScale.z);

        GetComponent<SpriteRenderer>().color = colorOptions[Random.Range(0, colorOptions.Length)];
    }
}