using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FuelMain : Interactable
{
    public abstract Fuel FuelType { get; }

    public override EnumType Enumtype => EnumType.FUEL;

    /// <summary>
    /// Add Item to inventory
    /// </summary>
    /// <param name="_amount">amount to add to inventory</param>
    public override void MoveToInventory(int _amount)
    {
        Debug.Log("Pick up " + FuelType.ToString());
        FindObjectOfType<PlayerController>().inventory.AddItem(FuelType, _amount);
    }

}
