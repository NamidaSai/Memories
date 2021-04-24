using UnityEngine;

public class AIMover : MonoBehaviour
{
    [SerializeField] float wanderRadius = 5f;
    [SerializeField] float wanderCooldown = 5f;

    private float wanderTimer = 0f;

    private void Update()
    {
        if (wanderTimer >= wanderCooldown)
        {
            PickTargetPosition();
            wanderTimer = 0f;
        }
        else
        {
            Tick();
        }
    }

    private void PickTargetPosition()
    {
        GetComponent<Mover>().targetPosition = (Vector2)transform.position + RandomPointOnUnitCircle(wanderRadius);
    }

    private Vector2 RandomPointOnUnitCircle(float radius)
    {
        float angle = Random.Range(0f, Mathf.PI * 2);
        float x = Mathf.Sin(angle) * radius;
        float y = Mathf.Cos(angle) * radius;

        return new Vector2(x, y);
    }

    private void Tick()
    {
        wanderTimer += Time.deltaTime;
    }
}