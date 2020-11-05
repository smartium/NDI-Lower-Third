using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
#endif

namespace KodoLinija.UI 
{
    public class ButtonLongPress : Button  
    {
        #pragma warning disable 0649
        [Tooltip("Time required to hold the button in seconds")]
        [Range(0.01f, 5f)]
        [SerializeField] private float m_RequiredHoldTime = 1f;
        [Tooltip("Should the On Click Long action execution be delayed till button is released after being held for required amount of time")]
        [SerializeField] private bool m_ExecuteOnRelease = false;
        [Tooltip("Keep retriggering the action until the button is released")]
        [SerializeField] private bool m_Retrigger = false;

        [Tooltip("Called as soon as button gets pressed")]
        [SerializeField] private ButtonClickedEvent m_OnClickLongStart 
            = new ButtonClickedEvent();
        [Tooltip("Called if button gets released too early")]
        [SerializeField] private ButtonClickedEvent m_OnClickLongCancel
            = new ButtonClickedEvent();
        [Tooltip("Called if button gets held for the whole RequiredHoldTime. Depends on ExecuteOnRelease!")]
        [SerializeField] private ButtonClickedEvent m_OnClickLongComplete 
            = new ButtonClickedEvent();
        #pragma warning restore 0649
        public ButtonClickedEvent onClickLongStart
        { 
            get => m_OnClickLongStart; 
            set 
            {
                m_OnClickLongStart = value;
            }
        }
        public ButtonClickedEvent onClickLongCancel
        { 
            get => m_OnClickLongCancel; 
            set 
            {
                m_OnClickLongCancel = value;
            }
        }
        public ButtonClickedEvent onClickLongComplete 
        { 
            get => m_OnClickLongComplete; 
            set 
            {
                m_OnClickLongComplete = value;
            }
        }
        private float m_CurrentHoldTime;
        public float CurrentHoldTime => Mathf.Clamp(m_CurrentHoldTime, 0, 
            m_RequiredHoldTime);
        public bool ExecuteOnRelease 
        {
            get => m_ExecuteOnRelease;
            set 
            {
                m_ExecuteOnRelease = value;
            }
        }

        public bool Retrigger 
        {
            get => m_Retrigger;
            set 
            {
                m_Retrigger = value;
            }
        }
        public float Progress => Mathf.Clamp(
            m_CurrentHoldTime / m_RequiredHoldTime, 0f, 1f);
        public float RequiredHoldTime 
        {
            get => m_RequiredHoldTime;
            set 
            {
                m_RequiredHoldTime = value;
            }
        }
        private bool m_WasHeldDown;
        private bool m_IsPushed;
        public bool IsPushed => m_IsPushed;
        private Slider m_Slider;
        private bool isSelectedNow =>
            #if UNITY_5 || UNITY_2017 || UNITY_2018
            currentSelectionState == SelectionState.Highlighted;
            #else
            currentSelectionState == SelectionState.Selected;
            #endif

        #if ENABLE_INPUT_SYSTEM
        private InputAction submitAction;

        private bool isHeldDown => IsPressed() || isSelectedNow
            && submitAction != null 
            && submitAction.phase == InputActionPhase.Started;

        public override void OnSubmit(BaseEventData eventData) 
        {
            if (submitAction == null && 
                    eventData.currentInputModule is InputSystemUIInputModule m)
            {
                submitAction = m.submit;
            }
        }
        #else 
        private bool isHeldDown => IsPressed() || isSelectedNow
            && Input.GetButton("Submit");

        #endif

        private bool HoldDown()
        {
            m_CurrentHoldTime += Time.unscaledDeltaTime;
            float p = m_CurrentHoldTime / m_RequiredHoldTime;
            if (m_Slider != null) 
            { 
                m_Slider.value = p;
            }
            return p >= 1;
        }

        protected override void Start()
        { 
            m_Slider = GetComponentInChildren<Slider>();
            ResetTime();
            if (m_RequiredHoldTime == 0) 
            {
                Debug.Assert(m_RequiredHoldTime > 0, 
                    "ButtonLongPress: Timeout cannot be set to 0! Defaulting to 1", this);
                m_RequiredHoldTime = 1;
            }
            base.Start();
        }

        private void StopLongPress() 
        {
            m_IsPushed = false;
        }

        private void ResetTime()
        {
            m_CurrentHoldTime = 0;
            if (m_Slider != null)
            {
                m_Slider.value = 0;
            }
        }

        private void Update()
        {
            var isDown = isHeldDown;
            if (!m_WasHeldDown && isDown) 
            {
                m_IsPushed = true;
                m_OnClickLongStart.Invoke();
            } 
            else if (m_WasHeldDown && !isDown) 
            {
                if (m_ExecuteOnRelease && m_CurrentHoldTime >= m_RequiredHoldTime) 
                {
                    m_OnClickLongComplete.Invoke();
                }
                ResetTime();
            }
            m_WasHeldDown = isDown;
            if (!m_IsPushed) 
            { 
                return; 
            }
            if (!isDown) 
            {
                StopLongPress();
                ResetTime();
                m_OnClickLongCancel.Invoke();
                return;
            }
            if (HoldDown()) 
            {
                if (!m_ExecuteOnRelease)
                {
                    m_OnClickLongComplete.Invoke();
                    if (m_Retrigger) {
                        m_CurrentHoldTime = 0;
                    } else {
                        StopLongPress();
                    }
                }
                else 
                {
                    StopLongPress();
                }
            }
        }
    }
}
