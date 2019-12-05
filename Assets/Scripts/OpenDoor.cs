using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;


public class OpenDoor : Interactable
{
    private bool isOpenDoor = false;
    private Animator animator;
    private int isOpenHash = Animator.StringToHash("isOpen");

    private void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    protected override void EnterInteract(PlayerRaycastSystem p)
    {
        base.EnterInteract(p);
        if (p.interactObject == this && Input.GetKeyDown(KeyCode.UpArrow) && Vector3.Distance(p.transform.position,transform.position) < 5f)
        {
            isOpenDoor = !isOpenDoor;
            animator.SetBool(isOpenHash,isOpenDoor);
        }
    }
}
