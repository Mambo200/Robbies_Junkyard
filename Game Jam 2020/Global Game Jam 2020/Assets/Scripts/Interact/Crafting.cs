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
        _inventory.JunkInventory[Interactable.Junk.CORRUGATEDIRON]--;
        _inventory.JunkInventory[Interactable.Junk.DUCKTAPE]--;

        return true;
    }

    /// <summary>
    /// Total Requirements: 
    /// 1 <see cref="Interactable.Junk.BOLT"/>, 
    /// 1 <see cref="Interactable.Junk.BOLTNUT"/>, 
    /// 1 <see cref="Interactable.Junk.CORRUGATEDIRON"/>
    /// 1 <see cref="Interactable.Junk.DUCKTAPE"/>
    /// </summary>
    /// <param name="_inventory">players Inventory</param>
    /// <returns>true if player has enough of materials, else false</returns>
    private static bool CanCraftHammer(Inventory _inventory)
    {
        if (_inventory.JunkInventory[Interactable.Junk.BOLT] >= 1
            && _inventory.JunkInventory[Interactable.Junk.BOLTNUT] >= 1
            && _inventory.JunkInventory[Interactable.Junk.CORRUGATEDIRON] >= 1
            && _inventory.JunkInventory[Interactable.Junk.DUCKTAPE] >= 1)
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
        _inventory.JunkInventory[Interactable.Junk.CORRUGATEDIRON]--;
        _inventory.JunkInventory[Interactable.Junk.DUCKTAPE]--;

        return true;
    }

    /// <summary>
    /// Total Requirements: 
    /// 1 <see cref="Interactable.Junk.BOLT"/>, 
    /// 2 <see cref="Interactable.Junk.BOLTNUT"/>, 
    /// 1 <see cref="Interactable.Junk.CORRUGATEDIRON"/>
    /// 1 <see cref="Interactable.Junk.DUCKTAPE"/>
    /// </summary>
    /// <param name="_inventory">players Inventory</param>
    /// <returns>true if player has enough of materials, else false</returns>
    private static bool CanCraftTongs(Inventory _inventory)
    {
        if (_inventory.JunkInventory[Interactable.Junk.BOLT] >= 1
            && _inventory.JunkInventory[Interactable.Junk.BOLTNUT] >= 2
            && _inventory.JunkInventory[Interactable.Junk.CORRUGATEDIRON] >= 1
            && _inventory.JunkInventory[Interactable.Junk.DUCKTAPE] >= 1)
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
    public static bool CraftRocket(Inventory _inventory, bool _sendInfomessage = false)
    {
        if (!CanCraftRocket(_inventory, _sendInfomessage)) return false;

        _inventory.JunkInventory[Interactable.Junk.BOTTLE] -= 1;
        _inventory.JunkInventory[Interactable.Junk.WOODENPLANK] -= 4;
        _inventory.JunkInventory[Interactable.Junk.CORRUGATEDIRON] -= 1;
        _inventory.JunkInventory[Interactable.Junk.CARDBOARD] -= 1;
        _inventory.JunkInventory[Interactable.Junk.BOLT] -= 10;
        _inventory.JunkInventory[Interactable.Junk.BOLTNUT] -= 10;
        _inventory.JunkInventory[Interactable.Junk.COGWHEEL] -= 15;
        _inventory.JunkInventory[Interactable.Junk.DUCKTAPE] -= 4;
        _inventory.JunkInventory[Interactable.Junk.STARTBUTTON] -= 1;
        _inventory.FuelInventory[Interactable.Fuel.GAS] -= 5;

        Debug.Log("Rocked build");

        return true;
    }

    /// <summary>
    /// Total Requirements: 
    /// 1 <see cref="Interactable.Junk.BOTTLE"/>, 
    /// 4 <see cref="Interactable.Junk.WOODENPLANK"/>, 
    /// 1 <see cref="Interactable.Junk.CORRUGATEDIRON"/>, 
    /// 1 <see cref="Interactable.Junk.CARDBOARD"/>, 
    /// 10 <see cref="Interactable.Junk.BOLT"/>, 
    /// 10 <see cref="Interactable.Junk.BOLTNUT"/>,
    /// 15 <see cref="Interactable.Junk.COGWHEEL"/>, 
    /// 1 <see cref="Interactable.Junk.STARTBUTTON"/>, 
    /// 4 <see cref="Interactable.Junk.DUCKTAPE"/>
    /// 1 <see cref="Interactable.Tools.HAMMER"/>, 
    /// 1 <see cref="Interactable.Tools.TONGS"/>, 
    /// 5 <see cref="Interactable.Fuel.GAS"/>, 
    /// </summary>
    /// <param name="_inventory">players Inventory</param>
    /// <returns>true if player has enough of materials, else false</returns>
    private static bool CanCraftRocket(Inventory _inventory, bool _sendInfoMessage)
    {
        if (_inventory.JunkInventory[Interactable.Junk.BOTTLE] < 1)
        {
            if (_sendInfoMessage)
                InfoText.Get.Message($"You are missing {Interactable.Junk.BOTTLE.ToString().ToLower()}s!", 5f, Color.red);
            return false;
        }
        else if (_inventory.JunkInventory[Interactable.Junk.WOODENPLANK] < 4)
        {
            if (_sendInfoMessage)
                InfoText.Get.Message($"You are missing {Interactable.Junk.WOODENPLANK.ToString().ToLower()}s!", 5f, Color.red);
            return false;
        }
        else if (_inventory.JunkInventory[Interactable.Junk.CORRUGATEDIRON] < 1)
        {
            if (_sendInfoMessage)
                InfoText.Get.Message($"You are missing {Interactable.Junk.CORRUGATEDIRON.ToString().ToLower()}s!", 5f, Color.red);
            return false;
        }
        else if (_inventory.JunkInventory[Interactable.Junk.CARDBOARD] < 1)
        {
            if (_sendInfoMessage)
                InfoText.Get.Message($"You are missing {Interactable.Junk.CARDBOARD.ToString().ToLower()}s!", 5f, Color.red);
            return false;
        }
        else if (_inventory.JunkInventory[Interactable.Junk.BOLT] < 10)
        {
            if (_sendInfoMessage)
                InfoText.Get.Message($"You are missing {Interactable.Junk.BOLT.ToString().ToLower()}s!", 5f, Color.red);
            return false;
        }
        else if (_inventory.JunkInventory[Interactable.Junk.BOLTNUT] < 10)
        {
            if (_sendInfoMessage)
                InfoText.Get.Message($"You are missing {Interactable.Junk.BOLTNUT.ToString().ToLower()}s!", 5f, Color.red);
            return false;
        }
        else if (_inventory.JunkInventory[Interactable.Junk.COGWHEEL] < 15)
        {
            if (_sendInfoMessage)
                InfoText.Get.Message($"You are missing {Interactable.Junk.COGWHEEL.ToString().ToLower()}s!", 5f, Color.red);
            return false;
        }
        else if (_inventory.JunkInventory[Interactable.Junk.DUCKTAPE] < 4)
        {
            if (_sendInfoMessage)
                InfoText.Get.Message($"You are missing {Interactable.Junk.DUCKTAPE.ToString().ToLower()}s!", 5f, Color.red);
            return false;
        }
        else if (_inventory.JunkInventory[Interactable.Junk.STARTBUTTON] < 1)
        {
            if (_sendInfoMessage)
                InfoText.Get.Message($"You are missing {Interactable.Junk.STARTBUTTON.ToString().ToLower()}s!", 5f, Color.red);
            return false;
        }
        else if (_inventory.ToolInventory[Interactable.Tools.HAMMER] < 1)
        {
            if (_sendInfoMessage)
                InfoText.Get.Message($"You are missing a {Interactable.Tools.HAMMER.ToString().ToLower()}!", 5f, Color.red);
            return false;
        }
        else if (_inventory.ToolInventory[Interactable.Tools.TONGS] < 1)
        {
            if (_sendInfoMessage)
                InfoText.Get.Message($"You are missing a {Interactable.Tools.TONGS.ToString().ToLower()}!", 5f, Color.red);
            return false;
        }
        else if (_inventory.FuelInventory[Interactable.Fuel.GAS] < 5)
        {
            if (_sendInfoMessage)
                InfoText.Get.Message($"You are missing {Interactable.Fuel.GAS.ToString().ToLower()}!", 5f, Color.red);
            return false;
        }
        else
            return true;

        //if (_inventory.JunkInventory[Interactable.Junk.BOTTLE] >= 1
        //    && _inventory.JunkInventory[Interactable.Junk.WOODENPLANK] >= 4
        //    && _inventory.JunkInventory[Interactable.Junk.CORRUGATEDIRON] >= 1
        //    && _inventory.JunkInventory[Interactable.Junk.CARDBOARD] >= 1
        //    && _inventory.JunkInventory[Interactable.Junk.BOLT] >= 15
        //    && _inventory.JunkInventory[Interactable.Junk.BOLTNUT] >= 15
        //    && _inventory.JunkInventory[Interactable.Junk.COGWHEEL] >= 20
        //    && _inventory.JunkInventory[Interactable.Junk.STARTBUTTON] >= 1
        //    && _inventory.ToolInventory[Interactable.Tools.HAMMER] >= 1
        //    && _inventory.ToolInventory[Interactable.Tools.TONGS] >= 1
        //    && _inventory.FuelInventory[Interactable.Fuel.GAS] >= 5
        //    )
        //    return true;
        //else return false;
    }
    #endregion
}
