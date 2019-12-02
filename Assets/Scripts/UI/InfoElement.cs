using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoElement : MonoBehaviour
{
    [SerializeField] GameObject _panel = null;


    private void Start() {
        Hide();
    }
    public void Show(){
        _panel.SetActive(true);
    }
    public void Hide() {
        _panel.SetActive(false);
    }

}
