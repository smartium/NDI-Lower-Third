using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyCommands : MonoBehaviour
{
    public Button btnClosePresets;
    public GameObject panelPresets;
    private bool bPresets = true;

    // Start is called before the first frame update
    void Start()
    {
        panelPresets.SetActive(bPresets);
        btnClosePresets.onClick.AddListener(delegate {
            bPresets = false;
            panelPresets.SetActive(bPresets);
        });

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            bPresets = !bPresets;
            panelPresets.SetActive(bPresets);
        }
    }
}
