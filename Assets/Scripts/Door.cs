using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : InteractiveObject
{
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
        if(!isOpen)
        {
        base.InteractWith();
        animator.SetBool("shouldOpen", true);
        displayText = string.Empty;
        isOpen = true;
        }
       
    }
}
