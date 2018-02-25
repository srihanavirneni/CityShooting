using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killerblock4 : MonoBehaviour {

    public float speed = 10f;

    private void Update()
    {
        if (transform.position.x <= -4)
        {
            speed = 5;
        }

        if (transform.position.x >= 4)
        {
            speed = -20;
        }

        transform.Translate(speed * Time.deltaTime, 0, 0);


    }
}
