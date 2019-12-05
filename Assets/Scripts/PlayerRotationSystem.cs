using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerRotationSystem : MonoBehaviour
{
     [SerializeField] Transform YRotation = null;
    [SerializeField] Transform XRotation = null;

    public float VerticalSensitivy = 20f;
    public float HorizontalSensitivy = 20f;

    private Vector3 VecYRotation = Vector3.zero;
    private Vector3 VecXRotation = Vector3.zero;
    private bool canRotate = true;

    private float posGyroInitialY;
    private float posGyroInY;
    private float calibrarEnY;
    private bool once = false;
    private void Start() {
        // Cursor.lockState = CursorLockMode.Locked;
        Input.gyro.enabled = true;
        posGyroInitialY = XRotation.eulerAngles.y;
    }
    private void Update()
    {
        UpdateRotate();
        
    }
    
  
    private void UpdateRotate()
    {
  
        VecYRotation = new Vector3(0, Input.GetAxis("Mouse X") * HorizontalSensitivy *  Time.deltaTime, 0);
        VecXRotation = new Vector3(-Input.GetAxis("Mouse Y") * VerticalSensitivy  *  Time.deltaTime, 0, 0);


        // nextRotation_X es la siguiente rotación en el eje X que se va aplicar
        float nextRotation_X = XRotation.rotation.eulerAngles.x + VecXRotation.x;

        canRotate = !(nextRotation_X > 80 && nextRotation_X < 280);

        if (canRotate)
        {
            YRotation.Rotate(VecYRotation);
            XRotation.Rotate(VecXRotation);
        }

        /*Rotacion();
        Calibrar();
        if (once)
        {
            Aplicar();
            once = false;
        }*/
        
    }

    private void Rotacion()
    {
        XRotation.rotation = Input.gyro.attitude;
        XRotation.Rotate(0, 0, 180f, Space.Self);
        XRotation.Rotate(90, 180, 0, Space.World);
        posGyroInY = XRotation.eulerAngles.y;
    }

    void Calibrar()
    {
        calibrarEnY = posGyroInY - posGyroInitialY; 
    }

    void Aplicar()
    {
        XRotation.Rotate(0, -calibrarEnY, 0, Space.World);
    }
}
