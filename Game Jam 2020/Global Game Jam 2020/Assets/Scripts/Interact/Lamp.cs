using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : Interactable
{
    public override Junk JunkType => Junk.LAMP;
    public override void Click()
    {
        Debug.Log("Just clicked on this object", this.gameObject);

        base.Click();
    }

    public override void Interact()
    {
        Debug.Log("Just interacted with this object", this.gameObject);


        base.Interact();
    }

    // Start is called before the first frame update
    protected override void Start()
    {




        // base comes at last!
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {




        // base comes at last!
        base.Update();
    }
}
