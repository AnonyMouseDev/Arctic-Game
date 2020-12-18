using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using UnityEngine;

public class Actor : MonoBehaviour
{

    //components
    public Rigidbody2D rb;
    public BoxCollider2D bc;

    public BoxCollider2D characterCollider;

    //move speed
    public float moveSpeed = 10f; 

    //vectors
    Vector2 movement;
    Vector2 origin;
    Vector2 direction;
    Vector2 originPlayer;
    Vector2 directionPlayer;

    public BoxCollider2D other;

    public float radius = 10f; 
    public float distance = 10f;
    public float radiusPlayer = 10f;
    public float distancePlayer = 10f;

    public LayerMask playerLayer;
    public LayerMask EnemyLayer;

    RaycastHit2D colliderHit;
    RaycastHit2D colliderHitEnemy;

    public Transform Player; 

    public NavMeshAgent agent;

    //public Transform Enemy;

    void Start()
    {
        direction = Vector2.zero;
        directionPlayer = Vector2.zero;

        //agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        //Enemy = GetComponent<Transform>(); 
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        originPlayer.x = GameObject.FindWithTag("Player").transform.position.x;
        originPlayer.y = GameObject.FindWithTag("Player").transform.position.y;

        origin.x = GameObject.FindWithTag("Enemy").transform.position.x;
        origin.y = GameObject.FindWithTag("Enemy").transform.position.y;
    }

    public void Move()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        colliderHitEnemy = Physics2D.CircleCast(originPlayer, radiusPlayer, directionPlayer, distancePlayer, EnemyLayer);
        Debug.Log("Running");
        if (colliderHitEnemy.collider == other)
        {
            Debug.Log("Detected Enemy");
        }

    }

    public void EnemyAI()
    {
        colliderHit = Physics2D.CircleCast(origin, radius, direction, distance, playerLayer);
        Debug.Log("Ran it");
        if (colliderHit.collider == characterCollider)
        {
            //agent.SetDestination(Player.position);
            Debug.Log("Detected");
        }
    }

    public void Death()
    {
        
    }
}
