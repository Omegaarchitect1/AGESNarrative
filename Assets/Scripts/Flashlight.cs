using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public Light flashlight;
    public bool activatelashlight = false;

    // Start is called before the first frame update
    void Start()
    {
        activatelashlight = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown ("Flashlight"))
        {
            if (activatelashlight == true)
            {
                flashlight.enabled = false;
                activatelashlight = false;
            }
            else if (activatelashlight == false)
            {
                flashlight.enabled = true;
                activatelashlight = true; 
            }
        }
    }
}
