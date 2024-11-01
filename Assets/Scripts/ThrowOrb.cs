using UnityEngine;

public class ThrowOrb : MonoBehaviour
{
    public Rigidbody2D orbPrefab;
    private Rigidbody2D cloneOrb;

    private float speed = 8f;

    private Vector2 targetPosition;
    private Vector2 currentDirection;

    public bool isAlive = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isAlive)
            {
                CloneAndThrow();
            }
            else
            {
                targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                currentDirection = (targetPosition - cloneOrb.position).normalized;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isAlive)
        {
            MoveOrbTowardsTarget();
        }
    }

    void CloneAndThrow()
    {
        cloneOrb = Instantiate(orbPrefab, transform.position, Quaternion.identity);
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        currentDirection = (targetPosition - (Vector2)transform.position).normalized;
        cloneOrb.velocity = (targetPosition - (Vector2)transform.position).normalized * speed;
        isAlive = true;
    }

    void MoveOrbTowardsTarget()
    {
        cloneOrb.MovePosition(cloneOrb.position + currentDirection * speed * Time.deltaTime);
    }
}
