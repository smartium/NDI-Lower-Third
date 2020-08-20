using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCommands : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            print("space key was pressed");
        }
    }
}
