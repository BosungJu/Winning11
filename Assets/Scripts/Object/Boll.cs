using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boll : MonoBehaviour {

    public Rigidbody2D boll;
    private Vector2 lastVel;

    /// <summary>
    /// ÀÓ½Ã·Î Å×½ºÆ® ¿ë
    /// </summary>
    void Start() {
        boll.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
    }

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

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            IPlayer player = collision.gameObject.GetComponent<IPlayer>();
            player.OnHitted(boll);
        }
        else if (collision.CompareTag("GoalPost")) {
            // TODO goal effect
            // clear ¿¬Ãâ
        }
    }
