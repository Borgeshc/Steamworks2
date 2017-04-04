using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour 
{
	public float rotationSpeed;

    public enum Rotation
    {
       NONE,
       NEGX, POSX,
       NEGY, POSY,
       NEGZ, POSZ
    };

    public Rotation myRotation = Rotation.NONE;

	void Update ()
	{
        switch(myRotation)
        {
            case Rotation.NONE:
                break;
            case Rotation.NEGX:
                transform.Rotate(Vector3.left * rotationSpeed * Time.deltaTime);
                break;
            case Rotation.POSX:
                transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
                break;
            case Rotation.NEGY:
                transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);
                break;
            case Rotation.POSY:
                transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
                break;
            case Rotation.NEGZ:
                transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
                break;
            case Rotation.POSZ:
                transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
                break;
        }
	}
}
