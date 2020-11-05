using UnityEngine;

namespace KodoLinija.UI.ButtonLongPressExamples
{
    public class TestScriptWiring : MonoBehaviour
    {
        void Start()
        {
            ButtonLongPress button = GetComponentInChildren<ButtonLongPress>();
            button.gameObject.AddComponent<ScriptUsageExample>();
        }
    }
}
