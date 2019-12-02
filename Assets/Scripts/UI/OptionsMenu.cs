using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
 
    [SerializeField] AudioMixer audioMixer = null;
    [SerializeField] GameObject menuPanel = null;
    [SerializeField] GameObject optionsPanel = null;

    public float defaultVolume = 5f;

    private void Start()
    {
        audioMixer.SetFloat("volume", defaultVolume);
    }

    public void SetVolume(float v) {
        Debug.Log(gameObject.name);
        audioMixer.SetFloat("volume", v);
    }

    public void SetGraphics(int idx) {
        QualitySettings.SetQualityLevel(idx);
    }

    public void ActiveOptions(){
        menuPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }
    public void ActiveMenu(){
        menuPanel.SetActive(true);
        optionsPanel.SetActive(false);
    }
    public float GetVolume() {
        float volume = 0;
        audioMixer.GetFloat("volume", out volume);
        return volume;
    }
}
