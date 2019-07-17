﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneSpawner : MonoBehaviour
{
    public float WaitTime = 1f;
    public GameObject AngryPhoneObstacle;
    public EvilPaperSpawner Spawner;
    public bool ShouldSpawn = true;

    private void Start()
    {
        StartCoroutine(SpawnAngryPhoneObstacleAtIntervals());
    }
    private IEnumerator SpawnAngryPhoneObstacleAtIntervals()
    {
        while (ShouldSpawn)
        {
            if((int)Time.time % Spawner.WaitTime != 0 && (int)Time.time % Spawner.WaitTime != 1)
            {
                //Debug.Log(Time.time);
                Instantiate(AngryPhoneObstacle, transform.position, Quaternion.identity);
            }
            yield return new WaitForSeconds(WaitTime);
        }
     
    }
}


