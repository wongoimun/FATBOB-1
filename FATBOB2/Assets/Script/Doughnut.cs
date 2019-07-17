using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doughnut : MonoBehaviour
{
    private Rigidbody2D DoughnutRigidbody;
    public static float Speed = 10f;
    public static bool hitDoughnut = false;

    private void Start()
    {
        DoughnutRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        DoughnutRigidbody.velocity = new Vector2(-1f, 0) * Speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Bob")
        {
            hitDoughnut = true;
            Destroy(gameObject);
        }
    }
}
/*private Rigidbody2D DoughnutRigidbody;
    //public Coin coin;
    public static float Speed = 10f;

    public static bool DoublePickedup;
    private float time;
    private float timer = 0;
    private float seconds = 3;

    private void Start()
    {
        DoughnutRigidbody = GetComponent<Rigidbody2D>();
        DoublePickedup = false;
    }

    private void Update()
    {
        DoughnutRigidbody.velocity = new Vector2(-1f, 0) * Speed;
        if (DoublePickedup)
        {
            timer += Time.deltaTime;
            Debug.Log("Timer:" + timer);
            if (timer > seconds)
            {
                Debug.Log("STOP");
                timer = 0;
                DoublePickedup = false;
            }
        }
        if(DoublePickedup && Time.time == time + 2)
        {
            DoublePickedup = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Bob")
        {
            Debug.Log("hit");
            DoublePickedup = true;
            Debug.Log("picked up doughnut");
            //StartCoroutine(StartCountDown(5f));
            Destroy(gameObject);
            Debug.Log("Hiie");
            while (timer < seconds)
            {
                timer += Time.deltaTime;
                Debug.Log("Timer:" + timer);
            }
            if (timer > seconds)
            {
                Debug.Log("STOP");
                timer = 0;
                DoublePickedup = false;
            }
            //time = Time.time;
            //Debug.Log(time);
            //Debug.Log(time + 2);

        }

    }

   public IEnumerator StartCountDown(float waitTime)
    {
       // if (DoublePickedup)
        //{
            Debug.Log("Countdown Start");
            yield return new WaitForSeconds(waitTime);
            Debug.Log("Countdown Stop");
            DoublePickedup = false;
        //}
    }
}*/