using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Sound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private static Background_Sound instance = null;
    public static Background_Sound Instance{
        get{ return instance;}
    }

    void Awake(){
        if(instance != null && instance != this){
            Destroy(this.gameObject);
            return;
        }else{
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
