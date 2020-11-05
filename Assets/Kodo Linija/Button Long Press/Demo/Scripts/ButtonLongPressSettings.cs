using System.Collections;
using System.Collections.Generic;
using KodoLinija.UI;
using UnityEngine;
using UnityEngine.UI;

namespace KodoLinija.UI.ButtonLongPressExamples 
{
    [DefaultExecutionOrder(1000)]
    public class ButtonLongPressSettings : MonoBehaviour
    {
        private const float MaxTime = 5;
        #pragma warning disable 0649
        [SerializeField] private ButtonLongPress m_ButtonLongPress;
        [SerializeField] private Text m_ProgressText;
        [SerializeField] private Text m_CurrentHoldTimeText;
        [SerializeField] private Text m_HoldTimeSettingText;
        [SerializeField] private Slider m_HoldTimeSlider;
        [SerializeField] private Toggle m_ExecuteOnReleaseToggle;
        [SerializeField] private Toggle m_RetriggerToggle;
        #pragma warning restore 0649
        // Start is called before the first frame update
        void Start()
        {
            m_RetriggerToggle.isOn = m_ButtonLongPress.Retrigger;
            m_RetriggerToggle.onValueChanged.AddListener(OnRetriggerChange);

            m_ExecuteOnReleaseToggle.isOn = m_ButtonLongPress.ExecuteOnRelease;
            OnExecuteOnReleaseChange(m_ButtonLongPress.ExecuteOnRelease);
            m_ExecuteOnReleaseToggle.onValueChanged.AddListener(
                OnExecuteOnReleaseChange);

            var sliderValue = m_ButtonLongPress.RequiredHoldTime / MaxTime;
            m_HoldTimeSlider.value = sliderValue;
            OnTimeoutSliderChange(sliderValue);
            m_HoldTimeSlider.onValueChanged.AddListener(OnTimeoutSliderChange);
        }

        void Update()
        {
            m_ProgressText.text = string.Format("Hold progress: {0:0}%", 
                m_ButtonLongPress.Progress * 100);
            m_CurrentHoldTimeText.text = string.Format(
                "Current hold time: {0:0.00}s", m_ButtonLongPress.CurrentHoldTime);
        }

        private void OnTimeoutSliderChange(float value) 
        {
            value = Mathf.Max(0.05f, value * MaxTime);
            m_ButtonLongPress.RequiredHoldTime = value;
            m_HoldTimeSettingText.text = string.Format(
                "Required hold time: {0:0.00}s", value);
        }

        private void OnExecuteOnReleaseChange(bool value) 
        {
            m_ButtonLongPress.ExecuteOnRelease = value;
            m_RetriggerToggle.interactable = !value;
        }
        private void OnRetriggerChange(bool value) 
        {
            m_ButtonLongPress.Retrigger = value;
        }
    }
}