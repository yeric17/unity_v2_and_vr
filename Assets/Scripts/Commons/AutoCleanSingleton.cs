using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCleanSingleton<T> : MonoBehaviour where T : MonoBehaviour
{

    private static T _instance;

    public static T Instance {

        get {
            if (_instance == null)
            {
               // Debug.Log("Instance es null");
                _instance = FindObjectOfType<T>();
                if (_instance == null)
                {
                    _instance = new GameObject(name: "Instance of " + typeof(T)).AddComponent<T>();
                }
            }
            
            return _instance;
        }
            
    }
    protected void Awake() {
        // Debug.Log("Despertando...");
        if (_instance != null) {
           //  Debug.Log("Existe otra instancia");
            Destroy(this.gameObject);   
        }
    }
}
