using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBlock : StandardBlock {

    protected override void Start() {

        points = ConfigurationUtils.BonusBlockPoints;
        color = "Red";

    }
}
