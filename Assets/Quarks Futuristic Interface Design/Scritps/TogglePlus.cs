using UnityEngine;
using UnityEngine.UI;
namespace QuarksUI
{
    public class TogglePlus : MonoBehaviour
    {
        public Text stateText;
        private Toggle m_Toggle;
        private Animator anim;
        /// <summary>
        /// Start is called on the frame when a script is enabled just before
        /// any of the Update methods is called the first time.
        /// </summary>
        void Start()
        {
            anim = GetComponent<Animator>();
            m_Toggle = GetComponent<Toggle>();
            m_Toggle.onValueChanged.AddListener(setState);
        }
        void setState(bool value)
        {
            if (m_Toggle)
            {
                anim.SetBool("IsOn", value);
                if (stateText)
                {
                    if (value)
                    {
                        stateText.text = "On";
                    }
                    else
                    {
                        stateText.text = "Off";
                    }
                }
            }
        }
    }
}