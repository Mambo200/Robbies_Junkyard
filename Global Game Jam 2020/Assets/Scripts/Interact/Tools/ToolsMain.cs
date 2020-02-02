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
        InfoText.Get.Message($"You found {ToolType.ToString().ToLower()}: ({_amount})", 2.5f, Color.yellow);

        FindObjectOfType<PlayerController>().inventory.AddItem(ToolType, _amount);
    }

}
