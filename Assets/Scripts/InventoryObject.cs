using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : InteractiveObject
{

    [SerializeField]
    private string objectName = nameof(InventoryObject);

    [SerializeField]
    [TextArea(3,8)]
    private string description;

    [SerializeField]
    private Sprite icon;

    public Sprite Icon => icon;
    public string ObjectName => objectName;
    public string Desciption => description;
   
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
        InventoryMenu.Instance.AddItemToMenu(this);
        collider.enabled = false;
        renderer.enabled = false;
        Debug.Log($"Inventory menu game object name {InventoryMenu.Instance.name}");
    }
}
