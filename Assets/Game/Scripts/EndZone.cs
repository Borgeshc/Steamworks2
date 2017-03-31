using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndZone : MonoBehaviour 
{
	public string nextLevel;

	void OnTriggerEnter(Collider other)
	{
		if (other.tag.Equals ("Player"))
			SceneManager.LoadScene (nextLevel);
	}
}
