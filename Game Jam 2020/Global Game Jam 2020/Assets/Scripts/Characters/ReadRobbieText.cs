using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ReadRobbieText : MonoBehaviour
{
    [SerializeField]
    private string m_ResourcePath = "";

    public TextAsset Raw { get; private set; }

    public string[] Lines { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        LoadFile();
    }

    public void LoadFile()
    {
        Raw = Resources.Load<TextAsset>(m_ResourcePath);

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

    }

}
