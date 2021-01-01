using System.Security;
using System.Net.Cache;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using UnityEngine;

public class Enemy : Actor
{
    Vector2 origin;
    Vector2 direction;

    RaycastHit2D colliderHit;

    public float radius = 10f; 
    public float distance = 10f;

    public LayerMask playerLayer;

    public Transform player;
    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        direction = Vector2.zero;

        var agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        origin = transform.position;

        colliderHit = Physics2D.CircleCast(origin, radius, direction, distance, playerLayer);
        //Debug.Log("Ran it");
        if (colliderHit.collider == characterCollider)
        {
            //Debug.Log("Detected");
            agent.SetDestination(player.position);
        }
    }
