using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : EnemyBase {
    private void Awake()
    {
        level = 2;
    }

    public override void OnHitted(Rigidbody2D ball) {
        base.OnHitted(ball);
        SoundManager.instance.PlayOneShotThere(Sound.Enemy2);
    }
}
