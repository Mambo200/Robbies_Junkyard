using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public Dictionary<Interactable.Junk, int> PlayerInventory { get; private set; }

    public Inventory()
    {
        PlayerInventory = new Dictionary<Interactable.Junk, int>();

        for (int i = 0; i < System.Enum.GetValues(typeof(Interactable.Junk)).Length; i++)
        {
            PlayerInventory.Add((Interactable.Junk)i, 0);
        }
    }


    public override string ToString()
    {
        if (PlayerInventory.Count == 0) return "No Items";

        string toReturn = "Items: ";

        foreach (KeyValuePair<Interactable.Junk, int> item in PlayerInventory)
        {
            toReturn += item.Key.ToString() + " " + item.Value.ToString() + " - ";
        }

        return toReturn.Remove(toReturn.Length - 2, 2);
    }
}
