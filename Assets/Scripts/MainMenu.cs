using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

  public AudioSource menuFX;
  public AudioClip buttonFXClick;
  public AudioClip buttonFXHover;
  private Scene scene;
  public float timer = 2f;
  
  public void PlayGame(){
    SceneManager.LoadScene("Select");
    menuFX.PlayOneShot(buttonFXClick);
  }

  public void Hover(){
    menuFX.PlayOneShot(buttonFXHover);
  }

  public void AboutGame(){
    SceneManager.LoadScene("About");
  }

   public void ConfigGame(){
    SceneManager.LoadScene("Config");
  }

  public void Menu(){
    SceneManager.LoadScene("Menu");
  }

  public void QuitGame(){
    Application.Quit();
  }
}
