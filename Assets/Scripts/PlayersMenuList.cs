using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Esta e script controla a lista de personagem do menu.
/// </summary>
public class PlayersMenuList : MonoBehaviour
{

    public Text nomeText;
    
    [SerializeField]
    float _rotateSpeed = 1;
    /// <summary>
    /// Variavel q guarda o personagem q esta sendo mostrado na tela, ele e salvo a parte para facilitar no calculo
    /// de girar o personagem, pois a todo momento ele precisa ser acessado e pra nao ficar fazendo toda hora o GetChild
    /// o mesmo e salvo a parte.
    /// </summary>
    private Transform _palyer2Rotate;
    private Animator _palyerAnim;
    private bool _enableRotate;
    private float _initialMoisePos;
    private float _initialPalyerRotate;
    private int _characterIndice;

    void Start()
    {
        _characterIndice = PlayerPrefs.GetInt(PlayerPrefsStrings.characterIndice);
        PrevNextCharacter();
    }

    #region Rotaciona o personagem
    // Update is called once per frame
    void Update()
    {
        if (_enableRotate && !_palyerAnim.GetBool("WalkingMenu")) {
            float tp_mouseDis = (_initialMoisePos - Input.mousePosition.x);

            float tp_rotation = (_initialPalyerRotate + tp_mouseDis) * _rotateSpeed;

            _palyer2Rotate.eulerAngles = new Vector3(_palyer2Rotate.eulerAngles.x, tp_rotation, _palyer2Rotate.eulerAngles.z);
        }
    }

    public void EnableRotate() {
        _initialMoisePos = Input.mousePosition.x;
        _initialPalyerRotate = _palyer2Rotate.eulerAngles.y;

        _enableRotate = true;
    }

    public void DisableRotate() {
        _enableRotate = false;
    }
    #endregion

    #region Troca de personagem
    public void PrevCharacter()
    {
        transform.GetChild(_characterIndice).gameObject.SetActive(false);
        _characterIndice--;

        if (_characterIndice < 0)
        {
            _characterIndice = transform.childCount - 1;
        }

        PrevNextCharacter();
    }

    public void NextCharacter()
    {
        transform.GetChild(_characterIndice).gameObject.SetActive(false);
        _characterIndice++;

        if (_characterIndice > transform.childCount - 1)
        {
            _characterIndice = 0;
        }

        PrevNextCharacter();
    }

    /// <summary>
    /// Coisas genericas que são feitas tanto no prev como no next.
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    public void PrevNextCharacter()
    {
        transform.GetChild(_characterIndice).gameObject.SetActive(true);
        _palyer2Rotate = transform.GetChild(_characterIndice);
        _palyer2Rotate.GetComponent<Player_Menu>().PrepareMoveToCamera();
        _palyerAnim = _palyer2Rotate.GetComponent<Animator>();
        PlayerPrefs.SetInt(PlayerPrefsStrings.characterIndice, _characterIndice);
    }
    #endregion
}
