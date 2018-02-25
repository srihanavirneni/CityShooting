using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Gun : MonoBehaviour {
    
    public Transform muzzle;
    public Bullet bullet;
    public float msBetweenShots = 100;
    public float muzzleVelocity = 35;
    public GameObject fireParticle;

    float nextShotTime;

    public void Shoot()
    {
        if (Time.time > nextShotTime)
        {
            nextShotTime = Time.time + msBetweenShots;
			Bullet abullet = Instantiate(bullet, muzzle.position, muzzle.rotation) as Bullet;
			abullet.SetSpeed(muzzleVelocity);
            GameObject fireP = (GameObject)Instantiate(fireParticle, transform.position, transform.rotation);
        }
    }
}
