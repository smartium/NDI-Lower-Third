using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class TextInput : MonoBehaviour
{
    public Text nameOutput1, nameOutput2;
    public InputField inputField1, inputField2;
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
        nameOutput1.text = inputField1.text.ToUpper();
        nameOutput2.text = inputField2.text.ToUpper();
    }

    public void resetTexts()
    {
        nameOutput1.text = null;
        inputField1.text = null;

        nameOutput2.text = null;
        inputField2.text = null;
    }
}
