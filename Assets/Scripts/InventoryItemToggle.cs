using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemToggle : MonoBehaviour
{
    [SerializeField]
    private Image iconImage;

    [SerializeField]
    private InventoryObject associatedInventoryObject;

    private void Start()
    {
        iconImage.sprite = associatedInventoryObject.Icon; 
    }
}
