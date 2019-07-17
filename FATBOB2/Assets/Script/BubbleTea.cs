using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleTea : MonoBehaviour
{
    private Rigidbody2D BubbleTeaRigidbody;
    public static float Speed = 10f;
    public static bool hitBubbleTea = false;

    private void Start()
    {
        BubbleTeaRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        BubbleTeaRigidbody.velocity = new Vector2(-1f, 0) * Speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Bob")
        {
            hitBubbleTea = true;
            Destroy(gameObject);
        }

    }
}
