using UnityEngine;
using UnityEngine.UI;
namespace QuarksUI
{
    public class DialogBox : MonoBehaviour
    {
        public Text tittleText;
        public Text contentText;
        public Button primaryButton;
        public Button SecundaryButton;
        private Animator m_Anim;
        void Start()
        {
            m_Anim = GetComponent<Animator>();
        }
        public void Open()
        {
            if (m_Anim)
            {
                m_Anim.SetBool("Show", true);
            }
        }
        public void Close()
        {
            if (m_Anim)
            {
                m_Anim.SetBool("Show", false);
            }
        }
    }
}