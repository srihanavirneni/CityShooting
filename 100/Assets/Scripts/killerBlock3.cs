using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killerBlock3 : MonoBehaviour {

    public float speed = 3f;

    private void Update()
    {
        if (transform.position.x <= -4)
        {
            speed = 3f;
        }

        if (transform.position.x >= 4)
        {
            speed = -3f;
        }

        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
}
