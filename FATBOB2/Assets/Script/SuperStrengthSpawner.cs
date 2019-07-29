using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperStrengthSpawner : MonoBehaviour
{
    public float WaitTime = 0.1f;
    public GameObject SuperStrength;
    public bool ShouldSpawn = true;

    private void Start()
    {
        StartCoroutine(SpawnSuperStrengthAtIntervals());
    }
    private IEnumerator SpawnSuperStrengthAtIntervals()
    {
        while (ShouldSpawn)
        {
            if (Time.timeSinceLevelLoad != 0)
            {
                Instantiate(SuperStrength, transform.position, Quaternion.identity);
            }
            yield return new WaitForSeconds(WaitTime);
        }
    }
}