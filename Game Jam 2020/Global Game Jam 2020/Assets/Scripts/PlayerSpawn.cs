using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public int m_StartRoom = 0;
    public GameObject m_ToSpawn;

    private GameObject m_PlayerInScene;

    // Start is called before the first frame update
    void Start()
    {
        // Instanciate Player
        m_PlayerInScene = Instantiate(m_ToSpawn);

        //// prepare Player
        //Rigidbody rigidbody = m_PlayerInScene.AddComponent<Rigidbody>();
        //rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        //
        //m_PlayerInScene.AddComponent<PlayerController>();

        // Set Player in Roommanager
        RoomManager.Get.m_Player = m_PlayerInScene;

        // Change Room
        RoomManager.Get.ToRoom(m_StartRoom);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
