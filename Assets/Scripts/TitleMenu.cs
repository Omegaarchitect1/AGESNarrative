using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenu : MonoBehaviour
{
    [SerializeField]
    private string SceneToLoad;

    public void LoadGameScene()
    {
        SceneManager.LoadScene(SceneToLoad);
    }

    public void ExitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    private void Awake()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
