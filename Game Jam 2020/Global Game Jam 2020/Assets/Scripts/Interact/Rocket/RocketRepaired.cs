using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketRepaired : Rocket
{
    public UnityEngine.UI.Text m_WinText;

    public void Awake()
    {
        m_WinText.gameObject.SetActive(true);
        FindObjectOfType<PlayerController>().gameObject.SetActive(false);
        m_DestroyedRocketInScene.SetActive(false);
    }

    protected override void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime);
    }
}
