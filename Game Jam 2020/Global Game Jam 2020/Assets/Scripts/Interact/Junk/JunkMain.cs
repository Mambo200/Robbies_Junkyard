using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class JunkMain : Interactable
{
    public abstract Junk JunkType { get; }

    public override EnumType Enumtype => EnumType.JUNK;

    /// <summary>
    /// Add Item to inventory
    /// </summary>
    /// <param name="_amount">amount to add to inventory</param>
    public override void MoveToInventory(int _amount)
    {
        Debug.Log("Pick up " + JunkType.ToString());

        FindObjectOfType<PlayerController>().inventory.AddItem(JunkType, _amount);
    }

}
