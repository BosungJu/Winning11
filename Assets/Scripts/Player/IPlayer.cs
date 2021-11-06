using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IPlayer
{
    public void OnHitted(Rigidbody2D ball);
}
