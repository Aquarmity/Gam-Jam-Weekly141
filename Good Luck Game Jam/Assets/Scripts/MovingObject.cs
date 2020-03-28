using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovingObject : MonoBehaviour
{

    public float moveTime = 0.1f;
    public LayerMask blockingLayer;
    public LayerMask blockingLayer2;

    private BoxCollider2D boxCollider;
    private Rigidbody2D rb2D;
    protected bool moving = false;

    private float inverseMoveTime;

    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb2D = GetComponent<Rigidbody2D>();

        inverseMoveTime = 1f / moveTime;
    }
    protected bool Move(int xDir, int yDir, out RaycastHit2D hit)
    {
        Vector2 start = transform.position;
        
        Vector2 end = start + new Vector2(xDir, yDir);


        boxCollider.enabled = false;

        hit = Physics2D.Linecast(start, end, blockingLayer | blockingLayer2);
        boxCollider.enabled = true;

        if (hit.transform == null || hit.collider.isTrigger)
        {
            StartCoroutine(SmoothMovement(end));
            return true;
        }
        return false;
        

    }


    protected IEnumerator SmoothMovement(Vector3 end)
    {
        float sqrDistanceRemaining = (transform.position - end).sqrMagnitude;

        while (sqrDistanceRemaining > float.Epsilon)
        {
            Vector3 newPosition = Vector3.MoveTowards(rb2D.position, end, inverseMoveTime * Time.deltaTime);
            rb2D.MovePosition(newPosition);
            sqrDistanceRemaining = (transform.position - end).sqrMagnitude;
            yield return null;
        }
        moving = false;
    }

    protected virtual bool AttemptMove<T>(int xDir, int yDir)
        where T : Component
    {
        RaycastHit2D hit;
        bool canMove = Move(xDir, yDir, out hit);
        if (hit.transform == null)
        {
            return true;
        }

        T hitComponent = hit.transform.GetComponent<T>();
        if (!canMove && hitComponent != null)
        {
            OnCantMove(hitComponent);
        }
        moving = false;
        return false;
    }


    protected abstract void OnCantMove<T>(T component)
        where T : Component;



}
