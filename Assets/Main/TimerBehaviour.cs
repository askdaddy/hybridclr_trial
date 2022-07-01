using System;
using UnityEngine;

public class TimerBehaviour : MonoBehaviour
{
    static GameObject _instance;

    public static TimerBehaviour AddBehaviour(Action<float> checkAction, float interval)
    {
        if (_instance==null)
        {
            _instance = new GameObject("TimerBehaviourObject");
        }
        TimerBehaviour bt = _instance.AddComponent<TimerBehaviour>();
       

        bt.TimerChecked = checkAction;
        bt.intervel = interval;
        bt.tempIntervel = interval;
        return bt;
    }
 
    Action<float> TimerChecked;

    public float intervel = 1;
    float tempIntervel = 1;


    void Update()
    {
        Check(Time.deltaTime);
    }

    void Check(float deltaTime)
    {

        if (intervel == 0)
        {
            if (TimerChecked != null)
            {
                TimerChecked?.Invoke(deltaTime);
            }
        }
        else
        {
            tempIntervel -= deltaTime;
            if (tempIntervel <= 0)
            {
                tempIntervel = intervel;
                if (TimerChecked != null)
                {
                    TimerChecked?.Invoke(tempIntervel);
                }
            }
        }
    }
}
