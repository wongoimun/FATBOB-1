using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleTeaSpawner : MonoBehaviour
{
    public float WaitTime = 0.1f;
    public GameObject BubbleTea;
    public bool ShouldSpawn = true;
    private void Start()
    {
        StartCoroutine(SpawnBubbleTeaAtIntervals());
    }
    private IEnumerator SpawnBubbleTeaAtIntervals()
    {
        while (ShouldSpawn)
        {
            Instantiate(BubbleTea, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(WaitTime);
        }
    }
}
