using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunWeapon : GenericWeapon
{
    
    /// <summary>
    /// Lugar onde vai ser instancia a municao.
    /// </summary>
    public Transform spaw;

    public float magazine = 5;
    public float maxBullets = 5;
}
