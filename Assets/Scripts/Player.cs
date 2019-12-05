using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Player : AutoCleanSingleton<Player>
{
    PlayerStatus playerStatus = 0;
    public Image transitionImage = null;
    public float transitionTeleport = 1f;
    public LayerMask platformsLayer = 0;
    float _time = 0;
    [SerializeField] private Camera playerCamera;
    public Transform pointerMovement;
    
    new private void Awake()
    {
        base.Awake();
    }



    private void Update()
    {
        TeleportTransition();
        MovePointer();
    }

    private void TeleportTransition()
    {
        if (playerStatus == PlayerStatus.teleport)
        {
            _time += Time.deltaTime;
            if (_time > transitionTeleport)
            {
                playerStatus = PlayerStatus.none;
                _time = 0;
            }
            else
            {
                float alpha = Mathf.Lerp(transitionImage.color.a, 0, .06f);
                SetTranstition(alpha);
            }
        }
    }

    private void MovePointer()
    {
        RaycastHit hitInfo;
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        Physics.Raycast(ray, out hitInfo, 15f,
            platformsLayer);
        if (hitInfo.collider)
        {
            pointerMovement.GetComponent<NavMeshAgent>().SetDestination(hitInfo.point);
        }
        else
        {
            pointerMovement.GetComponent<NavMeshAgent>().SetDestination((playerCamera.transform.forward * 15f) + transform.position);
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (GetComponent<PortalNeed>().Spend(2f * Vector3.Distance(transform.position, pointerMovement.position)))
            {
                transform.position = pointerMovement.transform.Find("SpawnPosition").GetComponent<Transform>()
                    .position;
                SetTranstition(1f);
                playerStatus = PlayerStatus.teleport;
            }
        }
        
    }

    public void SetStatus(PlayerStatus p ) {
        playerStatus = p;
    }

    public void SetTranstition(float alpha) {
        transitionImage.color = new Color(0,0,0,alpha);
    }
}
public enum PlayerStatus
{
    none,
    teleport,
    damage,
}