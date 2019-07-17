using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pizza : MonoBehaviour
{
    private Rigidbody2D PizzaRigidbody;
    public static float Speed = 10f;
    public static bool hitPizza = false;

    private void Start()
    {
        PizzaRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        PizzaRigidbody.velocity = new Vector2(-1f, 0) * Speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Bob")
        {
            hitPizza = true;
            Destroy(gameObject);
        }
    }
}
