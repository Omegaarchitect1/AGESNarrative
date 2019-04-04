using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : InteractiveObject
{
    // TODO: add long desctiption field
    // TODO: add item icon

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        collider = GetComponent<Collider>();
    }

    private new Renderer renderer;
    private new Collider collider;
     public InventoryObject()
    {
        displayText = nameof(InventoryObject);
    }

    public override void InteractWith()
    {
        base.InteractWith();
        PlayerInventory.InventoryObjects.Add(this);
        collider.enabled = false;
        renderer.enabled = false;

        //ended video at 37:27


    }
}
