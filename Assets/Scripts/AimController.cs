using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimController : MonoBehaviour
{
    [Range(0.1f,1f)]
    public float aimSpeed = 0.5f;
    public Joystick joystickRight;
    void Update()
    {
        Aim();
    }
    void Aim(){
        //Vector3 inputAim = new Vector3(Input.GetAxisRaw("Right Stick Horizontal") * aimSpeed, 0, Input.GetAxisRaw("Right Stick Vertical") * aimSpeed);
        Vector3 inputAim = new Vector3(joystickRight.Horizontal, 0, joystickRight.Vertical);

        transform.Translate(inputAim);

        Vector3 cameraPosition = Camera.main.WorldToViewportPoint (transform.position);
         cameraPosition.x = Mathf.Clamp01(cameraPosition.x);
         cameraPosition.y = Mathf.Clamp01(cameraPosition.y);
         transform.position = Camera.main.ViewportToWorldPoint(cameraPosition);
    }
}
