using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenu : MonoBehaviour
{
    private static InventoryMenu instance;
    private CanvasGroup canvasGroup;

    public static InventoryMenu Instance
    {
        get
        {
            if (instance == null)
                throw new System.Exception("There is currently no InventoryMenu instnce but you are trying to access it anyway.");
            return instance;
        }
        private set { instance = value; }
    }

    private bool IsVisible => canvasGroup.alpha > 0;

    private void ShowMenu()
    {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
    }

    private void HideMenu()
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
    }

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            if (IsVisible)
                HideMenu();

            else
                ShowMenu();
        }
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;

        else
            throw new System.Exception("There is already an instance of InventoryMenu active. THERE CAN BE ONLY OOOOOOOONE");

        canvasGroup = GetComponent<CanvasGroup>();
        HideMenu();
    }
}
