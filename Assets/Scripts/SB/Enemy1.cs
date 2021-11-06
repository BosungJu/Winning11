using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : EnemyBase {
    private void Awake()
    {
        level = 1;
    }

    public override void OnHitted(Rigidbody2D ball) {
        base.OnHitted(ball);
        SoundManager.instance.PlayOneShotThere(Sound.Enemy1);
    }
}
