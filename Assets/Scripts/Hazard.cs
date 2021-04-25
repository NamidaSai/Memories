using UnityEngine;

public class Hazard : MonoBehaviour
{
    [SerializeField] float minScale = 1f;
    [SerializeField] float maxScale = 4f;

    private void Start()
    {
        float newScaleX = Random.Range(minScale, maxScale);
        float newScaleY = newScaleX;
        transform.localScale = new Vector3(newScaleX, newScaleY, transform.localScale.z);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Memory")
        {
            if (!other.gameObject.GetComponent<Linker>().isLinked)
            {
                return;
            }

            if (other.gameObject.GetComponent<FixedJoint2D>().connectedBody.gameObject.tag == "Player")
            {
                if (FindObjectOfType<PlayerController>().enabled == false)
                {
                    return;
                }

                MemoryType type = other.gameObject.GetComponent<Memory>().type;
                FindObjectOfType<ScoreManager>().RemoveFromScore(type.GetScore(), type.GetMemType());
            }

            other.gameObject.GetComponent<Memory>().Discard();
        }
    }
}