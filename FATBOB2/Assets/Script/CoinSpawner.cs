using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public float WaitTime = 0.1f;
    public GameObject Coin;
    public bool ShouldSpawn = true;
    public EvilPaperSpawner paperSpawner;

    private void Start()
    {
        StartCoroutine(SpawnCoinAtIntervals());
    }

    private IEnumerator SpawnCoinAtIntervals()
    {
        while (ShouldSpawn)
        {
            int Remainder = (int)(Time.time % paperSpawner.WaitTime);
            //Debug.Log(Remainder);
            if(Remainder != 1 || Remainder != 4)
            {
                Instantiate(Coin, transform.position, Quaternion.identity);
            }
            yield return new WaitForSeconds(WaitTime);
        }
    } 
}
