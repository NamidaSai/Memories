﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linker : MonoBehaviour
{
    [SerializeField] bool linkingEnabled = true;

    public bool isLinked = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (linkingEnabled)
            {
                GetComponent<FixedJoint2D>().enabled = true;
                GetComponent<FixedJoint2D>().connectedBody = collision.gameObject.GetComponent<Rigidbody2D>();
                collision.gameObject.GetComponent<Mover>().IncreaseMoveSpeed();
                isLinked = true;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}