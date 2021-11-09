using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour, IPlayer {

    #region Global Variables

    [Header("SETTINGS")]
    [SerializeField]
    protected float shootPwrMultiplier;
    [SerializeField]
    protected float maxSpeed;
    public int level { get; protected set; }
    private string pName;

    #endregion

    #region Functions

    public virtual void OnHitted(Rigidbody2D ball) {
        float speed = GetSpeed(ball);
        Vector3 direction = GetDirection(ball);
        ball.velocity = Vector3.zero;
        ball.transform.position = transform.position;
        CameraShake.instance.Shake(direction.normalized);
        ball.AddForce(direction * speed, ForceMode2D.Impulse);
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        EffectPooler.instance.SpawnEffect(Effect.Kick, transform.position, new Vector3(0, 0, rotZ));
        
        if (!GameManager.instance.isEndGame)
            Vibration.CreateOneShot(50);
    }

    protected float GetSpeed(Rigidbody2D ball) {
        float speed = ball.velocity.magnitude * shootPwrMultiplier;
        if (speed > maxSpeed) {
            speed = maxSpeed;
        }
        return speed;
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
