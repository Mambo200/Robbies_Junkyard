using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Interactable : MonoBehaviour
{
    public abstract EnumType Enumtype { get; }

    /// <summary>
    /// Methods which will be executed at the end of <see cref="Click"/>
    /// </summary>
    [Tooltip("These Methods will be exectued at last!")]
    public UnityEvent m_OnClicked;

    /// <summary>
    /// Methods which will be executed at the end of <see cref="Interact"/>
    /// </summary>
    [Tooltip("These Methods will be exectued at last!")]
    public UnityEvent m_OnInteracted;


    protected virtual void Start()
    {

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    /// <summary>
    /// When object was clicked
    /// </summary>
    public virtual void Click()
    {
        Debug.Log("Just clicked on this object", this.gameObject);


        m_OnClicked.Invoke();
    }

    /// <summary>
    /// interact with object
    /// </summary>
    public virtual void Interact()
    {
        Debug.Log("Just interacted with this object", this.gameObject);


        m_OnInteracted.Invoke();
    }

    public abstract void MoveToInventory(int _addCount);


    /// <summary>
    /// Destroy this Gameobject
    /// </summary>
    public void Destroy() => Destroy(this.gameObject);

    public enum Junk
    {
        /// <summary>
        /// Zahnrad
        /// </summary>
        COGWHEEL,

        /// <summary>
        /// Schraube
        /// </summary>
        BOLT,

        /// <summary>
        /// Schraubenmutter
        /// </summary>
        BOLTNUT,

        /// <summary>
        /// Lampe
        /// </summary>
        LAMP,

        /// <summary>
        /// Flasche
        /// </summary>
        BOTTLE,

        /// <summary>
        /// Klebeband
        /// </summary>
        DUCKTAPE,

        /// <summary>
        /// Pappe
        /// </summary>
        CARDBOARD,

        /// <summary>
        /// Startknopf
        /// </summary>
        STARTBUTTON,

        /// <summary>
        /// Holzbrett
        /// </summary>
        WOODENPLANK,

        /// <summary>
        /// Wellblech
        /// </summary>
        CORRUGATEDIRON
    }

    public enum Tools
    {
        /// <summary>
        /// Hammer
        /// </summary>
        HAMMER,

        /// <summary>
        /// Zange
        /// </summary>
        TONGS
    }

    public enum Fuel
    {
        /// <summary>
        /// Gas
        /// </summary>
        GAS
    }

    public enum EnumType
    {
        /// <summary>
        /// Junk Enum
        /// </summary>
        JUNK,

        /// <summary>
        /// Tools Enum
        /// </summary>
        TOOLS,

        /// <summary>
        /// Fuel Enum
        /// </summary>
        FUEL
    }
}
