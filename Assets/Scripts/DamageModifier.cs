using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DamageModifier : MonoBehaviour
{
    [SerializeField] string enemy = "Player";
     [SerializeField] float healtAmount = 10f;
    protected void Init() {
        GetComponent<Collider>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag(enemy)){
            if(other.gameObject.GetComponent<Damagable>()){
                other.gameObject.GetComponent<Damagable>().SetHealth(healtAmount);
            }
        }
    }
}
