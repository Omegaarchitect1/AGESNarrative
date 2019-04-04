using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : InteractiveObject
{

    [SerializeField]
    private string objectName = nameof(InventoryObject);
    // TODO: add long desctiption field
    // TODO: add item icon

    public string ObjectName => objectName;

    private new Renderer renderer;
    private new Collider collider;
    private void Start()
    {
        renderer = GetComponent<Renderer>();
        collider = GetComponent<Collider>();
    }


     public InventoryObject()
    {
        displayText = $"Take {objectName}";
    }

    public override void InteractWith()
    {
        base.InteractWith();
        PlayerInventory.InventoryObjects.Add(this);
        collider.enabled = false;
        renderer.enabled = false;
    }
}
