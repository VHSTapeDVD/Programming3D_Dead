using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;

    public float health = 2;
    public Transform player;

    public LayerMask IsGrunded, whatIsPlayer;

    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    public float sightRange;
    public bool playerInSightRange;
    
    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    
    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

        if (!playerInSightRange) Patrolling();
        else RunAway();
    }

    private void Patrolling() 
    {
        if (!walkPointSet) SearchWalkPoint();
        else
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, IsGrunded))
        {
            walkPointSet = true;
        }
    }
    private void RunAway()
    {
        Vector3 runAwayDirection = transform.position - player.position;
        Vector3 newRunAwayPos = transform.position + runAwayDirection;

        agent.SetDestination(newRunAwayPos);
        
    }
   
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0) Invoke("PickUpEnemy", 0.5f);
    }

    private void PickUpEnemy()
    {
        
    }
}
