using UnityEngine;

public class Ager : MonoBehaviour
{
    [SerializeField] bool isAging = true;
    [SerializeField] float scaleUpFactor = 0.1f;
    [SerializeField] float maxScale = 5f;

    private void Update()
    {
        if (!isAging) { return; }

        if (transform.localScale.x < maxScale)
        {
            float targetX = transform.localScale.x + Time.deltaTime * scaleUpFactor;
            float targetY = transform.localScale.y + Time.deltaTime * scaleUpFactor;

            transform.localScale = new Vector3(targetX, targetY, 1f);
        }
    }
}