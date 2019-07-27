using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Rigidbody2D coinRigidbody;
    public static float Speed = 10f;
    public static int score = 0;
    public bool DoublePickedup;
    //public static float CurrCountDownValue;

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
        //DoublePickedup = Doughnut.DoublePickedup;

        /*if (DoublePickedUp)
        {
            StartCoroutine(StartCountDown());
        }*/

        if ((float)Time.time > pickedTiming && (float)Time.time <= endTiming)
        {
            DoublePickedup = true;
        }
        if ((float)Time.time < pickedTiming || (float)Time.time > endTiming)
        {
            DoublePickedup = false;
        }
    }
    
    public void DoublePickedUp()
    {
        pickedTiming = (float)Time.time;
        endTiming = pickedTiming + 5;
    }

    /*public IEnumerator StartCountDown(float countDownValue = 5)
     {   
         CurrCountDownValue = 5;
         yield return new WaitForSeconds(5.0f);
         Doughnut.hitDoughnut = false;
         while (CurrCountDownValue > 0)
         {
             Debug.Log("Countdown: " + CurrCountDownValue);
             yield return new WaitForSeconds(1.0f);
             CurrCountDownValue--;
             Doughnut.hitDoughnut = false;
         }

     }*/

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.name == "Bob" && !DoublePickedup)
        {
            score++;
            Destroy(gameObject);
        }

        if (other.gameObject.name == "Bob" && DoublePickedup)
        {
            score += 2;
            Destroy(gameObject);
        }

    }
}
