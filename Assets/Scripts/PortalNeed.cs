using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalNeed : Need
{
    public float restorePerSecond = 1f;

    private void Update() {
        Restore(restorePerSecond * Time.deltaTime);
    }

    
    private void Start() {
        value = max;
    }
}
