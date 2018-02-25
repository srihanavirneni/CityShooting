using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour {

    // This is the bullet class
    public Text myscore;
    private int scoreValue = 2;

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
    //public Score scores;
    public static int count;
    //private Color color = Color.red;
	void Start ()
    {
        Debug.Log(" Start");
        count = 0;
     //   scoreText = GetComponent<Text>(); 
        Destroy(gameObject, SecondsToDestroy);
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
        Debug.Log("update");
        float moveDistance = speed * Time.deltaTime;
        CheckCollisions(moveDistance);
        transform.Translate(Vector3.forward * moveDistance);
	}

    void CheckCollisions(float moveDistance)
    {
        Debug.Log("CheckCollisions");
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, moveDistance + WidthOfSkin, collisionMask, QueryTriggerInteraction.Collide))
        {
            OnHitObject(hit);
        }
    }

    void OnHitObject(RaycastHit hit)
    {
     
	//	Debug.LogError("onhitobject");
        IDamageable damageableObject = hit.collider.GetComponent<IDamageable>();
		
        if (damageableObject != null)
        {
#region PlayerPrefs
            count = PlayerPrefs.GetInt("ScoreText", 0);
            count++;
          //  ScoreManager.count = count;
            Debug.Log(" onhitobject : " + count);
            {
                PlayerPrefs.SetInt("ScoreText", count);
                // myscore.text = count.ToString();
                ScoreManager.SetCount(count); 
                //scoreText.GetComponent<GameUI>().fadeOut.enabled = true;
                         //   scoreText.gameObject.SetActive(true);
            }
#endregion
            damageableObject.TakeDamage(damage);
           // if (currentScore > PlayerPrefs.GetInt("ScoreText", 0))
          
        }
		Debug.Log(" onhitobject : ");
	
		
        //GameObject.Destroy(gameObject);
        GameObject.Destroy(gameObject);

    }


    void OnHitObject(Collider col)
    {
       Debug.LogError("onhitobject");
		IDamageable damageableObject = col.GetComponent<IDamageable>();

		if (damageableObject != null)
		{
			damageableObject.TakeDamage(damage);
		}
	
        GameObject.Destroy(gameObject);

   }
}
