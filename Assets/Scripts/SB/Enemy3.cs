using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : EnemyBase {

    #region Global Variables

    private Vector2 goalDirection;

    #endregion

    #region Main

    private void Awake() {
        level = 3;
    }

    void Start() {
        goalDirection = (-GoalPost.instance.transform.position - transform.position).normalized;
    }

    #endregion

    #region Functions

    public override void OnHitted(Rigidbody2D ball) {
        base.OnHitted(ball);
        SoundManager.instance.PlayOneShotThere(Sound.Enemy3);
    }

    protected override Vector2 GetDirection(Rigidbody2D ball) {
        return goalDirection;
    }

    #endregion
}
