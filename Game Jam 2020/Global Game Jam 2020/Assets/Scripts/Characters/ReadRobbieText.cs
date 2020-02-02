using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ReadRobbieText : MonoBehaviour
{
    public Text ChangeText;
    public TextAsset Raw { get; private set; }

    public string[] Lines { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        LoadFile();
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
        ChangeText.text = Lines[MyRandom.GetRandomNumber(Lines.Length)];
    }

}
