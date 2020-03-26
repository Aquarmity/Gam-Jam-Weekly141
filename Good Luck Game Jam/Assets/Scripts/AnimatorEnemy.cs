using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorEnemy : MonoBehaviour
{
    Animator animator;
    public int dir = 0;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetInteger("direction",dir);
    }
}
