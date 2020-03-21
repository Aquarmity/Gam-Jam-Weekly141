using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipStack : MovingObject
{
    
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        Random.InitState(System.Environment.TickCount);



    }

    // Update is called once per frame
    void Update()
    {

        if (moving == false)
        {
            
            RandomMovement(out int horizontal,out int vertical);
            moving = true;
            AttemptMove<Wall>(horizontal, vertical);
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
    protected override void OnCantMove<T>(T component)
    {

    }

}
