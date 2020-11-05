using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;
#endif

public class ShowForNewInputSystem : MonoBehaviour
{

    #pragma warning disable 0649
    [SerializeField] private GameObject target;
    #pragma warning restore 0649

    void Start()
    {
        #if ENABLE_INPUT_SYSTEM
        if (EventSystem.current.gameObject
                .GetComponent<InputSystemUIInputModule>() == null) 
        {
            target.SetActive(true);
        }
        #endif
    }
}
