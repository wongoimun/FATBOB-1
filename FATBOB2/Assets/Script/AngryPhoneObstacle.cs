﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AngryPhoneObstacle : MonoBehaviour
{
    public static float Speed = 10f;
    private Rigidbody2D phoneRigidbody;
    private void Start()
    {
        phoneRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        phoneRigidbody.velocity = new Vector2(-1f, 0) * Speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "DeSpawner")
        {
            Destroy(gameObject);
        }

       if (other.gameObject.name == "EvilPaperObstacle(Clone)")
        {
            Destroy(gameObject);
            Debug.Log("destroyed");
        }
       //testing

    }
}