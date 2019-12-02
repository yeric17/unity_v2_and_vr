using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    private void Awake()
    {
        PlayerRaycastSystem.OnExitInteraction += ExitInteract;
        PlayerRaycastSystem.OnEnterInteraction += EnterInteract;
    }

    protected virtual void EnterInteract(PlayerRaycastSystem p)
    {
        Debug.Log("Interactuando con: " + gameObject.name);
    }

    protected virtual void ExitInteract(PlayerRaycastSystem p)
    {
        Debug.Log("Saliento de la interacción" +  gameObject);
    }

    private void OnDestroy()
    {
        PlayerRaycastSystem.OnExitInteraction -= ExitInteract;
        PlayerRaycastSystem.OnEnterInteraction -= EnterInteract;
    }
}


