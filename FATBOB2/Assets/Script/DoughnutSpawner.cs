using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoughnutSpawner : MonoBehaviour
{
    public float WaitTime = 0.1f;
    public GameObject Doughnut;
    public bool ShouldSpawn = true;
    private void Start()
    {
        StartCoroutine(SpawnDoughnutAtIntervals());
    }
    private IEnumerator SpawnDoughnutAtIntervals()
    {
        while (ShouldSpawn)
        {
            Instantiate(Doughnut, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(WaitTime);
        }
    }
}
