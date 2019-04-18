using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class InventoryMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject InventoryItemTogglePrefab;

    private static InventoryMenu instance;
    private CanvasGroup canvasGroup;
    private RigidbodyFirstPersonController rigidbodyFirstPersonController;

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
        rigidbodyFirstPersonController.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void HideMenu()
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        rigidbodyFirstPersonController.enabled = true;
    }

    public void ExitMenuButtonClick()
    {
        HideMenu();
    }

    public void AddItemToMenu(InventoryObject inventoryObjectToAdd)
    {
        Instantiate(InventoryItemTogglePrefab);
        GameObject clone = Instantiate(InventoryItemTogglePrefab);
        InventoryItemToggle toggle = clone.GetComponent<InventoryItemToggle>();
        toggle.AssociatedInventoryObject = inventoryObjectToAdd;
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
        rigidbodyFirstPersonController = FindObjectOfType<RigidbodyFirstPersonController>();
        HideMenu();
    }

    private void Start()
    {
        HideMenu(); 
    }
}
