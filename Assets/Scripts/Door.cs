using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : InteractiveObject
{
    [SerializeField]
    private bool isLocked;

    [SerializeField]
    private string lockedDisplayText = "Locked";

    [SerializeField]
    private AudioClip lockedAudioClip;

    [SerializeField]
    private AudioClip openAudioClip;

    public override string DisplayText => isLocked ? lockedDisplayText :  base.displayText;

    private Animator animator;
    private bool isOpen;

    /// <summary>
    /// Using a constructor to initialize displaytext in the editor
    /// </summary>
    private Door()
    {
        displayText = nameof(Door);
    }

    protected override void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// Calling the InteractWith method from the IInteractive interface to utilize that functionality 
    /// </summary>

    public override void InteractWith()
    {
        if (!isOpen)
        {
            if (!isLocked)
            {
                audioSource.clip = openAudioClip;
                animator.SetBool("shouldOpen", true);
                displayText = string.Empty;
                isOpen = true;
            }

            else
            {
                audioSource.clip = lockedAudioClip;
            }
            base.InteractWith();
        }
    }
}
