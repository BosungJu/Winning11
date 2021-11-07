using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : EnemyBase {

    #region Global Variables

    private float left;
    private float right;
    private float y;

    #endregion

    #region Main

    private void Awake() {
        level = 3;
    }

    void Start() {
        left = GoalPost.instance.leftEndPoint;
        right = GoalPost.instance.rightEndPoint;
        y = -GoalPost.instance.transform.position.y;
    }

    #endregion

    #region Functions

    public override void OnHitted(Rigidbody2D ball) {
        base.OnHitted(ball);
        SoundManager.instance.PlayOneShotThere(Sound.Enemy3);
    }

    protected override Vector2 GetDirection(Rigidbody2D ball) {
        Vector2 direction = new Vector3(Random.Range(left, right), y, 0) - transform.position;
        return direction.normalized;
    }

    #endregion
}
