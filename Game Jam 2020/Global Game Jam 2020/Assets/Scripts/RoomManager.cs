using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    private static RoomManager instance;
    public static RoomManager Get
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<RoomManager>();
            }
            return instance;
        }
    }

    [HideInInspector]
    public GameObject m_Player;
    private int currentRoom;

    public GameObject[] m_Room { get; private set; }
    public GameObject[] m_RoomCameraposition { get; private set; }

    // Start is called before the first frame update
    void Awake()
    {
        Debug.LogWarning("Here are [Input.GetKeyDown] Functions", this);

        instance = this;

        m_Room = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            m_Room[i] = transform.GetChild(i).gameObject;
        } 


        m_RoomCameraposition = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            m_RoomCameraposition[i] = m_Room[i].transform.Find("CameraPosition").gameObject;
        }
    }

    public void ToRoom(int _room)
    {
        if (_room < 0
            || _room >= m_Room.Length)
            return;

        // teleport Player
        m_Player.transform.position = m_Room[_room].transform.position + new Vector3(0, 1.5f, 0);
        m_Player.transform.rotation = m_RoomCameraposition[_room].transform.rotation;

        // teleport Camera and set rotation
        Camera.main.transform.position = m_RoomCameraposition[_room].transform.position;
        Camera.main.transform.rotation = m_RoomCameraposition[_room].transform.rotation;

        // set current room
        currentRoom = _room;
    }

    public void NextRoom() => ToRoom(currentRoom + 1);
    public void PreviousRoom() => ToRoom(currentRoom - 1);

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
            NextRoom();
        else if (Input.GetKeyDown(KeyCode.KeypadMinus))
            PreviousRoom();

    }

    public void GoLeftButton()
    {
        PreviousRoom();
    }

    public void GoRightButton()
    {
        NextRoom();
    }
}
