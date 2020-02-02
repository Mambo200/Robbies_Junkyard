using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ReadRobbieText : MonoBehaviour
{
    Camera cameraToLookAt;

    public GameObject changeText;

    public TextAsset Raw { get; private set; }

    public string[] Lines { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        LoadFile();

        cameraToLookAt = Camera.main;
    }

    private void Update()
    {
        ChangeText();

        changeText.transform.LookAt(cameraToLookAt.transform);
        changeText.transform.rotation = Quaternion.LookRotation(cameraToLookAt.transform.forward);
    }

    public void LoadFile()
    {
        Raw = Resources.Load<TextAsset>("Text/Robbie_Text");

#if(DEBUG)
        if (Raw == null)
        {
            Debug.LogError("Robbie Text could not be loaded!", this);
            Debug.Break();
        }
#endif

        Lines = Raw.text.Split('\n');
    }

    public void GetRandomText()
    {
        changeText.GetComponent<TextMesh>().text = Lines[MyRandom.GetRandomNumber(Lines.Length)];
    }

    public void ChangeText()
    {
        if (Input.GetMouseButtonDown(0)==true)
        {
            GetRandomText();
        }
    }

}
