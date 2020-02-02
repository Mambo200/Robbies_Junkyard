using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketDestroyed : Rocket
{
    private AudioSource audioSource;

    public void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public override void Interact(PlayerController _player)
    {
        if (Crafting.CraftRocket(_player.inventory))
        {
            // Player has enough materials to build
            m_RepairedRocketInScene.SetActive(true);
        }
        else
        {
            // player is missing something
            audioSource.Play();
        }


    }
}
