using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : DamageModifier
{
   
    [SerializeField] float velocity = 10f;
    public float lifeTime = 4f;

    private void Start() {
        Init();
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().velocity = transform.forward * velocity;
        Destroy(gameObject, lifeTime);
    }

}
