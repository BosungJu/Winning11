using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    public Slider sound;
    public OnOffButton vibration;

    private static float volume = 0.6f;
    private static bool isOn = true;

    private void Awake()
    {
        sound.onValueChanged.AddListener((value) => 
        {
            SoundManager.instance.ChangeBGMVolume(value);
            SoundManager.instance.ChangeAllVolume(value);
            volume = value;
        });
        vibration.OnClickEvent += (isOn) => 
        {
            Vibration.isOn = isOn;
            Setting.isOn = isOn;
        };

        sound.value = volume;
        vibration.isOn = isOn;
        vibration.SetButtonImage();
    }
}
