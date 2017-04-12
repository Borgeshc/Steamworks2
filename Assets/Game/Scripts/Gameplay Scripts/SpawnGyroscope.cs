using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGyroscope : MonoBehaviour
{
    public GameObject gyroscope;
    public int maxGyros = 3;
    GameObject spawnPosition;
    int gyroCount;

    void Start()
    {
        spawnPosition = GameObject.Find("GyroscopeSpawnPoint");
        gyroCount = 0;
    }

    public void SpawnGyro()
    {
        if (gyroCount < maxGyros)
        {
            GameObject clone = Instantiate(gyroscope, spawnPosition.transform.position, Quaternion.identity) as GameObject;
            gyroCount++;
        }
    }
}
