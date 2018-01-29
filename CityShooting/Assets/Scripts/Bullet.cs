using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    // This is the bullet class

    // So lets make a variable called a collision Mask and this will be public and make it type of LayerMask.
    // This will trigger when what object we want to collide which we dont want to collide with the player.
    public LayerMask collisionMask;
    // We need speed for our bullet
    public float speed = 10;
    // We need some damage
    float damage = 1;

    // We also want seconds to destroy our bullet
    float SecondsToDestroy = 3;
    // Also this weird name called width of skin
    float WidthOfSkin = .1f;

    void Start ()
    {
        // In the start method we need to destroy our bullet after the seconds to destroy;
        Destroy(gameObject, SecondsToDestroy);

		// We need an array.
		// REMEMBER : that arrays store a fixed amount size of collections of elements so if you want a array of waves so do this:

		// public class Wave
		// {
		//     public float speed = 12;
		//     public float enemyCount;
		//     public float timeBetweenWaves;
		// }

		// IMPORTANT PART OF CODE 
		// [System.Serializable]
	    // public class Wave
	    // {
		//     public int enemyCount;
		//     public float timeBetweenSpawns;
	    // }

        // So now this will be equal to the physics engine and over lap shpere
		Collider[] collisions = Physics.OverlapSphere(transform.position, .1f, collisionMask);
        if (collisions.Length > 0)
        {
            OnHitObject(collisions[0]);
        }
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

	void Update () {
        float moveDistance = speed * Time.deltaTime;
        CheckCollisions(moveDistance);
        transform.Translate(Vector3.forward * moveDistance);
	}

    void CheckCollisions(float moveDistance)
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, moveDistance + WidthOfSkin, collisionMask, QueryTriggerInteraction.Collide))
        {
            OnHitObject(hit);
        }
    }

    void OnHitObject(RaycastHit hit)
    {
        IDamageable damageableObject = hit.collider.GetComponent<IDamageable>();

        if (damageableObject != null)
        {
            damageableObject.TakeDamage(damage);
        }

        GameObject.Destroy(gameObject);
    }

    void OnHitObject(Collider col)
    {
		IDamageable damageableObject = col.GetComponent<IDamageable>();

		if (damageableObject != null)
		{
			damageableObject.TakeDamage(damage);
		}

		GameObject.Destroy(gameObject);
    }
}
