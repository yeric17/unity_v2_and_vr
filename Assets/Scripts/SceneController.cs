using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneController : AutoCleanSingleton<SceneController>
{
    [SerializeField] TextMeshProUGUI percentageText = null;
    [SerializeField] Image fillImage = null;
    [SerializeField] GameObject loaderPanel = null;
    public float delay = 3f;
    bool isChangeScene = false;
    bool isLoading = false;
    float _time = 0;
    float progress = 0;
    private void OnEnable()
    {
        SceneManager.activeSceneChanged += OnChangeScene;
    }

    private void Update()
    {

        // si esta cargando llama la función UpdateProgress para actualizar el UI del Loader
        if (isLoading)
        {
            UpdateProgress(.6f);
        }
        // Se verifica si la escena se ha cambiado completamente
        if (isChangeScene == true)
        {
            // se empieza a tomar en cuenta el tiempo de retraso
            _time += Time.deltaTime;
            if (_time > delay)
            {
                isLoading = false;
                isChangeScene = false;
                loaderPanel.SetActive(false);
                progress = 0;
            }
        }

        if (Input.GetKey(KeyCode.W))
        {
            Load(1);
        }
    }

    // Esta funcion es la que se llama desde los botones
    public void Load(int scene)
    {
        // Activa el panel de carga
        loaderPanel.SetActive(true);
        // Empieza el estado de cargando
        isLoading = true;
        // se inicializa el tiempo que ayuda a controlar el retraso
        _time = 0;
        // Se carga la escena de manera asyncrona
        StartCoroutine(AsyncLoad(scene));
    }
    IEnumerator AsyncLoad(int scene)
    {
        // Se asigna la operacion asincrona para verificar el progreso
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene);
        while (!operation.isDone)
        {
            // Se asigna el progreso teniendo en cuenta que operation.progress solo llega hasta .9

            progress = Mathf.Clamp01(operation.progress / .9f);
            yield return null;
        }
    }

    // UpdateProgress actualiza el UI del Loader
    private void UpdateProgress(float lerpFactor)
    {

        float localProgress = Mathf.Lerp(fillImage.fillAmount, progress, lerpFactor);

        percentageText.text = (int)(localProgress * 100) + "%";
        fillImage.fillAmount = localProgress;
    }

    // FindReference busca las referencias de los objetos y componentes del UI
    private void FindReference()
    {
       
        percentageText = GameObject.Find("PercentageText").GetComponent<TextMeshProUGUI>();
        fillImage = GameObject.Find("LoaderFillImage").GetComponent<Image>();
        loaderPanel = GameObject.Find("PanelLoader");
    }

    // OnChangeScene verifica cuando una scena ha sido cargada totalmente
    private void OnChangeScene(Scene from, Scene to)
    {
        // Busca las referencias antes de ocultar la pantalla de carga
        FindReference();
        isChangeScene = true;
    }
    public void Exit(){
        Application.Quit();
    }
}

public enum SceneName
{
    MainMenu,
    Level1
}
