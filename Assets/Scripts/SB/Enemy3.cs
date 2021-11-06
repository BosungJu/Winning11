using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : EnemyBase {

    #region Global Variables

    private Vector2 goalDirection;

    #endregion

    #region Main

    void Start() {
        goalDirection = (GoalPost.instance.transform.position - transform.position).normalized;
    }

    #endregion

    #region Functions
    private void Awake()
    {
        level = 3;
    }

    protected override Vector2 GetDirection(Rigidbody2D ball) {
        return goalDirection;
    }

    #endregion
}
