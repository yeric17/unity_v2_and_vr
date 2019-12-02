using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] Slider sliderVolume = null;
    [SerializeField] OptionsMenu optionsMenu = null;
   
    // Start is called before the first frame update
    void Start()
    {
        sliderVolume = GetComponent<Slider>();
        sliderVolume.value = optionsMenu.GetVolume();
    }

    public void MoveSlider() {
        optionsMenu.SetVolume(sliderVolume.value);
    }
    
}
