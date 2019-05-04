using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//summary
//This script is for a flashlight which will let the player see in dark areas such as the deep woods.
//summary
public class Flashlight : MonoBehaviour
{
    [SerializeField]
    private Light flashlight;
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
