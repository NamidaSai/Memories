using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linker : MonoBehaviour
{
    [SerializeField] bool linkingEnabled = true;
    [SerializeField] GameObject linkFXPrefab = default;
    [SerializeField] float linkFXDuration = 1f;

    public bool isLinked = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isLinked) { return; }

        if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<PlayerController>().enabled == true)
        {
            if (linkingEnabled)
            {
                GetComponent<FixedJoint2D>().enabled = true;
                GetComponent<FixedJoint2D>().connectedBody = collision.gameObject.GetComponent<Rigidbody2D>();
                GetComponent<Mover>().enabled = false;
                Memory memory = GetComponent<Memory>();
                FindObjectOfType<ScoreManager>().AddToScore(memory.type.GetScore(), memory.type.GetMemType());
                FindObjectOfType<AudioManager>().Play("linked");
                GameObject linkFX = Instantiate(linkFXPrefab, collision.transform.position, collision.transform.rotation) as GameObject;
                ParticleSystem.MainModule newMain = linkFX.GetComponent<ParticleSystem>().main;
                newMain.startColor = collision.gameObject.GetComponentInChildren<SpriteRenderer>().color;
                linkFX.transform.parent = collision.transform;
                linkFX.transform.localScale = collision.transform.localScale;
                Destroy(linkFX, linkFXDuration);
                isLinked = true;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        if (collision.gameObject.tag == "Circle")
        {
            GetComponent<FixedJoint2D>().enabled = true;
            GetComponent<FixedJoint2D>().connectedBody = collision.gameObject.GetComponent<Rigidbody2D>();
            GetComponent<Mover>().enabled = false;
            GameObject linkFX = Instantiate(linkFXPrefab, collision.transform.position, collision.transform.rotation) as GameObject;
            ParticleSystem.MainModule newMain = linkFX.GetComponent<ParticleSystem>().main;
            newMain.startColor = collision.gameObject.GetComponentInChildren<SpriteRenderer>().color;
            linkFX.transform.parent = collision.transform;
            linkFX.transform.localScale = collision.transform.localScale;
            Destroy(linkFX, linkFXDuration);
            isLinked = true;
        }
    }
}
