using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public float WaitTime = 0.1f;
    public GameObject Coin;
    public bool ShouldSpawn = true;
    private void Start()
    {
        StartCoroutine(SpawnCoinAtIntervals());
    }
    private IEnumerator SpawnCoinAtIntervals()
    {
        while (ShouldSpawn)
        {
            Instantiate(Coin, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(WaitTime);
        }
    } 
}
