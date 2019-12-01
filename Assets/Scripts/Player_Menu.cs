using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Menu : MonoBehaviour
{
    private Animator anima;
    [Range(0,20)]
    public float clock = 15f ;
    private bool NextIdleI = true;
    private bool NextIdleII = false;
    private float rotSpeed = 5;

    void Awake()
    {
        anima = GetComponent<Animator>();
    }

    public void PrepareMoveToCamera()
    {
        transform.localRotation = Quaternion.identity;
        transform.localPosition = new Vector3(0f, 0f, -6f);
        anima.SetBool("WalkingMenu", true);
    }

    // Update is called once per frame
    void Update()
    {

        if(transform.localPosition.z <= -0.1f){
            transform.localPosition = Vector3.Lerp(transform.localPosition, Vector3.zero, .5f * Time.deltaTime);
            //Tem que ficar ajustando sempre a posição local pois a animação do personagem andando esta desajustando o mesmo na tela.
            transform.localPosition = new Vector3(0f, 0f, transform.localPosition.z);
        } else{
            anima.SetBool("WalkingMenu",false);
            //Tem que ficar ajustando sempre a posição local pois a animação do personagem andando esta desajustando o mesmo na tela.
            transform.localPosition = Vector2.zero;
        }

        clock -= Time.deltaTime;

        if(clock <= 0.0){
            if(NextIdleI){
            anima.SetBool("Idle Break I", true);
            }
            clock = 35f;
        }
        
    }

    public void IdleBreakIEvent(){
        NextIdleII = false;
        anima.SetBool("Idle Break I", false);
    }
}
