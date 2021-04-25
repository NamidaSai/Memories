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
            ParticleSystem.MainModule newMain = newFX.GetComponent<ParticleSystem>().main;
            newMain.startColor = type.GetColor();
            float targetScale = type.GetScale() + newFX.transform.localScale.x;
            newFX.transform.localScale = new Vector3(targetScale, targetScale, 1f);
            Destroy(newFX, deathFXDuration);
        }

        FindObjectOfType<AudioManager>().Play("faint");
        Destroy(gameObject);
    }
}