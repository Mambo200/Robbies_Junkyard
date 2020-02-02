using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public Dictionary<Interactable.Junk, int> JunkInventory { get; private set; }
    public Dictionary<Interactable.Tools, int> ToolInventory { get; private set; }
    public Dictionary<Interactable.Fuel, int> FuelInventory { get; private set; }

    public Inventory()
    {
        // add junk inventory
        JunkInventory = new Dictionary<Interactable.Junk, int>();
        for (int i = 0; i < System.Enum.GetValues(typeof(Interactable.Junk)).Length; i++)
        {
            JunkInventory.Add((Interactable.Junk)i, 0);
        }

        // add tool inventory
        ToolInventory = new Dictionary<Interactable.Tools, int>();
        for (int i = 0; i < System.Enum.GetValues(typeof(Interactable.Tools)).Length; i++)
        {
            ToolInventory.Add((Interactable.Tools)i, 0);
        }

        // add fuel inventory
        FuelInventory = new Dictionary<Interactable.Fuel, int>();
        for (int i = 0; i < System.Enum.GetValues(typeof(Interactable.Fuel)).Length; i++)
        {
            FuelInventory.Add((Interactable.Fuel)i, 0);
        }
    }

    /// <summary>
    /// Add Item to Junk inventory
    /// </summary>
    /// <param name="_item">Item to add</param>
    /// <param name="_amount">amount to add</param>
    public void AddItem(Interactable.Junk _item, int _amount) => JunkInventory[_item] += _amount;

    /// <summary>
    /// Add Item to Tools inventory
    /// </summary>
    /// <param name="_item">Item to add</param>
    /// <param name="_amount">amount to add</param>
    public void AddItem(Interactable.Tools _item, int _amount) => ToolInventory[_item] += _amount;

    /// <summary>
    /// Add Item to Fuel inventory
    /// </summary>
    /// <param name="_item">Item to add</param>
    /// <param name="_amount">amount to add</param>
    public void AddItem(Interactable.Fuel _item, int _amount) => FuelInventory[_item] += _amount;

    public void InventoryItems()
    {
        // Junk
        string toLog = "Junk: ";
        for (int i = 0; i < JunkInventory.Count; i++)
        {
            toLog += ((Interactable.Junk)i).ToString() + " " + JunkInventory[(Interactable.Junk)i].ToString() + " - ";
        }
        Debug.Log(toLog);

        // Tools
        toLog = "Tools: ";
        for (int i = 0; i < ToolInventory.Count; i++)
        {
            toLog += ((Interactable.Tools)i).ToString() + " " + ToolInventory[(Interactable.Tools)i].ToString() + " - ";
        }
        Debug.Log(toLog);

        // Fuel
        toLog = "Fuel: ";
        for (int i = 0; i < FuelInventory.Count; i++)
        {
            toLog += ((Interactable.Fuel)i).ToString() + " " + FuelInventory[(Interactable.Fuel)i].ToString() + " - ";
        }
        Debug.Log(toLog);

    }

    public override string ToString()
    {
        return base.ToString();
    }
}
