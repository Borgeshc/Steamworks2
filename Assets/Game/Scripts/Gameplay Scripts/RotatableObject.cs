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
    //public enum Rotation
    //{
    //    NONE,
    //    NEGX, POSX,
    //    NEGY, POSY,
    //    NEGZ, POSZ
    //};

    //public Rotation myRotation = Rotation.NONE;
    
    private void Start()
    {
        currentRotation = transform.rotation.y;
    }

	void Update()
	{
#if MOBILE_INPUT
        if (!inverted)
            currentRotation += CrossPlatformInputManager.GetAxisRaw("Horizontal") * rotationSpeed * Time.deltaTime;
        else
            currentRotation += -CrossPlatformInputManager.GetAxisRaw("Horizontal") * rotationSpeed * Time.deltaTime;
#else
		if(!inverted)
			currentRotation += Input.GetAxisRaw("Horizontal") * rotationSpeed * Time.deltaTime;
		else
			currentRotation += -Input.GetAxisRaw("Horizontal") * rotationSpeed * Time.deltaTime;
#endif

        currentRotation = Mathf.Clamp(currentRotation, minYRotation, maxYRotation);
        transform.rotation = Quaternion.identity * Quaternion.AngleAxis(currentRotation, transform.forward);

        //currentRotation = Mathf.Clamp(currentRotation, minYRotation, maxYRotation);
        //switch (myRotation)
        //{
        //    case Rotation.NONE:
        //        break;
        //    case Rotation.NEGX:
        //        transform.Rotate(Vector3.left * currentRotation * rotationSpeed * Time.deltaTime);
        //        break;
        //    case Rotation.POSX:
        //        transform.Rotate(Vector3.right * currentRotation * rotationSpeed * Time.deltaTime);
        //        break;
        //    case Rotation.NEGY:
        //        transform.Rotate(Vector3.down * currentRotation * rotationSpeed * Time.deltaTime);
        //        break;
        //    case Rotation.POSY:
        //        transform.Rotate(Vector3.up * currentRotation * rotationSpeed * Time.deltaTime);
        //        break;
        //    case Rotation.NEGZ:
        //        transform.Rotate(Vector3.back * currentRotation * rotationSpeed * Time.deltaTime);
        //        break;
        //    case Rotation.POSZ:
        //        transform.Rotate(Vector3.forward * currentRotation * rotationSpeed * Time.deltaTime);
        //        break;
        //}
	}    
}
