﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : JunkMain
{
    public override Junk JunkType => Junk.LAMP;
    public override void Click()
    {

        base.Click();
    }

    public override void Interact(PlayerController _player)
    {
        base.Interact(_player);
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
