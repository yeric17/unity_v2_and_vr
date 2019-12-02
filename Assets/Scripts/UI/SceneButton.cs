using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneButton : MonoBehaviour
{

    [SerializeField] SceneName sceneName = SceneName.MainMenu;

    public void ActionButton() {
        SceneController.Instance.Load((int)sceneName);
    }
}

