using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killerBlock : MonoBehaviour {

    public float speed = 10f;

    private void Update()
    {
        if (transform.position.x <= -4)
        {
            speed = 10;
        }

        if (transform.position.x >= 4)
        {
            speed = -10;
        }

        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
}
