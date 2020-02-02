using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{
    private static ItemsManager instance;
    public static ItemsManager Get
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<ItemsManager>();
            }
            return instance;
        }
    }

    public bool GameItems { get => !m_ItemsButton.activeSelf; }

    [Header("Root Gameobjects")]
    [SerializeField] private GameObject m_ChangeRoomsRoot;
    [SerializeField] private GameObject m_ItemsButton;
    //[SerializeField] private GameObject m_SettingsMenu;
    [SerializeField] private GameObject m_InventoryUI;
    [SerializeField] private GameObject m_BuildTool;

    [Header("Text")]
    [SerializeField] private UnityEngine.UI.Text m_Ducktape;
    [SerializeField] private UnityEngine.UI.Text m_Flasche;
    [SerializeField] private UnityEngine.UI.Text m_Holzbrett;
    [SerializeField] private UnityEngine.UI.Text m_Schraubenmutter;
    [SerializeField] private UnityEngine.UI.Text m_Pappe;
    [SerializeField] private UnityEngine.UI.Text m_Schraube;
    [SerializeField] private UnityEngine.UI.Text m_Startknopf;
    [SerializeField] private UnityEngine.UI.Text m_Wellblech;
    [SerializeField] private UnityEngine.UI.Text m_Zahnrad;
    [SerializeField] private UnityEngine.UI.Text m_Gas;
    [SerializeField] private UnityEngine.UI.Text m_Zange;
    [SerializeField] private UnityEngine.UI.Text m_Hammer;

    [Header("Infotext")]
    [SerializeField] private UnityEngine.UI.Text m_InfoText;


    private Inventory playerInventory;

    public void SetInventory(Inventory _inventory)
    {
        playerInventory = _inventory;
    }

    private void Start()
    {
        instance = this;
    }

    public void PauseGame()
    {
        m_ChangeRoomsRoot.SetActive(false);
        m_ItemsButton.SetActive(false);

        m_InventoryUI.SetActive(true);
        FillInventory();
        //m_SettingsMenu.SetActive(true);
        m_BuildTool.SetActive(true);
    }

    public void ResumeGame()
    {
        m_ChangeRoomsRoot.SetActive(true);
        m_ItemsButton.SetActive(true);

        m_InventoryUI.SetActive(false);
        //m_SettingsMenu.SetActive(false);
        m_BuildTool.SetActive(false);
    }

    /// <summary>
    /// Refresh inventory text
    /// </summary>
    public void FillInventory()
    {
        if (playerInventory == null) GetInventory();

        m_Ducktape.text = playerInventory.JunkInventory[Interactable.Junk.DUCKTAPE].ToString();
        m_Flasche.text = playerInventory.JunkInventory[Interactable.Junk.BOTTLE].ToString();
        m_Holzbrett.text = playerInventory.JunkInventory[Interactable.Junk.WOODENPLANK].ToString();
        m_Schraubenmutter.text = playerInventory.JunkInventory[Interactable.Junk.BOLTNUT].ToString();
        m_Pappe.text = playerInventory.JunkInventory[Interactable.Junk.CARDBOARD].ToString();
        m_Schraube.text = playerInventory.JunkInventory[Interactable.Junk.BOLT].ToString();
        m_Startknopf.text = playerInventory.JunkInventory[Interactable.Junk.STARTBUTTON].ToString();
        m_Wellblech.text = playerInventory.JunkInventory[Interactable.Junk.CORRUGATEDIRON].ToString();
        m_Zahnrad.text = playerInventory.JunkInventory[Interactable.Junk.COGWHEEL].ToString();

        m_Zange.text = playerInventory.ToolInventory[Interactable.Tools.TONGS].ToString();
        m_Hammer.text = playerInventory.ToolInventory[Interactable.Tools.HAMMER].ToString();

        m_Gas.text = playerInventory.FuelInventory[Interactable.Fuel.GAS].ToString();
    }

    private void GetInventory() => playerInventory = FindObjectOfType<PlayerController>().inventory;
}
