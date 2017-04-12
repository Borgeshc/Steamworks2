using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class RotatableObject : MonoBehaviour 
{
	public float rotationSpeed;
	public float minYRotation = -35f;
	public float maxYRotation = 35f;
	float currentRotation;
	Quaternion yRotation;

	public bool inverted;
    public enum Rotation
    {
        NONE,
        NEGX, POSX,
        NEGY, POSY,
        NEGZ, POSZ
    };

    public Rotation myRotation = Rotation.NONE;
    
    private void Start()
    {
        currentRotation = transform.rotation.y;
    }

	void Update()
	{
		#if MOBILE_INPUT
		if(!inverted)rotation
		currentRotation = CrossPlatformInputManager.GetAxisRaw("Vertical");
		else
		currentRotation = -CrossPlatformInputManager.GetAxisRaw("Vertical");
		#else
		if(!inverted)
			currentRotation = Input.GetAxis("Vertical");
		else
			currentRotation = -Input.GetAxis("Vertical");
		#endif

		//currentRotation = Mathf.Clamp(currentRotation, minYRotation, maxYRotation);
        switch (myRotation)
        {
            case Rotation.NONE:
                break;
            case Rotation.NEGX:
                transform.Rotate(Vector3.left * currentRotation * rotationSpeed * Time.deltaTime);
                break;
            case Rotation.POSX:
                transform.Rotate(Vector3.right * currentRotation * rotationSpeed * Time.deltaTime);
                break;
            case Rotation.NEGY:
                transform.Rotate(Vector3.down * currentRotation * rotationSpeed * Time.deltaTime);
                break;
            case Rotation.POSY:
                transform.Rotate(Vector3.up * currentRotation * rotationSpeed * Time.deltaTime);
                break;
            case Rotation.NEGZ:
                transform.Rotate(Vector3.back * currentRotation * rotationSpeed * Time.deltaTime);
                break;
            case Rotation.POSZ:
                transform.Rotate(Vector3.forward * currentRotation * rotationSpeed * Time.deltaTime);
                break;
        }
	}
}
