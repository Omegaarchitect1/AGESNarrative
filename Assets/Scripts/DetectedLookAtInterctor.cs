using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectedLookAtInterctor : MonoBehaviour
{

    [Tooltip("Starting point the raycast used to detect interactives.")]
    [SerializeField]
    private Transform raycastOrigin;

    [Tooltip("How far from the raycast origin we'll search for interactive elements")]
    [SerializeField]
    private float maxRange = 5.0f;

    public static event Action LookedAtInteractiveChanged;

    
    public IInteractive LookedAtInteractive
    {
        get { return lookAtInteractive; }
        private set
        {
            bool isInteractiveChanged = value != LookedAtInteractive;
            if(isInteractiveChanged)
            {
                LookedAtInteractive = value;
                LookedAtInteractiveChanged?.Invoke();
                //stopped video tutorial 3 at 47:25
               
            }

        }
    }

    private IInteractive lookAtInteractive;

    private void FixedUpdate()
    {
        
        Debug.DrawRay(raycastOrigin.position, raycastOrigin.forward * maxRange, Color.red);
        RaycastHit hitInfo;
        bool objectWasDetected = Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hitInfo, maxRange);

        IInteractive interactive = null;

            if(objectWasDetected)
        {
            //Debug.Log($"Player is looking at:  {hitInfo.collider.gameObject.name}");
            interactive = hitInfo.collider.gameObject.GetComponent<IInteractive>();

            if (interactive != null)
                lookAtInteractive = interactive;
        }
    }
}
