using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class UI_Need : MonoBehaviour
{
    [SerializeField] Image fillImage = null;
    [SerializeField] Image totalImage = null;
    [SerializeField] Need need = null;
    private void Start() {
        fillImage.fillAmount = 1;
        totalImage.fillAmount = 1;
        need.OnChange += UpdateFill;
    }
    
    public void UpdateFill(Need n) {
        fillImage.fillAmount = Mathf.Lerp(fillImage.fillAmount, need.value / need.max, .1f);
    }
    
}
