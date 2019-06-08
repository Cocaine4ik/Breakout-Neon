using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpBlock : PickupBlock {

    float speedUpEffectDuration;
    float speedFactor;

    protected override void Start() {

        base.Start();

        color = "Green";

        effect = PickupEffect.Speedup;

        speedUpEffectDuration = ConfigurationUtils.SpeedUpEffectDuration;
        speedFactor = ConfigurationUtils.SpeedFactor;

    }

    protected override void OnCollisionEnter2D(Collision2D collision) {

        base.OnCollisionEnter2D(collision);

        EventManager.TriggerEvent(EventName.SpeedUpEffectActivated, speedUpEffectDuration, speedFactor);

        AudioManager.Play(AudioClipName.SpeedUpEffect);
    }
}
