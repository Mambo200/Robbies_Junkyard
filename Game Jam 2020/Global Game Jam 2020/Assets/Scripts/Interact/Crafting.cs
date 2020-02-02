using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Crafting
{
    #region Hammer
    /// <summary>
    /// check if player has enough materials and craft a Hammer and put it in inventory
    /// </summary>
    /// <param name="_inventory">inventory of Player</param>
    /// <returns>true if hammer could be crafted, else false</returns>
    public static bool CraftHammer(Inventory _inventory)
    {
        if (!CanCraftHammer(_inventory)) return false;

        _inventory.ToolInventory[Interactable.Tools.HAMMER]++;

        _inventory.JunkInventory[Interactable.Junk.BOLT]--;
        _inventory.JunkInventory[Interactable.Junk.BOLTNUT]--;

        return true;
    }

    /// <summary>
    /// Total Requirements: 1 <see cref="Interactable.Junk.BOLT"/> and 1 <see cref="Interactable.Junk.BOLTNUT"/>
    /// </summary>
    /// <param name="_inventory">players Inventory</param>
    /// <returns>true if player has enough of materials, else false</returns>
    private static bool CanCraftHammer(Inventory _inventory)
    {
        if (_inventory.JunkInventory[Interactable.Junk.BOLT] >= 1
            && _inventory.JunkInventory[Interactable.Junk.BOLTNUT] >= 1)
            return true;
        else return false;
    }
    #endregion

    #region Tongs
    /// <summary>
    /// check if player has enough materials and craft a Tong and put it in inventory
    /// </summary>
    /// <param name="_inventory">inventory of Player</param>
    /// <returns>true if hammer could be crafted, else false</returns>
    public static bool CraftTongs(Inventory _inventory)
    {
        if (!CanCraftTongs(_inventory)) return false;

        _inventory.ToolInventory[Interactable.Tools.TONGS]++;

        _inventory.JunkInventory[Interactable.Junk.BOLT]--;
        _inventory.JunkInventory[Interactable.Junk.BOLTNUT] -= 2;

        return true;
    }

    /// <summary>
    /// Total Requirements: 1 <see cref="Interactable.Junk.BOLT"/> and 2 <see cref="Interactable.Junk.BOLTNUT"/>
    /// </summary>
    /// <param name="_inventory">players Inventory</param>
    /// <returns>true if player has enough of materials, else false</returns>
    private static bool CanCraftTongs(Inventory _inventory)
    {
        if (_inventory.JunkInventory[Interactable.Junk.BOLT] >= 1
            && _inventory.JunkInventory[Interactable.Junk.BOLTNUT] >= 2)
            return true;
        else return false;
    }
    #endregion

    #region Rocket
    /// <summary>
    /// check if player has enough materials and craft a Rocket
    /// </summary>
    /// <param name="_inventory">inventory of Player</param>
    /// <returns>true if hammer could be crafted, else false</returns>
    public static bool CraftRocket(Inventory _inventory)
    {
        if (!CanCraftRocket(_inventory)) return false;

        _inventory.JunkInventory[Interactable.Junk.BOTTLE] -= 1;
        _inventory.JunkInventory[Interactable.Junk.WOODENPLANK] -= 4;
        _inventory.JunkInventory[Interactable.Junk.CORRUGATEDIRON] -= 1;
        _inventory.JunkInventory[Interactable.Junk.CARDBOARD] -= 1;
        _inventory.JunkInventory[Interactable.Junk.BOLT] -= 15;
        _inventory.JunkInventory[Interactable.Junk.BOLTNUT] -= 15;
        _inventory.JunkInventory[Interactable.Junk.COGWHEEL] -= 20;
        _inventory.FuelInventory[Interactable.Fuel.GAS] -= 5;
        _inventory.JunkInventory[Interactable.Junk.STARTBUTTON] -= 1;

        Debug.Log("Rocked build");

        return true;
    }

    /// <summary>
    /// Total Requirements: 
    /// 1 <see cref="Interactable.Junk.BOTTLE"/>, 
    /// 4 <see cref="Interactable.Junk.WOODENPLANK"/>, 
    /// 1 <see cref="Interactable.Junk.CORRUGATEDIRON"/>, 
    /// 1 <see cref="Interactable.Junk.CARDBOARD"/>, 
    /// 15 <see cref="Interactable.Junk.BOLT"/>, 
    /// 15 <see cref="Interactable.Junk.BOLTNUT"/>,
    /// 20 <see cref="Interactable.Junk.COGWHEEL"/>, 
    /// 1 <see cref="Interactable.Junk.STARTBUTTON"/>, 
    /// 1 <see cref="Interactable.Junk.DUCKTAPE"/>
    /// 1 <see cref="Interactable.Tools.HAMMER"/>, 
    /// 1 <see cref="Interactable.Tools.TONGS"/>, 
    /// 5 <see cref="Interactable.Fuel.GAS"/>, 
    /// </summary>
    /// <param name="_inventory">players Inventory</param>
    /// <returns>true if player has enough of materials, else false</returns>
    private static bool CanCraftRocket(Inventory _inventory)
    {
        if (_inventory.JunkInventory[Interactable.Junk.BOTTLE] >= 1
            && _inventory.JunkInventory[Interactable.Junk.WOODENPLANK] >= 4
            && _inventory.JunkInventory[Interactable.Junk.CORRUGATEDIRON] >= 1
            && _inventory.JunkInventory[Interactable.Junk.CARDBOARD] >= 1
            && _inventory.JunkInventory[Interactable.Junk.BOLT] >= 15
            && _inventory.JunkInventory[Interactable.Junk.BOLTNUT] >= 15
            && _inventory.JunkInventory[Interactable.Junk.COGWHEEL] >= 20
            && _inventory.JunkInventory[Interactable.Junk.STARTBUTTON] >= 1
            && _inventory.ToolInventory[Interactable.Tools.HAMMER] >= 1
            && _inventory.ToolInventory[Interactable.Tools.TONGS] >= 1
            && _inventory.FuelInventory[Interactable.Fuel.GAS] >= 5
            )
            return true;
        else return false;
    }
    #endregion
}
