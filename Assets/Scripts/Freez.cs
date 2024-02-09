using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freez : PickUp
{
    public int FreezTime = 20;


    public override void Picked()
    {
        GameManager.Instance.FreezTime(FreezTime);

        base.Picked();
    }
}
