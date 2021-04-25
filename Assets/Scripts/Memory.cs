using UnityEngine;

public class Memory : MonoBehaviour
{
    [SerializeField] GameObject discardFX = default;
    [SerializeField] float deathFXDuration = 2f;

    public MemoryType type = null;

    public void Discard()
    {
        if (discardFX != null)
        {
            GameObject newFX = Instantiate(discardFX, transform.position, Quaternion.identity) as GameObject;
        }
        Destroy(discardFX, deathFXDuration);

        FindObjectOfType<AudioManager>().Play("faint");

        if (GetComponent<Animator>() != null)
        {
            GetComponent<Animator>().SetTrigger("isDead");
            Destroy(gameObject, deathFXDuration);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}