using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KodoLinija.UI;

public class Presets : MonoBehaviour
{
    public Toggle toggleAutoLive;
    public ButtonLongPress btnClearPresets, btnDemoPresets;
    public InputField inputName, inputTitle;
    public Text renderName, renderTitle, txtAutoLiveInfo;
    public Button[] btnPreset;
    public InputField[] txtPresetName;
    public InputField[] txtPresetTitle;

    // Start is called before the first frame update
    void Start()
    {
        toggleAutoLive.onValueChanged.AddListener(delegate {
            //print(toggleAutoLive.GetComponent<Toggle>().isOn);
            if (toggleAutoLive.GetComponent<Toggle>().isOn)
            {
                txtAutoLiveInfo.GetComponent<Text>().enabled = true;
            }
            else
            {
                txtAutoLiveInfo.enabled = false;
            }
        });

        btnClearPresets.RequiredHoldTime = 2.0f;
        btnClearPresets.ExecuteOnRelease = false;
        btnClearPresets.onClickLongComplete.AddListener(delegate {
            for (int i = 0; i < txtPresetName.Length; i++)
            {
                txtPresetName[i].text = "";
                txtPresetTitle[i].text = "";
            }
        });

        btnDemoPresets.RequiredHoldTime = 2.0f;
        btnDemoPresets.ExecuteOnRelease = false;
        btnDemoPresets.onClickLongComplete.AddListener(delegate {
            for (int i = 0; i < txtPresetName.Length; i++)
            {
                txtPresetName[i].text = "Nome do Preset " + (i+1);
                txtPresetTitle[i].text = "Cargo ou Título do Preset " + (i + 1);
            }
        });

        btnPreset[0].onClick.AddListener(delegate {
            inputName.text = txtPresetName[0].text.ToUpper();
            inputTitle.text = txtPresetTitle[0].text.ToUpper();
            if (toggleAutoLive.GetComponent<Toggle>().isOn)
            {
                renderName.text = txtPresetName[0].text.ToUpper();
                renderTitle.text = txtPresetTitle[0].text.ToUpper();
            }
        });

        btnPreset[1].onClick.AddListener(delegate {
            inputName.text = txtPresetName[1].text.ToUpper();
            inputTitle.text = txtPresetTitle[1].text.ToUpper();
            if (toggleAutoLive.GetComponent<Toggle>().isOn)
            {
                renderName.text = txtPresetName[1].text.ToUpper();
                renderTitle.text = txtPresetTitle[1].text.ToUpper();
            }
        });

        btnPreset[2].onClick.AddListener(delegate {
            inputName.text = txtPresetName[2].text.ToUpper();
            inputTitle.text = txtPresetTitle[2].text.ToUpper();
            if (toggleAutoLive.GetComponent<Toggle>().isOn)
            {
                renderName.text = txtPresetName[2].text.ToUpper();
                renderTitle.text = txtPresetTitle[2].text.ToUpper();
            }
        });

        btnPreset[3].onClick.AddListener(delegate {
            inputName.text = txtPresetName[3].text.ToUpper();
            inputTitle.text = txtPresetTitle[3].text.ToUpper();
            if (toggleAutoLive.GetComponent<Toggle>().isOn)
            {
                renderName.text = txtPresetName[3].text.ToUpper();
                renderTitle.text = txtPresetTitle[3].text.ToUpper();
            }
        });

        btnPreset[4].onClick.AddListener(delegate {
            inputName.text = txtPresetName[4].text.ToUpper();
            inputTitle.text = txtPresetTitle[4].text.ToUpper();
            if (toggleAutoLive.GetComponent<Toggle>().isOn)
            {
                renderName.text = txtPresetName[4].text.ToUpper();
                renderTitle.text = txtPresetTitle[4].text.ToUpper();
            }
        });

        btnPreset[5].onClick.AddListener(delegate {
            inputName.text = txtPresetName[5].text.ToUpper();
            inputTitle.text = txtPresetTitle[5].text.ToUpper();
            if (toggleAutoLive.GetComponent<Toggle>().isOn)
            {
                renderName.text = txtPresetName[5].text.ToUpper();
                renderTitle.text = txtPresetTitle[5].text.ToUpper();
            }
        });

        btnPreset[6].onClick.AddListener(delegate {
            inputName.text = txtPresetName[6].text.ToUpper();
            inputTitle.text = txtPresetTitle[6].text.ToUpper();
            if (toggleAutoLive.GetComponent<Toggle>().isOn)
            {
                renderName.text = txtPresetName[6].text.ToUpper();
                renderTitle.text = txtPresetTitle[6].text.ToUpper();
            }
        });

        btnPreset[7].onClick.AddListener(delegate {
            inputName.text = txtPresetName[7].text.ToUpper();
            inputTitle.text = txtPresetTitle[7].text.ToUpper();
            if (toggleAutoLive.GetComponent<Toggle>().isOn)
            {
                renderName.text = txtPresetName[7].text.ToUpper();
                renderTitle.text = txtPresetTitle[7].text.ToUpper();
            }
        });

        btnPreset[8].onClick.AddListener(delegate {
            inputName.text = txtPresetName[8].text.ToUpper();
            inputTitle.text = txtPresetTitle[8].text.ToUpper();
            if (toggleAutoLive.GetComponent<Toggle>().isOn)
            {
                renderName.text = txtPresetName[8].text.ToUpper();
                renderTitle.text = txtPresetTitle[8].text.ToUpper();
            }
        });

        btnPreset[9].onClick.AddListener(delegate {
            inputName.text = txtPresetName[9].text.ToUpper();
            inputTitle.text = txtPresetTitle[9].text.ToUpper();
            if (toggleAutoLive.GetComponent<Toggle>().isOn)
            {
                renderName.text = txtPresetName[9].text.ToUpper();
                renderTitle.text = txtPresetTitle[9].text.ToUpper();
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            inputName.text = txtPresetName[0].text.ToUpper();
            inputTitle.text = txtPresetTitle[0].text.ToUpper();
            if (toggleAutoLive.GetComponent<Toggle>().isOn)
            {
                renderName.text = txtPresetName[0].text.ToUpper();
                renderTitle.text = txtPresetTitle[0].text.ToUpper();
            }
        }

        else if (Input.GetKeyDown(KeyCode.F2))
        {
            inputName.text = txtPresetName[1].text.ToUpper();
            inputTitle.text = txtPresetTitle[1].text.ToUpper();
            if (toggleAutoLive.GetComponent<Toggle>().isOn)
            {
                renderName.text = txtPresetName[1].text.ToUpper();
                renderTitle.text = txtPresetTitle[1].text.ToUpper();
            }
        }

        else if (Input.GetKeyDown(KeyCode.F3))
        {
            inputName.text = txtPresetName[2].text.ToUpper();
            inputTitle.text = txtPresetTitle[2].text.ToUpper();
            if (toggleAutoLive.GetComponent<Toggle>().isOn)
            {
                renderName.text = txtPresetName[2].text.ToUpper();
                renderTitle.text = txtPresetTitle[2].text.ToUpper();
            }
        }

        else if (Input.GetKeyDown(KeyCode.F4))
        {
            inputName.text = txtPresetName[3].text.ToUpper();
            inputTitle.text = txtPresetTitle[3].text.ToUpper();
            if (toggleAutoLive.GetComponent<Toggle>().isOn)
            {
                renderName.text = txtPresetName[3].text.ToUpper();
                renderTitle.text = txtPresetTitle[3].text.ToUpper();
            }
        }

        else if (Input.GetKeyDown(KeyCode.F5))
        {
            inputName.text = txtPresetName[4].text.ToUpper();
            inputTitle.text = txtPresetTitle[4].text.ToUpper();
            if (toggleAutoLive.GetComponent<Toggle>().isOn)
            {
                renderName.text = txtPresetName[4].text.ToUpper();
                renderTitle.text = txtPresetTitle[4].text.ToUpper();
            }
        }

        else if (Input.GetKeyDown(KeyCode.F6))
        {
            inputName.text = txtPresetName[5].text.ToUpper();
            inputTitle.text = txtPresetTitle[5].text.ToUpper();
            if (toggleAutoLive.GetComponent<Toggle>().isOn)
            {
                renderName.text = txtPresetName[5].text.ToUpper();
                renderTitle.text = txtPresetTitle[5].text.ToUpper();
            }
        }

        else if (Input.GetKeyDown(KeyCode.F7))
        {
            inputName.text = txtPresetName[6].text.ToUpper();
            inputTitle.text = txtPresetTitle[6].text.ToUpper();
            if (toggleAutoLive.GetComponent<Toggle>().isOn)
            {
                renderName.text = txtPresetName[6].text.ToUpper();
                renderTitle.text = txtPresetTitle[6].text.ToUpper();
            }
        }

        else if (Input.GetKeyDown(KeyCode.F8))
        {
            inputName.text = txtPresetName[7].text.ToUpper();
            inputTitle.text = txtPresetTitle[7].text.ToUpper();
            if (toggleAutoLive.GetComponent<Toggle>().isOn)
            {
                renderName.text = txtPresetName[7].text.ToUpper();
                renderTitle.text = txtPresetTitle[7].text.ToUpper();
            }
        }

        else if (Input.GetKeyDown(KeyCode.F9))
        {
            inputName.text = txtPresetName[8].text.ToUpper();
            inputTitle.text = txtPresetTitle[8].text.ToUpper();
            if (toggleAutoLive.GetComponent<Toggle>().isOn)
            {
                renderName.text = txtPresetName[8].text.ToUpper();
                renderTitle.text = txtPresetTitle[8].text.ToUpper();
            }
        }

        else if (Input.GetKeyDown(KeyCode.F10))
        {
            inputName.text = txtPresetName[9].text.ToUpper();
            inputTitle.text = txtPresetTitle[9].text.ToUpper();
            if (toggleAutoLive.GetComponent<Toggle>().isOn)
            {
                renderName.text = txtPresetName[9].text.ToUpper();
                renderTitle.text = txtPresetTitle[9].text.ToUpper();
            }
        }
    }
}
