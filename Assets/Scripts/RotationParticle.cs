using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationParticle : MonoBehaviour
{
    public Vector3 vRotation = new Vector3(1f, 0, 0); 
     void Update()
    {
        transform.rotation = Quaternion.Euler(vRotation);
    }
}
