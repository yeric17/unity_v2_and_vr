using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class UIRaycast : MonoBehaviour
{
    [SerializeField] Camera playerCamera = null;
    [SerializeField] EventSystem eventSystem = null;
    [SerializeField] MiraController miraController = null;
    GameObject currentTarget = null;
    
    public static event Action<UIRaycast> OnFocusInfo = delegate{};
    public static event Action<UIRaycast> OnExitInfo = delegate{}; 

    private void Start()
    {
        if (playerCamera == null)
        {
            playerCamera = GameObject.Find("PlayerCamera").GetComponent<Camera>();
        }
        if (eventSystem == null)
        {
            eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        }
    }

    private void Update()
    {

        PointerEventData pointer = new PointerEventData(eventSystem);
        pointer.position = new Vector2(playerCamera.pixelWidth / 2, playerCamera.pixelHeight / 2);
        List<RaycastResult> raycasts = new List<RaycastResult>();

        eventSystem.RaycastAll(pointer, raycasts);

        if (raycasts.Count > 0)
        {
            // Debug.Log(raycasts[0].gameObject.name);
            if (!currentTarget)
            {
                currentTarget = raycasts[0].gameObject;
            }
            else if (currentTarget != raycasts[0].gameObject) {
                ExitTarget(pointer);
                currentTarget = raycasts[0].gameObject;
            }
            if (currentTarget) { 
                currentTarget.GetComponent<Selectable>().OnPointerEnter(pointer);
                if (currentTarget.GetComponent<InfoElement>())
                {
                    currentTarget.GetComponent<InfoElement>().Show();
                }
            }
            miraController.SetSizePoint(2f);

        }
        else
        {
            ExitTarget(pointer);
        }

        if(Input.GetKey(KeyCode.UpArrow) && currentTarget != null){
            currentTarget.GetComponent<Selectable>().OnPointerUp(pointer);
        }
    }

    private void ExitTarget(PointerEventData pointer) {
        if (currentTarget)
        {
            currentTarget.GetComponent<Selectable>().OnPointerExit(pointer);
            if (currentTarget.GetComponent<InfoElement>())
            {
                currentTarget.GetComponent<InfoElement>().Hide();
            }
            currentTarget = null;
        }
        miraController.SetSizePoint(1f);
    }


}
