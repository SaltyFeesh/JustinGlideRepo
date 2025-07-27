using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowingAir : MonoBehaviour
{
    bool playerInAir = false;
    public Rigidbody2D playerrb;
    public Vector2 airForce;
    Vector2 speed;
    private void Start()
    {
        playerrb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (playerInAir)
        {
            playerrb.AddForce(airForce);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInAir = true;
            playerrb.GetComponent<Glide>().isInAir = true;
            speed = playerrb.velocity;
            playerrb.velocity =  Vector2.zero;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInAir = false;
            playerrb.GetComponent<Glide>().isInAir = false;
            playerrb.velocity = speed;
        }
    }
}
