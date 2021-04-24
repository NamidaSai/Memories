using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Discarder : MonoBehaviour
{
    [SerializeField] float discardRadius = 0.5f;
    [SerializeField] LayerMask targetLayers = default;

    public void DiscardTarget(Vector2 mouseWorldPosition)
    {
        Collider2D[] allCollidersInArea = Physics2D.OverlapCircleAll(mouseWorldPosition, discardRadius, targetLayers);

        foreach (Collider2D collider2D in allCollidersInArea)
        {
            if (collider2D.gameObject.GetComponent<Linker>().isLinked)
            {
                Destroy(collider2D.gameObject);
                GetComponent<Mover>().DecreaseMoveSpeed();
            }
        }
    }
}
