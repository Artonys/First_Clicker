using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Controls : MonoBehaviour
{
    public GameObject canvasMenu;
    public AudioMixer am;
    public GameObject sliderAudio;

    private float miliSecond;
    private float second;
    private float sliderValue;

    private void Start()
    {
        if (PlayerPrefs.HasKey("soundVolume"))
        {
            sliderValue = PlayerPrefs.GetFloat("soundVolume");
            am.SetFloat("masterVolume", sliderValue);
            sliderAudio.GetComponent<Slider>().value = sliderValue;
        }
    }
    public void OpenSettings()
    {
        canvasMenu.SetActive(true);
    }

    public void CloseSettings()
    {
        canvasMenu.SetActive(false);
    }

    public void AudioVolume(float sliderValue)
    {
        am.SetFloat("masterVolume", sliderValue);
        PlayerPrefs.SetFloat("soundVolume", sliderValue);
    }

    public void ExitAppl()
    {
        Application.Quit();
    }

    private void FixedUpdate()
    {
        miliSecond += 0.02f;
        if (miliSecond >= 1) // Одна сек
        {
            second++;
            miliSecond = 0;
        }
    }
}
