using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBlock : StandardBlock {

    protected string pickupEffect;

    protected override void Start() {

        points = ConfigurationUtils.PickupBlockPoints;
                        
    }
}
