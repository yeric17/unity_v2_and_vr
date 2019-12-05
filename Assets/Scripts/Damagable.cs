using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Damagable : MonoBehaviour
{
    public float healthPoints {get; private set;}
    [SerializeField] private float maxHealthPoints = 100f;
    [SerializeField] private float minHealthPoints = 0f;
    public bool IsDead => healthPoints <= minHealthPoints;
    public event Action<Damagable> OnChangeHealth = delegate {};


    private void Start() {
        healthPoints = maxHealthPoints;
    }
    public void SetHealth(float amount) {
        float temp = healthPoints;
        temp -= amount;
        healthPoints = Mathf.Clamp(temp, minHealthPoints, maxHealthPoints);
        OnChangeHealth(this);
        Debug.Log(healthPoints);
    }

    public float GetMaxHealth(){
        return maxHealthPoints;
    }

}
