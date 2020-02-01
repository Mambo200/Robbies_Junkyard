using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : JunkMain
{
    public override Junk JunkType => Junk.BOLT;

    public override void Click()
    {

        base.Click();
    }

    public override void Interact()
    {


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
