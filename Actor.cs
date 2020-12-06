using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
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

    public BoxCollider2D other;

    public float radius = 10f; 
    public float distance = 10f;

    public LayerMask playerLayer;

    RaycastHit2D colliderHit;

    void Start()
    {
        direction = Vector2.zero;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        origin.x = GameObject.Find("Character").transform.position.x;
        origin.y = GameObject.Find("Character").transform.position.y;
    }

    public void Move()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public void EnemyAI()
    {
        colliderHit = Physics2D.CircleCast(origin, radius, direction, distance, playerLayer);

        if (colliderHit.collider == characterCollider)
        {
            Debug.Log("Detected");
        }
    }

    public void Death()
    {

    }
}
