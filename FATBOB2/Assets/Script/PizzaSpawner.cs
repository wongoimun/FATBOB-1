using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaSpawner : MonoBehaviour
{
    public float WaitTime = 0.1f;
    public GameObject Pizza;
    public bool ShouldSpawn = true;
    private void Start()
    {
        StartCoroutine(SpawnPizzaAtIntervals());
    }
    private IEnumerator SpawnPizzaAtIntervals()
    {
        while (ShouldSpawn)
        {
            if (Time.timeSinceLevelLoad != 0)
            {
                Instantiate(Pizza, transform.position, Quaternion.identity);
            }
            yield return new WaitForSeconds(WaitTime);
        }
    }
}
