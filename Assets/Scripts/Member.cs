using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Member{
    private float hunger = 100;
    private float sleepy = 100;
    private float condition = 100;

    public float Sleepy
    {
        get
        {
            return sleepy;
        }

        set
        {
            sleepy = Mathf.Clamp(value,0,100);
        }
    }

    public float Condition
    {
        get
        {
            return condition;
        }

        set
        {
            condition = Mathf.Clamp(value, 0, 100);
        }
    }

    public float Hunger
    {
        get
        {
            return hunger;
        }

        set
        {
            hunger = Mathf.Clamp(value, 0, 100);
        }
    }
}
