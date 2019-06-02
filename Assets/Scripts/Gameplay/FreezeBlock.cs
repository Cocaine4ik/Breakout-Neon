using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeBlock : PickupBlock {

    private float freezeEffectDuration;
   
    protected override void Start() {

        base.Start();


        color = "Blue";

        effect = PickupEffect.Freezer;
        freezeEffectDuration = ConfigurationUtils.FreezerEffectDuration;
    }

    protected override void OnCollisionEnter2D(Collision2D collision) {

        base.OnCollisionEnter2D(collision);

        EventManager.TriggerEvent(EventName.FreezeEffectActivated, freezeEffectDuration);
    }
}
