using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeBlock : PickupBlock {

    protected override void Start() {

        base.Start();
        color = "Blue";
        pickupEffect = PickupEffect.Freezer.ToString();

    }
}
