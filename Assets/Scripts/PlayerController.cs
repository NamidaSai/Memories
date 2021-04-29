using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector2 mouseWorldPosition;

    private void Start()
    {
        StartCoroutine(LateStart());
    }

    IEnumerator LateStart()
    {
        yield return new WaitForSeconds(0.1f);
        FindObjectOfType<AudioManager>().Play("start");
    }

    private void Update()
    {
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            Move();
        }

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Discard();
        }
    }

    private void Move()
    {
        GetComponent<Mover>().SetTargetPosition(mouseWorldPosition);
        FindObjectOfType<AudioManager>().Play("move");
    }

    private void Discard()
    {
        GetComponent<Discarder>().DiscardTarget(mouseWorldPosition);
    }

    private void OnReload()
    {
        Debug.Log("Should reload");
        FindObjectOfType<SceneLoader>().ResetScene();
    }
}
