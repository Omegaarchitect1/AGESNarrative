using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemToggle : MonoBehaviour
{
    [SerializeField]
    private Image iconImage;

    public static event Action<InventoryObject> InventoryMenuItemSelected;
    private InventoryObject associatedInventoryObject;

    public InventoryObject AssociatedInventoryObject
    {
        get { return associatedInventoryObject; }

        set
        {
            associatedInventoryObject = value;
            iconImage.sprite = associatedInventoryObject.Icon;
        }
    }

    public void InventoryItemWasToggled(bool isOn)
    {
        if (isOn)
            InventoryMenuItemSelected?.Invoke(AssociatedInventoryObject);
        Debug.Log($"Toggled: {isOn}");

    }

    private void Awake()
    {
        Toggle toggle = GetComponent<Toggle>();
        ToggleGroup toggleGroup = GetComponentInParent<ToggleGroup>();
        toggle.group = toggleGroup;
    }

}
