using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class RotatableObject : MonoBehaviour 
{
	public float turnSpeed;
	public float minYRotation = -35f;
	public float maxYRotation = 35f; // For proof of concept, basically
	float currentRotation = 0.0f;
	Quaternion yRotation;

	public bool inverted;

	void Update()
	{
		#if MOBILE_INPUT
		if(!inverted)
		currentRotation += CrossPlatformInputManager.GetAxisRaw("Vertical") * turnSpeed * Time.deltaTime;
		else
		currentRotation += -CrossPlatformInputManager.GetAxisRaw("Vertical") * turnSpeed * Time.deltaTime;
		#else
		if(!inverted)
			currentRotation += Input.GetAxisRaw("Vertical") * turnSpeed * Time.deltaTime;
		else
			currentRotation += -Input.GetAxisRaw("Vertical") * turnSpeed * Time.deltaTime;
		#endif

		currentRotation = Mathf.Clamp(currentRotation, minYRotation, maxYRotation);
		transform.rotation = Quaternion.identity * Quaternion.AngleAxis(currentRotation, transform.forward);
	}
}
