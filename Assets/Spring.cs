using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour 
{
	public float force;

	void Start () 
	{
		
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.transform.tag.Equals ("Player")) {

			print ("Happens");
			other.rigidbody.AddForce (transform.up * force, ForceMode.Acceleration);
		}
	}
}
