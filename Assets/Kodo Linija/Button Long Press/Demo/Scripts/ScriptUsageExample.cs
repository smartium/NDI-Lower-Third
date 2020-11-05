using UnityEngine;
using KodoLinija.UI;

namespace KodoLinija.UI.ButtonLongPressExamples
{
    public class ScriptUsageExample : MonoBehaviour
    {
        private ButtonLongPress Button;

        void Start()
        {
            // Find the button
            Button = GetComponent<ButtonLongPress>();

            // Require the button to be held for 300 ms. Default is 1s.
            Button.RequiredHoldTime = 1f;

            // Wait for player to release the button before calling the 
            // completion callback. Default is false.
            Button.ExecuteOnRelease = false;

            // Keep repeating the action if button is still pressed. 
            // Default is false.
            Button.Retrigger = false;

            // Listen to start of click event
            Button.onClickLongStart.AddListener(OnStartHold);

            // Listen to premature release event
            Button.onClickLongCancel.AddListener(OnCancelHold);

            // Listen to hold completion event. This is the main action 
            // that should replace button's onClick event
            Button.onClickLongComplete.AddListener(OnCompleteHold);
        }

        void Update() 
        {
            if (Button != null && Button.IsPushed) 
            {
                Debug.LogFormat("Progress: {0:0} %, Hold time: {1:0.00}s", 
                    Button.Progress * 100, Button.CurrentHoldTime);
            }
        }

        void OnStartHold() 
        {
            Debug.Log("Started holding");
        }

        void OnCancelHold() 
        {
            Debug.Log("Released too soon!");
        }

        void OnCompleteHold() 
        {
            Debug.Log("Held long enough!");
        }
    }
}