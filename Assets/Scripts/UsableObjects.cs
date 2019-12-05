using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsableObjects : Interactable
{
 [SerializeField] Rigidbody _rigidbody = null;

    float timeToThrow = 1f;
    
    public float _time = 0;
    float distance = 2f;
    float maxDistance = 12f;

    public float chargeForce = 0;
    
    public float maxThrowForce = 10f;

    private void Awake() {
        PlayerRaycastSystem.OnEnterInteraction += Move;
    }
  

    public void Move(PlayerRaycastSystem p)
    {
        Debug.Log("Enemigo");
        if (p.interactObject == this)
        {
            float smoothSpeed = 6.8f;

            Vector3 finalPosition = (p.ray.direction * distance) + p.ray.origin;

            Vector3 smoothPosition = Vector3.Lerp(transform.position, finalPosition, smoothSpeed * Time.deltaTime);

            _rigidbody.MovePosition(smoothPosition);
            _rigidbody.useGravity = false;
        }
        
    }

    private void OnDisable() {
        PlayerRaycastSystem.OnEnterInteraction -= Move;
    }
}
