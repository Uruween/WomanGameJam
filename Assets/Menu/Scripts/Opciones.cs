using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Opciones : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    public void Fullscreen (bool fullScreen) 
    {
        Screen.fullScreen = fullScreen;

    }
    public void Volume (float volumen) 
    {
        audioMixer.SetFloat("Limitless Void", volumen);
    }
    public void Calidad (int index) 
    {
        QualitySettings.SetQualityLevel(index);
    }
}
