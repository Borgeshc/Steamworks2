using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour 
{
	public float rotationSpeed;
	public bool inverted;

	void Update ()
	{
		if (!inverted)
			transform.Rotate (Vector3.back * rotationSpeed * Time.deltaTime);
		else
			transform.Rotate (Vector3.forward * rotationSpeed * Time.deltaTime);
	}
}
