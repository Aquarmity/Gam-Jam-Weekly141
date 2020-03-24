using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MovingObject 
{


    public int max_Health = 100;
    public int min_Health = 0;
    public int health = 100;
    public LayerMask enemyLayer;

    public GameObject healthbar;

    private Die die;
    private Slider slider;




    protected override void Start()
    {
        base.Start();
        die = GetComponent<Die>();
        slider = healthbar.GetComponent<Slider>();
        slider.maxValue = max_Health;
        slider.minValue = min_Health;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = health;

        if (moving == true)
        {
            return;
        }
        //Get input from the input manager, round it to an integer and store in horizontal to set x axis move direction
        int horizontal = (int)Input.GetAxisRaw("Horizontal");

        //Get input from the input manager, round it to an integer and store in vertical to set y axis move direction
        int vertical = (int)Input.GetAxisRaw("Vertical");

        //Check if moving horizontally, if so set vertical to zero.
        if (horizontal != 0)
        {
            vertical = 0;
        }

        //Check if we have a non-zero value for horizontal or vertical
        if (horizontal != 0 || vertical != 0)
        {
            //Call AttemptMove passing in the generic parameter Wall, since that is what Player may interact with if they encounter one (by attacking it)
            //Pass in horizontal and vertical as parameters to specify the direction to move Player in.
            moving = true;
            if (AttemptMove<Wall>(horizontal, vertical))
            {
                if (horizontal > 0 )
                {
                    die.Rrotate();
                } else if (horizontal < 0)
                {
                    die.Lrotate();
                } else if (vertical > 0)
                {
                    die.Urotate();
                } else if (vertical < 0)
                {
                    die.Drotate();
                }
            }
            

        }

        
        //print(message: die.top);
    }


    protected override void OnCantMove<T>(T component)
    {
       
    }
}
