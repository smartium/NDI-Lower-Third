using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KodoLinija.UI;
using UnityEngine.EventSystems;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif


namespace KodoLinija.UI.ButtonLongPressExamples 
{
    public class TestLongPressButton : MonoBehaviour
    {
        #pragma warning disable 0649
        [SerializeField] private ButtonLongPress m_ButtonLongPress;
        [SerializeField] private ParticleSystem m_ParticleSystem;
        [SerializeField] private AudioSource m_AudioSource;
        [SerializeField] private AudioClip m_BeepSound;
        #pragma warning restore 0649
        public void FireParticles() 
        {
            Debug.Log("Firing particles!");
            m_ParticleSystem.Emit(1000);
            m_AudioSource.PlayOneShot(m_BeepSound);
        }

        void Update() 
        {
            if (EventSystem.current.currentSelectedGameObject == null) 
            {
                if (KeyNavigationUsed())
                {
                    EventSystem.current.SetSelectedGameObject(
                        m_ButtonLongPress.gameObject);
                }
            }
        }

        private bool KeyNavigationUsed() 
        {
            #if ENABLE_INPUT_SYSTEM
                var gp = Gamepad.current;
                var kb = Keyboard.current;
                return kb != null && kb.anyKey.isPressed 
                    || gp != null && gp.buttonSouth.isPressed;
            #else
            return Mathf.Abs(Input.GetAxis("Horizontal")) > 0.3f 
                || Mathf.Abs(Input.GetAxis("Vertical")) > 0.3f
                || Input.GetButton("Submit") || Input.GetButton("Cancel");
            #endif
        }
    }
}