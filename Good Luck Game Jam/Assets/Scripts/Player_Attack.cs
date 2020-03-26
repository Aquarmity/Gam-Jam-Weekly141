using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    bool attacking = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Chip Stack")
        {
            if (attacking == true)
            {
                collision.GetComponent<Enemy_Health>().health -= 1;
                attacking = false;
            }
        }
    }

    public Player pattack;
    public BoxCollider2D collider_attack;
    // Start is called before the first frame update
    void Start()
    {
        collider_attack = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            attacking = true;
        }

        switch (pattack.dir)
        {
            case Player.Facing.left:
                collider_attack.offset = new Vector2(-1, 0);
                break;
            case Player.Facing.right:
                collider_attack.offset = new Vector2(1, 0);
                break;
            case Player.Facing.north:
                collider_attack.offset = new Vector2(0, 1);
                break;
            case Player.Facing.south:
                collider_attack.offset = new Vector2(0, -1);
                break;
        }
        
    }

  
}
