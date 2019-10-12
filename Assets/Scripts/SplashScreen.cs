using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    public void SplashFinish(){
    SceneManager.LoadScene("Menu");
  }
}
