using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] Transform shootPoint = null;
    [SerializeField] GameObject bullet = null;
    
    public void ShootBullet(){
        Instantiate(bullet, shootPoint.position, shootPoint.rotation);
    }
}
