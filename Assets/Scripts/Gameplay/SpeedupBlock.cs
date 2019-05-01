using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedupBlock : PickupBlock {

    protected override void Start() {

        base.Start();
        color = "Green";
        pickupEffect = PickupEffect.Speedup.ToString();
    }
}
