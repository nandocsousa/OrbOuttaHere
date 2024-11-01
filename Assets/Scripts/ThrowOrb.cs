using UnityEngine;

public class ThrowOrb : MonoBehaviour
{
    public Rigidbody2D orbPrefab;
    private Rigidbody2D cloneOrb;

    private float speed = 8f;

    private Vector2 targetPosition;
    private Vector2 currentDirection;

    public bool isAlive = false;

    private GameObject canvas;
    private MovesCounter movesCounter;

    private void Start()
    {
        canvas = GameObject.FindWithTag("Canvas");
        movesCounter = canvas.GetComponent<MovesCounter>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isAlive)
            {
                CloneAndThrow();
            }
            else if (movesCounter.CanMove())
            {
                targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                currentDirection = (targetPosition - cloneOrb.position).normalized;

                movesCounter.IncrementMoves();
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

        movesCounter.IncrementMoves();
    }

    void MoveOrbTowardsTarget()
    {
        cloneOrb.MovePosition(cloneOrb.position + currentDirection * speed * Time.deltaTime);
    }
}
