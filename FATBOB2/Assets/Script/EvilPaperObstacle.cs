using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EvilPaperObstacle : MonoBehaviour
{
    public static float Speed = 15f;
    private Rigidbody2D paperRigidbody;
    private void Start()
    {
        paperRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        paperRigidbody.velocity = new Vector2(-1f, 0) * Speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "DeSpawner")
        {
            Destroy(gameObject);
        }

        if (other.gameObject.name == "AngryPhoneObstacle(Clone)")
        {
            Destroy(gameObject);
            Debug.Log("destroyed");
        }

    }
}

