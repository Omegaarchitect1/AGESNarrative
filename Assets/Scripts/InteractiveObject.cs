using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class InteractiveObject : MonoBehaviour, IInteractive
{
    [SerializeField]
    private protected string displayText = nameof(InteractiveObject);
    public virtual string DisplayText => displayText;

    private protected AudioSource audioSource;

    protected virtual void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public virtual void InteractWith()
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
