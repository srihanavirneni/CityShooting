using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : Entity {

    public enum State {Idle, Chasing, Attacking}
    State currentState;

    Color originalColor;
	//public Score scores;

	NavMeshAgent pathfinder;
    Transform target;
    Entity targetEntity;
    Material enemyMaterial;

    float attackDistanceTreshold = 1.5f;
    float timeBetweenAttacks = 1;
    float damage = 1;

    float nextAttackTime;
    float CollisionRadius;
    float targetCollisionRadius;

    bool hasTarget;

	protected override void Start () {
        base.Start();
        Debug.Log(" Start");

        pathfinder = GetComponent<NavMeshAgent>();
        enemyMaterial = GetComponent<Renderer>().material;
        originalColor = enemyMaterial.color;

        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
			currentState = State.Chasing;
            hasTarget = true;

			target = GameObject.FindGameObjectWithTag("Player").transform;
			targetEntity = target.GetComponent<Entity>();
			targetEntity.OnDeath += OnTargetDeath;

			CollisionRadius = GetComponent<CapsuleCollider>().radius;
			targetCollisionRadius = target.GetComponent<CapsuleCollider>().radius;
			StartCoroutine(UpdatePath());
        }

	}
	
    void OnTargetDeath()
    {
        Debug.Log(" on target  death");
	

		hasTarget = false;
        currentState = State.Idle;
    }

	void Update () {

        if (hasTarget)
        {
			if (Time.time > nextAttackTime)
			{
				float sqrDstToTarget = (target.position - transform.position).sqrMagnitude;

				if (sqrDstToTarget < Mathf.Pow(attackDistanceTreshold + CollisionRadius + targetCollisionRadius, 2))
				{
					nextAttackTime = Time.time + timeBetweenAttacks;
					StartCoroutine(Attack());
                    {
                        PlayerPrefs.DeleteKey("ScoreText");
                        PlayerPrefs.SetInt("ScoreText", 0);
                    }
				}
             ///   if (GameObject.FindGameObjectWithTag("Player") != null)
            
			}
        }


	}

    IEnumerator Attack()
    {
        currentState = State.Attacking;
        pathfinder.enabled = false;
		Vector3 dirToTarget = (target.position - transform.position).normalized;
		Vector3 AttackPosition = target.position - dirToTarget * (CollisionRadius);
        Vector3 originalPosition = transform.position;

        float attackSpeed = 3;
        float percent = 0;

        enemyMaterial.color = Color.red;
        bool hasAppliedDamage = false;

        while (percent <= 1)
        {
            if (percent >= .5f && !hasAppliedDamage)
            {
                hasAppliedDamage = true;
                targetEntity.TakeDamage(damage);
            }

            percent += Time.deltaTime * attackSpeed;
            float interpolation = (-Mathf.Pow(percent, 2) + percent) * 4;
            transform.position = Vector3.Lerp(originalPosition, AttackPosition, interpolation);

            yield return null;
        }

        enemyMaterial.color = originalColor;
        currentState = State.Chasing;
        pathfinder.enabled = true;
    }

    IEnumerator UpdatePath()
    {
        float refreshRate = .25f;

        while (hasTarget)
        {
            if (currentState == State.Chasing)
            {
                Vector3 dirToTarget = (target.position - transform.position).normalized;
                Vector3 targetPosition = target.position - dirToTarget * (CollisionRadius + targetCollisionRadius + attackDistanceTreshold/2);
                if (!IsDead)
                {
                    pathfinder.SetDestination(targetPosition);
                }
            }    

            yield return new WaitForSeconds(refreshRate);
        }
    }
}
