using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSetting : MonoBehaviour
{
    [SerializeField] private string parameter;

    [SerializeField] private Slider slider;

    [SerializeField] private AudioMixer audioMixer;

    public void SetValueSound()
    {
        audioMixer.SetFloat(parameter, slider.value);   
    }
}
