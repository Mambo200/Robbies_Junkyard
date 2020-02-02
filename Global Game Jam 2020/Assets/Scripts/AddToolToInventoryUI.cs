using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToolToInventoryUI : MonoBehaviour
{
    Inventory inventory;

    [SerializeField] private GameObject m_HammerButton;
    [SerializeField] private GameObject m_TongsButton;

    public Inventory PlayerInventory
    {
        get
        {
            if(inventory == null)
            {
                inventory = FindObjectOfType<PlayerController>().inventory;
            }
            return inventory;
        }
    }

    public void CraftHammer()
    {
        if (Crafting.CraftHammer(PlayerInventory))
        {
            // created
            InfoText.Get.Message("You crafted a hammer!", 5, Color.green);
            m_HammerButton.SetActive(false);
        }
        else
        {
            // not created
            InfoText.Get.Message("Oops, you are missing something for a hammer!", 5, Color.red);
        }
    }

    public void CraftTongs()
    {
        if (Crafting.CraftTongs(PlayerInventory))
        {
            // created
            InfoText.Get.Message("You crafted a tongs!", 5, Color.green);
            m_TongsButton.SetActive(false);
        }
        else
        {
            // not created
            InfoText.Get.Message("Oops, you are missing something for a tongs!", 5, Color.red);
        }

    }
}
