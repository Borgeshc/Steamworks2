using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ControllablePlatform : MonoBehaviour 
{
	public float turnSpeed;
	public float minYRotation = -35f;
	public float maxYRotation = 35f; // For proof of concept, basically
	float currentRotation = 0.0f;
	Quaternion yRotation;

	void Update()
	{
		currentRotation += -CrossPlatformInputManager.GetAxisRaw("Vertical") * turnSpeed * Time.deltaTime;
		currentRotation = Mathf.Clamp(currentRotation, minYRotation, maxYRotation);
		transform.rotation = Quaternion.identity * Quaternion.AngleAxis(currentRotation, transform.forward);
	}
}
