using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiplier : MonoBehaviour
{
    private Rigidbody2D MultiplierRigidbody;
    public static float Speed = 10f;
    public static bool hitMultiplier = false;

    public Coin CoinInstance;

    private void Start()
    {
        MultiplierRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MultiplierRigidbody.velocity = new Vector2(-1f, 0) * Speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Bob")
        {
            hitMultiplier = true;
            CoinInstance.DoublePickedUp();
            Destroy(gameObject);
            //Debug.Log("pickedUp");
        }
    }
}
