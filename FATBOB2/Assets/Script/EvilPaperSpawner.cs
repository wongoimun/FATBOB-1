using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilPaperSpawner : MonoBehaviour
{
    public float WaitTime = 1f;
    public GameObject EvilPaperObstacle;
    public bool ShouldSpawn = true;
    public bool SpawnNow = true;

    private void Start()
    {
        StartCoroutine(SpawnEvilPaperObstacleAtIntervals());
    }
    private IEnumerator SpawnEvilPaperObstacleAtIntervals()
    {
        while (ShouldSpawn)
        {
            Instantiate(EvilPaperObstacle, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(WaitTime);


        }
    }
} 

