using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    public int front = 1;
    public int back = 6;
    public int left = 4;
    public int right = 3;
    public int top = 5;
    public int bottom = 2;

    public void Rrotate()
    {
        int storage = bottom;
        bottom = right;
        right = top;
        top = left;
        left = storage;
    }
    public void Lrotate()
    {
        int storage = bottom;
        bottom = left;
        left = top;
        top = right;
        right = storage;
    }
    public void Urotate()
    {
        int storage = bottom;
        bottom = back;
        back = top;
        top = front;
        front = storage;
    }
    public void Drotate()
    {
        int storage = bottom;
        bottom = front;
        front = top;
        top = back;
        back = storage;
    }


}
