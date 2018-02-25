using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Entity : MonoBehaviour, IDamageable {

    public float startingHealth;
    protected float health;
    protected bool IsDead;
    public GameObject deathEffect;
    public Text scoreText;
    public int scoreValue = 2;

	public event System.Action OnDeath;

    protected virtual void Start()
    {
        health = startingHealth;
    }

    public void TakeHit(float damage, RaycastHit hit)
    {
        // We will be Implementing stuff later
        // with the hit variable we just created.

        // We are only using the hit variable for testing.
        TakeDamage(damage);
    }

    public void TakeDamage(float damage)
    {
		health -= damage;

		if (health <= 0 && !IsDead)
		{
            Die();
		}
    }

	protected void Die()
	{
		IsDead = true;
        if (OnDeath != null)
        {

            OnDeath();

		}





        GameObject.Destroy(gameObject);
        GameObject death = (GameObject)Instantiate(deathEffect, transform.position, transform.rotation);
        //Bullet.count += scoreValue;
        //PlayerPrefs.DeleteKey("ScoreText");
        //scoreText.text = "0";
        //GetComponent<Bullet>().scoreText.text = "0";    

    }

}
