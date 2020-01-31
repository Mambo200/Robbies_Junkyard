using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Interactable : MonoBehaviour
{
    public abstract Junk JunkType { get;  }
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
        m_OnClicked.Invoke();
    }

    /// <summary>
    /// interact with object
    /// </summary>
    public virtual void Interact()
    {
        m_OnInteracted.Invoke();
    }

    /// <summary>
    /// Add Item to inventory
    /// </summary>
    public void MoveToInventory(int _addCount)
    {
        FindObjectOfType<PlayerController>().inventory.PlayerInventory[JunkType] += _addCount;
    }

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
    }
}
