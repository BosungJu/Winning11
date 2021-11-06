using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public Rigidbody2D boll;
    private Vector2 lastVel;
    private bool isEnd = false;

    private void FixedUpdate() {
        lastVel = boll.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Wall")) {
            Vector2 vel = lastVel;
            float speed = vel.magnitude;
            Vector2 direction = Vector2.Reflect(vel.normalized, collision.GetContact(0).normal);
            boll.velocity = direction * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            IPlayer player = collision.gameObject.GetComponent<IPlayer>();
            player.OnHitted(boll);
            ResultData.lastHitAwayPlayer = (EnemyBase)player;
        }
        else if (collision.CompareTag("Home"))
        {
            IPlayer player = collision.gameObject.GetComponent<IPlayer>();
            player.OnHitted(boll);
            ResultData.lastHitHomePlayer = player;
        }


        if (collision.CompareTag("GoalPost") && !isEnd) {
            // TODO goal effect
            isEnd = true;
            // clear
            Debug.Log("Goal");
            ResultData.resultCode = 0;
            UIManager.instance.DisplayResult();
        }
        else if (collision.CompareTag("OutLine") && !isEnd)
        {
            // TODO set result outline and end game
            isEnd = true;
            Debug.Log("out");
            ResultData.resultCode = 1;
            UIManager.instance.DisplayResult();
        }
    }
}
