using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class InteractiveObject : MonoBehaviour, IInteractive
{
   [SerializeField]
    private string SceneToLoad;

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

       if (gameObject.CompareTag("SceneTransition"))
      {
            SceneManager.LoadScene(SceneToLoad);
        }
        else
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
}
