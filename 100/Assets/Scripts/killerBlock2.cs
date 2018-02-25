using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killerBlock2 : MonoBehaviour {

    public float speed = 12f;
	
	// Update is called once per frame
	void Update () {
		
        if (transform.position.x <= -4)
        {
            speed = 12f;
        }

        if (transform.position.x >= 4)
        {
            speed = -12f;
        }

        transform.Translate(speed * Time.deltaTime, 0, 0);
	}
}
