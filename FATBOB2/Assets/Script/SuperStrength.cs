using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperStrength : MonoBehaviour
{
    private Rigidbody2D SuperStrengthRigidbody;
    public static float Speed = 10f;
    public static bool hitSuperStrength = false;

    private void Start()
    {
        SuperStrengthRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        SuperStrengthRigidbody.velocity = new Vector2(-1f, 0) * Speed;

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Bob")
        {
            hitSuperStrength = true;
            GameManager.StrengthPickedup = true;
            GameManager.Strength();
            Destroy(gameObject);
        }
    }
}
