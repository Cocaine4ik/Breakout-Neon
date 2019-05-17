using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBlock : StandardBlock {

    protected PickupEffect effect;
    protected override void Start() {

        points = ConfigurationUtils.PickupBlockPoints;
                        
    }
}
