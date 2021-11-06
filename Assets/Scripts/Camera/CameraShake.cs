using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : Singleton<CameraShake>
{
    public Transform cam;
    private Coroutine routine;
    private Vector3 origin = new Vector3(0, 0, -10);

    private IEnumerator ShakeCamera(Vector2 direction)
    {
        direction.Normalize();

        for (int i = 0; i < 3; ++i)
        {
            cam.position += (Vector3)direction * 0.04f;
            yield return new WaitForSeconds(0.02f);
        }

        for (int i = 0; i < 3; ++i)
        {
            cam.position -= (Vector3)direction * 0.08f;
            yield return new WaitForSeconds(0.02f);
        }

        for (int i = 0; i < 3; ++i)
        {
            cam.position += (Vector3)direction * 0.04f;
            yield return new WaitForSeconds(0.02f);
        }

        cam.position = origin;
    }

    public void Shake(Vector2 direction)
    {
        if (routine != null)
        {
            StopCoroutine(routine);
            cam.position = origin;
        }

        routine = StartCoroutine(ShakeCamera(direction));
    }
}
