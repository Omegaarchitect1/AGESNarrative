using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// detects when the player presses the interact button while looking at IInteractive,
/// then calls IInteractive with the InteractWith method
/// </summary>
public class InteractWithLookedAt : MonoBehaviour
{
    private IInteractive lookedAtInteractive;
    void Update()
    {
        if (Input.GetButtonDown("Interact") && lookedAtInteractive != null)
        {
            Debug.Log("Player pressed the interact button.");
            lookedAtInteractive.InteractWith();
        }
    }

    private void OnLookedAtInteractiveChanged(IInteractive newLookedAtInteractive)
    {
        lookedAtInteractive = newLookedAtInteractive;
    }
    #region event subscirption / unsubsciption
    private void OnEnable()
    {
        DetectedLookAtInterctor.LookedAtInteractiveChanged += OnLookedAtInteractiveChanged;
    }

    private void OnDisable()
    {
        DetectedLookAtInterctor.LookedAtInteractiveChanged -= OnLookedAtInteractiveChanged;

    }
    #endregion
}
