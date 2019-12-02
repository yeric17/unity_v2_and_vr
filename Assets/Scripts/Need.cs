using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public  class Need : MonoBehaviour, IWearable
{
    public  float value {get;  protected set; }
    public float min;
    public float max;
    public event Action<Need> OnChange = delegate{};

    public virtual void Restore(float amount){
        value = Mathf.Clamp(value + amount, min, max);
        OnChange(this);
    }
    public virtual bool Spend(float amount) {
        Debug.Log("Current value: " + value);
        if((value - amount) < min) {
            return false;
        }
        else {
            value -= amount;
            OnChange(this);
            return true;
        }  
    }

}
