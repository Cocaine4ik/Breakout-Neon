using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeBlock : PickupBlock {

    private float freezeEffectDuarion;
    FreezerEffectActivated FreezerEffectActivated = new FreezerEffectActivated();

    protected override void Start() {

        base.Start();

        color = "Blue";

        effect = PickupEffect.Freezer;
    }

    protected override void OnDestroy() {

        base.OnDestroy();
        FreezerEffectActivated.Invoke(freezeEffectDuarion);
    }
}
