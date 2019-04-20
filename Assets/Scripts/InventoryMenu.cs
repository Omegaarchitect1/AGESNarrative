using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class InventoryMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject InventoryItemTogglePrefab;

    [SerializeField]
    private Transform InventoryContentArea;

    [SerializeField]
    private Text itemLabelText;

    [SerializeField]
    private Text descriptinAreaText;

    private static InventoryMenu instance;
    private CanvasGroup canvasGroup;
    private RigidbodyFirstPersonController rigidbodyFirstPersonController;
    private ToggleGroup toggleGroup;
   

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
       GameObject clone = Instantiate(InventoryItemTogglePrefab, InventoryContentArea);
        InventoryItemToggle toggle = clone.GetComponent<InventoryItemToggle>();
        toggle.AssociatedInventoryObject = inventoryObjectToAdd;
    }

    private void OnInventoryMeniItemSelected(InventoryObject inventoryObjectThatWasSelected)
    {
        itemLabelText.text = inventoryObjectThatWasSelected.ObjectName;
        descriptinAreaText.text = inventoryObjectThatWasSelected.Desciption;
    }

    private void OnEnable()
    {
        InventoryItemToggle.InventoryMenuItemSelected += OnInventoryMeniItemSelected;
    }

    private void OnDisable()
    {
        InventoryItemToggle.InventoryMenuItemSelected -= OnInventoryMeniItemSelected;
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
        toggleGroup = GetComponentInChildren<ToggleGroup>();
    }

    private void Start()
    {
        HideMenu(); 
    }
}
