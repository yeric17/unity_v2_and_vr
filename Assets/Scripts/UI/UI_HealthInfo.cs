using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_HealthInfo : MonoBehaviour
{
    [SerializeField] Image fill = null;
    [SerializeField] Damagable damagable = null;

    private void Start() {
        damagable.OnChangeHealth += ChangeFill;
    }
    private void ChangeFill(Damagable d){
        fill.fillAmount = d.healthPoints / d.GetMaxHealth();
    }
}
