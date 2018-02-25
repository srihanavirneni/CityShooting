using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killerBlock6 : MonoBehaviour {

    public float speed = 5f;

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x <= -4)
        {
            speed = 5f;
        }

        if (transform.position.x >= 4)
        {
            speed = -30f;
        }

        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
}
