using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    [SerializeField]
    private GameObject[] _allCharacters;

    // Start is called before the first frame update
    void Awake()
    {
        InstantiaCharacter(PlayerPrefs.GetInt(PlayerPrefsStrings.characterIndice));
    }

    public void InstantiaCharacter(int mth_indice)
    {
        Instantiate(_allCharacters[mth_indice], transform.position, transform.rotation);
    }
}
