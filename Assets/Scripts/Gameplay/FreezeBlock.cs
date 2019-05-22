using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeBlock : PickupBlock {

    private float freezeEffectDuration;
    FreezerEffectActivated freezerEffectActivated = new FreezerEffectActivated();

    
    protected override void Start() {

        base.Start();


        color = "Blue";

        effect = PickupEffect.Freezer;
        freezeEffectDuration = ConfigurationUtils.FreezerEffectDuarion;
    }

    protected override void OnCollisionEnter2D(Collision2D collision) {

        base.OnCollisionEnter2D(collision);

        EventManager.TriggerEvent("FreezeEffectActivated", freezeEffectDuration);
    }
}
