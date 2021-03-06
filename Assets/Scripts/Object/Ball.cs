using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public Rigidbody2D ball;
    private Vector2 lastVel;
    private bool isEnd = false;

    private void FixedUpdate() {
        lastVel = ball.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Wall")) {
            Vector2 vel = lastVel;
            float speed = vel.magnitude;
            ContactPoint2D contact = collision.GetContact(0);
            float rotZ = contact.point.x > 0 ? -90 : 90;
            Vector2 direction = Vector2.Reflect(vel.normalized, contact.normal);
            ball.velocity = direction * speed;
            SoundManager.instance.PlayOneShotThere(Sound.Wall);
            EffectPooler.instance.SpawnEffect(Effect.Bounce, contact.point, new Vector3(0, 0, rotZ));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            IPlayer player = collision.gameObject.GetComponent<IPlayer>();
            player.OnHitted(ball);
            ResultData.lastHitAwayPlayer = (EnemyBase)player;
        }
        else if (collision.CompareTag("Home"))
        {
            IPlayer player = collision.gameObject.GetComponent<IPlayer>();
            player.OnHitted(ball);
            ResultData.lastHitHomePlayer = player;
        }


        if (collision.CompareTag("GoalPost") && !isEnd) {
            // TODO goal effect
            isEnd = true;
            // clear
            Debug.Log("Goal");
            ResultData.resultCode = 0;
            GameManager.instance.endGameEvnent();
            EffectPooler.instance.SpawnEffect(Effect.Goal, collision.transform.position, Vector3.zero);
            ball.velocity = Vector2.zero;
        }
        else if (collision.CompareTag("OutLine") && !isEnd)
        {
            // TODO set result outline and end game
            isEnd = true;
            Debug.Log("out");
            ResultData.resultCode = 1;
            GameManager.instance.endGameEvnent();
            ball.velocity = Vector2.zero;
        }
    }
}
