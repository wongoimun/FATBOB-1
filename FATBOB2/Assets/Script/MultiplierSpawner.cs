using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplierSpawner : MonoBehaviour
{
    public float WaitTime = 0.1f;
    public GameObject Multiplier;
    public bool ShouldSpawn = true;

    private void Start()
    {
        StartCoroutine(SpawnMultiplierAtIntervals());
    }
    private IEnumerator SpawnMultiplierAtIntervals()
    {
        while (ShouldSpawn)
        {
            if (Time.timeSinceLevelLoad != 0)
            {
                Instantiate(Multiplier, transform.position, Quaternion.identity);
            }
            yield return new WaitForSeconds(WaitTime);
        }
    }
}