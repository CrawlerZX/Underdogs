using UnityEngine;
using UnityEngine.UI;
namespace QuarksUI
{
    public class SliderPlus : MonoBehaviour
    {
        public Text valueLabel;
        public bool showPrecentage = false;
        private Slider m_Slider;
        /// <summary>
        /// Start is called on the frame when a script is enabled just before
        /// any of the Update methods is called the first time.
        /// </summary>
        void Start()
        {
            m_Slider = GetComponent<Slider>();
            m_Slider.onValueChanged.AddListener(OnValueChanged);
            OnValueChanged(m_Slider.value);
        }
        /// <summary>
        /// Called when the slider value changed.
        /// </summary>
        void OnValueChanged(float value)
        {
            if (m_Slider)
            {
                if (showPrecentage)
                {
                    valueLabel.text = System.Math.Round((decimal)value) + "%";
                }
                else
                {
                    if (m_Slider.wholeNumbers)
                    {
                        valueLabel.text = System.Math.Round((decimal)value).ToString();
                    }
                    else
                    {
                        valueLabel.text = System.Math.Round((decimal)value, 2).ToString();
                    }
                }
            }
        }
    }
}