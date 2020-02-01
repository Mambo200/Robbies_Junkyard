using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ToolsMain : Interactable
{
    public abstract Tools ToolType { get; }

    public override EnumType Enumtype => EnumType.TOOLS;

    /// <summary>
    /// Add Item to inventory
    /// </summary>
    /// <param name="_amount">amount to add to inventory</param>
    public override void MoveToInventory(int _amount)
    {
        Debug.Log("Pick up " + ToolType.ToString());

        FindObjectOfType<PlayerController>().inventory.AddItem(ToolType, _amount);
    }

}
