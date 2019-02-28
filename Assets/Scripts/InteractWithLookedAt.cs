using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// detects when the player presses the interact button while looking at IInteractive,
/// then calls IInteractive with the InteractWith method
/// </summary>
public class InteractWithLookedAt : MonoBehaviour
{

    [SerializeField]
    private DetectedLookAtInterctor detectLookAtInteractive;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && detectLookAtInteractive.LookedAtInteractive != null)
        {
            Debug.Log("Player pressed the interact button.");
            detectLookAtInteractive.LookedAtInteractive.InteractWith();
        }
    }
}
