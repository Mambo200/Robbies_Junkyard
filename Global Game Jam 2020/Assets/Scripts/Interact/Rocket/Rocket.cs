using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Rocket : Interactable
{
    [SerializeField]
    public GameObject m_DestroyedRocketInScene;
    [SerializeField]
    public GameObject m_RepairedRocketInScene;

    private bool repaired = false;

    public override EnumType Enumtype => EnumType.ROCKET;

    public void SetDestroyedGameobject(GameObject _rocket)
    {
        m_DestroyedRocketInScene = _rocket;
    }

    public void SetRepairedGameobject(GameObject _rocket)
    {
        m_RepairedRocketInScene = _rocket;
    }

    public override void MoveToInventory(int _addCount)
    {
        throw new System.NotImplementedException();
    }
}
