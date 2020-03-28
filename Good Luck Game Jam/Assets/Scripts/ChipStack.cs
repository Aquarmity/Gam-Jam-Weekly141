using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipStack : MovingObject
{

    public GameObject player = null;
    public float attackTimer = 0;
    public enum States {Wandering, Following, Attacking };
    public States state = States.Wandering;

    public GameObject animator_child;



    private Vector3 selfTransform;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        Random.InitState(System.Environment.TickCount);



    }

    // Update is called once per frame
   

    private int lastDir = 0;
    private void Update()
    {
        selfTransform = GetComponent<Transform>().position;

        if ((player.transform.position - selfTransform).magnitude < 2)
        {
            state = States.Attacking;
            switch (lastDir) {
                case 0:
                    animator_child.GetComponent<AnimatorEnemy>().dir = 0;
                    break;
                case 1:
                    animator_child.GetComponent<AnimatorEnemy>().dir = 1;
                    break;
                case 2:
                    animator_child.GetComponent<AnimatorEnemy>().dir = 2;
                    break;
                case 3:
                    animator_child.GetComponent<AnimatorEnemy>().dir = 3;
                    break;
                case 4:
                    animator_child.GetComponent<AnimatorEnemy>().dir = 4;
                    break;

            }

        }
        else if ((player.transform.position - selfTransform).magnitude < 4)
        {
            state = States.Following;
            animator_child.GetComponent<AnimatorEnemy>().dir = 0;
        }
        else
        {
            state = States.Wandering;
            animator_child.GetComponent<AnimatorEnemy>().dir = 0;
        }

        if (moving == false)
        {
            if (state == States.Wandering)
            {

                RandomMovement(out int horizontal, out int vertical);
                moving = true;
                AttemptMove<Wall>(horizontal, vertical);
            }
            else if (state == States.Following)
            {
                DirectedMovement(out int horizontal, out int vertical, player.transform.position);
                moving = true;
                AttemptMove<Wall>(horizontal, vertical);

            }
            else if (state == States.Attacking)
            {
                attackTimer = attackTimer - Time.deltaTime;
                if (attackTimer < 0)
                {
                    player.GetComponent<Player>().health -= 5;
                    attackTimer = 2;
                }
            }
            if (state != States.Attacking)
            {
                attackTimer = 1f;
            }
        }
    }
    protected void RandomMovement(out int horizontal, out int vertical)
    {
        int direction = Random.Range(1, 5);

        horizontal = 0;
        vertical = 0;
        switch (direction)
        {
            case 1:
                horizontal = 1;
                break;
            case 2:
                horizontal = -1;
                break;
            case 3:
                vertical = 1;
                break;
            case 4:
                vertical = -1;
                break;

        }
    }
    protected void DirectedMovement(out int horizontal, out int vertical, Vector3 playerTransform)
    { 
        if (playerTransform.x > selfTransform.x)
        {
            horizontal = 1;
            lastDir = 2;
        } else if (playerTransform.x < selfTransform.x)
        {
            horizontal = -1;
            lastDir = 1;
        } else
        {
            horizontal = 0;
        }
        if (playerTransform.y > selfTransform.y)
        {
            vertical = 1;
            lastDir = 3;
        }
        else if (playerTransform.y < selfTransform.y)
        {
            vertical = -1;
            lastDir = 4;
        }
        else
        {
            vertical = 0;
        }

        if (vertical != 0)
        {
            horizontal = 0;
        }


    }
    protected override void OnCantMove<T>(T component)
    {

    }
}
