using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemToggle : MonoBehaviour
{
    [SerializeField]
    private Image iconImage;

    
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

    private void Start()
    {
        iconImage.sprite = associatedInventoryObject.Icon; 
    }
}
