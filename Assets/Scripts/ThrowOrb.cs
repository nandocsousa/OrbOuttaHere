using UnityEngine;

public class ThrowOrb : MonoBehaviour
{
    public Rigidbody2D orbPrefab;
    private Rigidbody2D cloneOrb;

    public float speed = 7f;

    private Vector2 targetPosition;
    private Vector2 currentDirection;

    public bool isAlive = false;

    private GameObject canvas;
    private MovesCounter movesCounter;

    private Animator animator;

    private void Start()
    {
        canvas = GameObject.FindWithTag("Canvas");
        movesCounter = canvas.GetComponent<MovesCounter>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isAlive && movesCounter.CanMove())
            {
                CloneAndThrow();

                animator.SetBool("isThrowing", true);
            }
            else if (isAlive && movesCounter.CanMove())
            {
                targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                currentDirection = (targetPosition - cloneOrb.position).normalized;

                movesCounter.IncrementMoves();
            }
        }
        else animator.SetBool("isThrowing", false);
    }

    private void FixedUpdate()
    {
        if (isAlive)
        {
            MoveOrbTowardsTarget();
            cloneOrb.transform.Rotate(0, 0, 8);
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
