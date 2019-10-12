using UnityEngine;
using UnityEngine.UI;
namespace QuarksUI
{
    public class InputfieldPlus : MonoBehaviour
    {
        public Button clearButton;
        private InputField m_InputField;
        /// <summary>
        /// Start is called on the frame when a script is enabled just before
        /// any of the Update methods is called the first time.
        /// </summary>
        void Start()
        {
            m_InputField = GetComponent<InputField>();
            m_InputField.onValueChanged.AddListener(OnValueChanged);
            OnValueChanged(m_InputField.text);
            clearButton.onClick.AddListener(ClearInput);
        }
        void ClearInput()
        {
            m_InputField.text = "";
        }
        void OnValueChanged(string str)
        {
            if (clearButton)
            {
                if (str != "")
                {
                    clearButton.interactable = true;
                }
                else
                {
                    clearButton.interactable = false;
                }
            }
        }
    }
}