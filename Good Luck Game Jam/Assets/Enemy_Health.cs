using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Health : MonoBehaviour
{

    public float health = 10;
    public float maxHealth = 10;
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {



        image.fillAmount = health / maxHealth;
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
