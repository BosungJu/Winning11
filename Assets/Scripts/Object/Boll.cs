using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boll : MonoBehaviour
{
    public Rigidbody2D boll;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            IPlayer player = collision.gameObject.GetComponent<IPlayer>();
            player.OnHitted(boll);
        }
        else if (collision.CompareTag("GoalPost"))
        {
            // TODO goal effect
            // clear ø¨√‚
        }
    }
}
