using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linker : MonoBehaviour
{
    [SerializeField] float maxForceIncrease = 2f;
    [SerializeField] float maxSpeedIncrease = 200f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GetComponent<FixedJoint2D>().enabled = true;
            GetComponent<FixedJoint2D>().connectedBody = collision.gameObject.GetComponent<Rigidbody2D>();
            collision.gameObject.GetComponent<Mover>().IncreaseMoveSpeed(maxForceIncrease, maxSpeedIncrease);
        }
    }
}
