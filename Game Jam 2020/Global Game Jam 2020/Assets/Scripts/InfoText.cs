using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoText : MonoBehaviour
{
    private static  InfoText instance;

    public UnityEngine.UI.Text infotextText;

    private float duration;

    public static InfoText Get
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<InfoText>();
            }
            return instance;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        infotextText = GetComponent<UnityEngine.UI.Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (duration <= 0) infotextText.text = "";
        else duration -= Time.deltaTime;
    }

    public void Message(string _message, float _duration) => Message(_message, _duration, Color.black);

    public void Message(string _message, float _duration, Color _color)
    {
        infotextText.text = _message;
        infotextText.color = _color;

        duration = _duration;
    }
}
