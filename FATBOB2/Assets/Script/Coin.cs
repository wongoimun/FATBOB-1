using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Rigidbody2D coinRigidbody;
    public static float Speed = 12f;
    public static int score = 0;

    public bool DoublePickedup;
    public float pickedTiming = 999999999999;
    public float endTiming;


    private void Start()
    {
        coinRigidbody = GetComponent<Rigidbody2D>();
        DoublePickedup = false;
    }

    private void Update()
    {
        coinRigidbody.velocity = new Vector2(-1f, 0) * Speed;

        if ((float)Time.time > pickedTiming - 2 && (float)Time.time <= endTiming)
        {
            DoublePickedup = true;
        }
        if ((float)Time.time < pickedTiming || (float)Time.time > endTiming)
        {
            DoublePickedup = false;
        }
        //Debug.Log(DoublePickedup);
    }
    
    public void DoublePickedUp()
    {
        DoublePickedup = true;
        pickedTiming = (float)Time.time;
        endTiming = pickedTiming + 5;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Bob" && DoublePickedup)
        {
            score += 2;
            //Debug.Log("double");
            Destroy(gameObject);
        }

        if (other.gameObject.name == "Bob" && !DoublePickedup)
        {
            score++;
            Destroy(gameObject);
        }

    }
}
