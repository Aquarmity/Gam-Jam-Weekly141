using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGrid : MonoBehaviour
{

    public LayerMask blockingLayer;
    public LayerMask blockingLayer2;
    public BoxCollider2D BoxCollider;

    public float speed = 0.1f;
    private float time;

    protected virtual void Start()
    {
        time = 1 / speed;
    }


    protected Vector3 Direction = Vector3.zero; 
    protected bool Move(float horizontal, float vertical)
    {
        // make a horizontal move instead of moving diagonaly
        if (horizontal != 0)
        {
            vertical = 0;
        }
        RaycastHit2D hit;
        Vector3 newPosition = Vector3.zero;
        newPosition.x = horizontal;
        newPosition.y = vertical;
        BoxCollider.enabled = false;
        hit = Physics2D.Linecast(transform.position, newPosition, blockingLayer | blockingLayer2);
        BoxCollider.enabled = true;

        if (hit.collider != null)
        {
            return false;
        }

        // if we are finally at the next grid location
        if ((Mathf.Floor(transform.position.x) == transform.position.x )&& (Mathf.Floor(transform.position.y) == transform.position.y))
        {
            // update the direction given input
            Direction.x = horizontal;
            Direction.y = vertical;
        }
        // get unit rate
        Direction *= time;

        // get distance traveled in the frame
        Direction *= Time.deltaTime;

        // travel that distance
        transform.position += Direction;

        

        


        return true;
    }
}
