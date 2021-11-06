using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour, IPlayer {

    #region Global Variables

    [Header("SETTINGS")]
    [SerializeField]
    protected float shootPwrMultiplier;
    public int level { get; protected set; }
    private string pName;

    #endregion

    #region Functions

    public void OnHitted(Rigidbody2D ball) {
        float speed = GetSpeed(ball);
        Vector3 direction = GetDirection(ball);
        ball.velocity = Vector3.zero;
        ball.transform.position = transform.position;
        ball.AddForce(direction * speed, ForceMode2D.Impulse);
    }

    protected float GetSpeed(Rigidbody2D ball) {
        return ball.velocity.magnitude * shootPwrMultiplier;
    }

    protected virtual Vector2 GetDirection(Rigidbody2D ball) {
        return (ball.transform.position - transform.position).normalized;
    }

    public string GetName()
    {
        return pName;
    }

    #endregion
}
