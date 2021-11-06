using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boll : MonoBehaviour
{
    public Rigidbody2D boll;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IPlayer player = collision.gameObject.GetComponent<IPlayer>();
        player.OnHitted(boll);
    }
}
