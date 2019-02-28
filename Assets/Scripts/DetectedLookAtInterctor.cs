using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectedLookAtInterctor : MonoBehaviour
{
    //
    [Tooltip("Starting point the raycast used to detect interactives.")]
    [SerializeField]
    private Transform raycastOrigin;

    [Tooltip("How far from the raycast origin we'll search for interactive elements")]
    [SerializeField]
    private float maxRange = 5.0f;

    private Vector3 raycastDirection;


    private void FixedUpdate()
    {
        Physics.Raycast(raycastOrigin.position, raycastDirection, maxRange);
    }
}
