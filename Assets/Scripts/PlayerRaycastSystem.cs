using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerRaycastSystem : MonoBehaviour {
    public Interactable interactObject { get; private set; }
    [SerializeField] Camera cameraPlayer = null;
    [SerializeField] float rayDistance = 2f;
    [SerializeField] LayerMask interactiveLayer = 0;
    [SerializeField] private MiraController playerMira;
    [SerializeField] Transform firePoint;
    
    private Transform cameraTransform;
    
    public Color rayColor = Color.green;
    public Ray ray { get; private set; }
    
    public static event Action<PlayerRaycastSystem> OnEnterInteraction = delegate {  }; 
    public static event Action<PlayerRaycastSystem> OnExitInteraction = delegate {  }; 
    private void Start()
    {
        cameraTransform = cameraPlayer.transform;
        playerMira = GetComponent<MiraController>();
    }

    void Update()
    {
        RayCasting();
    }


    void RayCasting()
    {
        RaycastHit hit;
        
        ray = new Ray(cameraTransform.position, cameraTransform.forward);

        Physics.Raycast(ray, out hit, rayDistance, interactiveLayer.value);

        Debug.DrawRay(ray.origin, ray.direction * rayDistance, rayColor);

        if(hit.collider){
            if(interactObject != hit.collider.GetComponent<Interactable>()){
                interactObject = hit.collider.GetComponent<Interactable>();
            }
            if (interactObject)
            {
                OnEnterInteraction(this);
                playerMira.SetSizePoint(10f);
            }
        }
        else
        {
            if (interactObject)
            {
                OnExitInteraction(this);
                interactObject = null;
            }
        }

    }
}