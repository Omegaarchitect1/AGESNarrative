using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : InteractiveObject
{
   
    [SerializeField]
    private string lockedDisplayText = "Locked";

    [SerializeField]
    private AudioClip lockedAudioClip;

    [SerializeField]
    private AudioClip openAudioClip;

    [SerializeField]
    private InventoryObject Key;

    [SerializeField]
    private bool ConsumesKey;

    // public override string DisplayText => isLocked ? lockedDisplayText :  base.displayText;


    public override string DisplayText
    {
        get
        {
            string toReturn;
            if (isLocked)
                toReturn = HasKey ? $"Use {Key.ObjectName}" : lockedDisplayText;
            else
                toReturn = base.displayText;

            return toReturn;
        }
    }

    private bool isLocked;
    private Animator animator;
    private bool isOpen;
    private bool HasKey => PlayerInventory.InventoryObjects.Contains(Key);

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
        InitializeIsLocked();
    }

   private void InitializeIsLocked()
   {
        if (Key != null)
        isLocked = true;
   }

    /// <summary>
    /// Calling the InteractWith method from the IInteractive interface to utilize that functionality 
    /// </summary>

    public override void InteractWith()
    {
        if (!isOpen)
        {
            if(isLocked && !HasKey)
            {
                audioSource.clip = lockedAudioClip;
            }
            else
            {
                audioSource.clip = openAudioClip;
                animator.SetBool("shouldOpen", true);
                displayText = string.Empty;
                isOpen = true;
                isLocked = false;
                UnlockDoor();
            }
            base.InteractWith();
        }
    }

    private void UnlockDoor()
    {
        if (Key != null && ConsumesKey)
            PlayerInventory.InventoryObjects.Remove(Key);
    }
}
