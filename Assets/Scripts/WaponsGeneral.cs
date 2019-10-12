using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaponsGeneral : MonoBehaviour
{
    [Range(1,15)]
    public int rotWeaponSpeed = 1;

    public GameObject weaponOnGround;
    public GameObject weaponOnHand;

    public GameObject actualWeaponOnHand;

    // Start is called before the first frame update
    void Start()
    {
        weaponOnHand.SetActive(false);

        Vector3 gunPosition = new Vector3(Random.Range(-5,5),0.45f,Random.Range(-5,5));
        transform.SetPositionAndRotation(gunPosition,Quaternion.Euler(90,0,0));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotWeaponSpeed);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player") {
            weaponOnHand.SetActive(true);
            actualWeaponOnHand.SetActive(false);
            weaponOnGround.SetActive(false);
        }

    }
}
