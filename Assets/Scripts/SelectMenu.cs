using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectMenu : MonoBehaviour
{
    public void DeployButton(){
        SceneManager.LoadScene("Game");
    }
    
}
