using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killerBlock5 : MonoBehaviour {

    public float speed = 10f;

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x <= -4)
        {
            speed = 16f;
        }

        if (transform.position.x >= 4)
        {
            speed = -10f;
        }

        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
}
