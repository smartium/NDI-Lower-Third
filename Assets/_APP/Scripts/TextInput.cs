using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class TextInput : MonoBehaviour
{
    public Text nameOutput;
    public InputField inputField;
    public Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        Display.displays[0].SetParams(1920, 590, 0, 790);

        if (Application.isEditor)
        {
            camera.name = "EDITOR";
        }
        else
        {
            camera.name = "InterAoVivo";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sendText()
    {
        nameOutput.text = inputField.text;
    }

    public void resetTexts()
    {
        nameOutput.text = null;
        inputField.text = null;
    }
}
