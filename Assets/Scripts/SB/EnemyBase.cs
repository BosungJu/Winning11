using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class EnemyBase : MonoBehaviour, IPlayer {

    #region Global Variables

    protected Rigidbody2D rb;

    #endregion

    #region Init

    protected void Init() {
        rb = GetComponent<Rigidbody2D>();
    }

    #endregion

    #region Functions

    public virtual void OnHitted(Rigidbody2D ball) {
        //TODO
    }

    #endregion
}
