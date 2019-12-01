using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericWeapon : MonoBehaviour
{

    [Header("Ajuste da arma")]
    /// <summary>
    /// Valor de ajuste pra quando a arma estiver guardada.
    /// </summary>
    public Vector3 ajustPosOnGuard;
    public Vector3 ajustAngOnGuard;

    [Header("Atributos da arma")]
    public float damange;
    public float reach;
    public float timePerMinute;
}
