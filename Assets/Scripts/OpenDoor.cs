using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;


public class OpenDoor : Interactable
{
    public Animator animator;
    readonly int isOpenHash = Animator.StringToHash("isOpen");
    private bool isOpenDoor = false;
    protected override void EnterInteract(PlayerRaycastSystem p)
    {
        base.EnterInteract(p);
        if (p.interactObject == this && Input.GetKeyDown(KeyCode.UpArrow))
        {
            isOpenDoor = !isOpenDoor;
            animator.SetBool(isOpenHash, isOpenDoor);
        }
    }
}
