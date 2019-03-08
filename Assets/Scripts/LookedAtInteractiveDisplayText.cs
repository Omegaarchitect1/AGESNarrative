﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookedAtInteractiveDisplayText : MonoBehaviour
{
	private IInteractive LookedAtInteractive;
	private Text displayText;


    private void Awake()
    {
        displayText.GetComponent<Text>();
        UpdateDisplayText();
    }

    private void UpdateDisplayText()
    {
        if (LookedAtInteractive != null)
            displayText.text = LookedAtInteractive.DisplayText;
        else
            displayText.text = string.Empty;
         
    }

    private void OnLookedAtInteractiveChanged(IInteractive newLookedAtInteractive)
    {
        LookedAtInteractive = newLookedAtInteractive;
        
    }

    private void OnEnable()
    {
        DetectedLookAtInterctor.LookedAtInteractiveChanged += OnLookedAtInteractiveChanged;
    }

    private void OnDisable()
    {
        DetectedLookAtInterctor.LookedAtInteractiveChanged -= OnLookedAtInteractiveChanged;

    }

}
