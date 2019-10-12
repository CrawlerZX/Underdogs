using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ConfigScript : MonoBehaviour
{
  public AudioMixer mixer;

  public void SetVolume(float sliderValue){
    mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
  }

  public void MuteVolume(bool toggleCheck){
    if(toggleCheck){
      mixer.SetFloat("MusicVol", 0f);
    }
  }
}
