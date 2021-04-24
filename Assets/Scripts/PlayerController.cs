using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector2 mouseWorldPosition;

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
    }

    private void Discard()
    {
    }
}
