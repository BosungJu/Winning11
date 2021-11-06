using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : EnemyBase {

    #region Global Variables

    private Vector2 goalDirection;

    #endregion

    #region Main

    void Start() {
        goalDirection = (transform.position - GoalPost.instance.transform.position).normalized;
    }

    #endregion

    #region Functions

    protected override Vector2 GetDirection(Rigidbody2D ball) {
        return goalDirection;
    }

    #endregion
}
