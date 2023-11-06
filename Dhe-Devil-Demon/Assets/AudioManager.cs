using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer au;
    public Slider gSlider;
    public Slider mSlider;
    public Slider eSlider;

    // Update is called once per frame
    void Update()
    {
        au.SetFloat("MasterVolume",gSlider.value);
        au.SetFloat("MusicVolume",mSlider.value);
        au.SetFloat("EffectVolume",eSlider.value);
    }
}
