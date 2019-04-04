using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : InteractiveObject
{
    // TODO: add long desctiption field
    // TODO: add item icon

    public override void InteractWith()
    {
        base.InteractWith();
        PlayerInventory p = new PlayerInventory();
        p.InventoryObjects.Add(this);

    }
}
