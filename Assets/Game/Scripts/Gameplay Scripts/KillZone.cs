using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour 
{
	GameObject playerSpawnPoint;

	void Start()
	{
		playerSpawnPoint = GameObject.Find ("GyroscopeSpawnPoint");
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") 
		{
			other.gameObject.transform.position = playerSpawnPoint.transform.position;
		}
	}
}
