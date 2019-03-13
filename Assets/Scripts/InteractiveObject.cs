using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour, IInteractive
{
    [SerializeField]
    private string displayText = nameof(InteractiveObject);
    public string DisplayText => displayText;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void InteractWith()
    {
        try
        {
            audioSource.Play();
        }

        catch (System.Exception)
        {

            throw new System.Exception("Missing audio component: InteractiveObject requires an AudioSource component");
        }
        Debug.Log($"Player interacted with {gameObject.name}.");


    }
}
