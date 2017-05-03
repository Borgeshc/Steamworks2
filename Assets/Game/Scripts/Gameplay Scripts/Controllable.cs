using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Controllable : MonoBehaviour
{
    public float rotationSpeed;
    public float minTurnAngle;
    public float maxTurnAngle;
    [HideInInspector]
    public float horizontalTurnAngle;

    public float horizontalMoveSpeed;
    public float verticalMoveSpeed;

    public float movementMinXClamp;
    public float movementMaxXClamp;

    public float movementMinYClamp;
    public float movementMaxYClamp;

    public bool hasVerticalMovement;
    public bool hasHorizontalMovement;
    public bool canRotate;

    float horizontal;
    float vertical;
    Quaternion currentRotation;

    public enum Rotation
    {
        NONE,
        NEGX, POSX,
        NEGY, POSY,
        NEGZ, POSZ
    };

    public Rotation myRotation = Rotation.NONE;
    
    void Awake()
    {
        currentRotation = transform.localRotation;
    }

    void FixedUpdate()
    {
#if MOBILE_INPUT

        if(canRotate)
        {
            horizontalTurnAngle = -CrossPlatformInputManager.GetAxisRaw("Horizontal") * rotationSpeed;
            horizontalTurnAngle = Mathf.Clamp(horizontalTurnAngle, -maxTurnAngle, maxTurnAngle);

            if (CrossPlatformInputManager.GetAxisRaw("Horizontal") != 0)
            {
                ChooseRotation();
            }
        }

        horizontal += CrossPlatformInputManager.GetAxisRaw("Horizontal") * horizontalMoveSpeed * Time.deltaTime;
        vertical += CrossPlatformInputManager.GetAxisRaw("Vertical") * verticalMoveSpeed * Time.deltaTime;


#else
		
        if(canRotate)
        {
            horizontalTurnAngle = -(Input.GetAxis("Horizontal2") * rotationSpeed;
            horizontalTurnAngle = Mathf.Clamp(horizontalTurnAngle, -maxTurnAngle, maxTurnAngle);

            if (Input.GetAxis("Horizontal2") != 0)
            {
                ChooseRotation();
            }

        }

        horizontal += Input.GetAxisRaw("Horizontal") * horizontalMoveSpeed * Time.deltaTime;
		vertical += Input.GetAxisRaw("Vertical") * verticalMoveSpeed * Time.deltaTime;
#endif

        horizontal = Mathf.Clamp(horizontal, movementMinXClamp, movementMaxXClamp);
        vertical = Mathf.Clamp(vertical, movementMinYClamp, movementMaxYClamp);

        if (hasVerticalMovement)
            transform.position = new Vector3(transform.position.x, vertical, 0);

        if (hasHorizontalMovement)
            transform.position = new Vector3(horizontal, transform.position.y, 0);
    }

    void ChooseRotation()
    {
        switch (myRotation)
        {
            case Rotation.NONE:
                break;
            case Rotation.NEGX:
                transform.Rotate((Vector3.left * horizontalTurnAngle * Time.deltaTime));
                ClampRotationX(-maxTurnAngle, maxTurnAngle, 0);
                break;
            case Rotation.POSX:
                transform.Rotate((Vector3.right * horizontalTurnAngle * Time.deltaTime));
                ClampRotationX(-maxTurnAngle, maxTurnAngle, 0);
                break;
            case Rotation.NEGY:
                transform.Rotate((Vector3.down * horizontalTurnAngle * Time.deltaTime));
                ClampRotationY(-maxTurnAngle, maxTurnAngle, 0);
                break;
            case Rotation.POSY:
                transform.Rotate((Vector3.up * horizontalTurnAngle * Time.deltaTime));
                ClampRotationY(-maxTurnAngle, maxTurnAngle, 0);
                break;
            case Rotation.NEGZ:
                transform.Rotate((Vector3.back * horizontalTurnAngle * Time.deltaTime));
                ClampRotationZ(-maxTurnAngle, maxTurnAngle, 0);
                break;
            case Rotation.POSZ:
                transform.Rotate((Vector3.forward * horizontalTurnAngle * Time.deltaTime));
                ClampRotationZ(-maxTurnAngle, maxTurnAngle, 0);
                break;
        }
    }


    void ClampRotationX(float minAngle, float maxAngle, float clampAroundAngle = 0)
    {
        //clampAroundAngle is the angle you want the clamp to originate from
        //For example a value of 90, with a min=-45 and max=45, will let the angle go 45 degrees away from 90

        //Adjust to make 0 be right side up
        clampAroundAngle += 180;

        //Get the angle of the x axis and rotate it up side down
        float x = transform.rotation.eulerAngles.x - clampAroundAngle;

        x = WrapAngle(x);

        //Move range to [-180, 180]
        x -= 180;

        //Clamp to desired range
        x = Mathf.Clamp(x, minAngle, maxAngle);

        //Move range back to [0, 360]
        x += 180;

        //Set the angle back to the transform and rotate it back to right side up
        transform.rotation = Quaternion.Euler(x + clampAroundAngle, Mathf.Clamp(transform.rotation.eulerAngles.y, currentRotation.y, currentRotation.y), Mathf.Clamp(transform.rotation.eulerAngles.z, currentRotation.z, currentRotation.z));
    }

    void ClampRotationY(float minAngle, float maxAngle, float clampAroundAngle = 0)
    {
        //clampAroundAngle is the angle you want the clamp to originate from
        //For example a value of 90, with a min=-45 and max=45, will let the angle go 45 degrees away from 90

        //Adjust to make 0 be right side up
        clampAroundAngle += 180;

        //Get the angle of the y axis and rotate it up side down
        float y = transform.rotation.eulerAngles.y - clampAroundAngle;

        y = WrapAngle(y);

        //Move range to [-180, 180]
        y -= 180;

        //Clamp to desired range
        y = Mathf.Clamp(y, minAngle, maxAngle);

        //Move range back to [0, 360]
        y += 180;

        //Set the angle back to the transform and rotate it back to right side up
        transform.rotation = Quaternion.Euler(Mathf.Clamp(transform.rotation.eulerAngles.x, currentRotation.x, currentRotation.x), y + clampAroundAngle, Mathf.Clamp(transform.rotation.eulerAngles.z, currentRotation.z, currentRotation.z));
    }

    void ClampRotationZ(float minAngle, float maxAngle, float clampAroundAngle = 0)
    {
        //clampAroundAngle is the angle you want the clamp to originate from
        //For example a value of 90, with a min=-45 and max=45, will let the angle go 45 degrees away from 90

        //Adjust to make 0 be right side up
        clampAroundAngle += 180;

        //Get the angle of the z axis and rotate it up side down
        float z = transform.rotation.eulerAngles.z - clampAroundAngle;

        z = WrapAngle(z);

        //Move range to [-180, 180]
        z -= 180;

        //Clamp to desired range
        z = Mathf.Clamp(z, minAngle, maxAngle);

        //Move range back to [0, 360]
        z += 180;

        //Set the angle back to the transform and rotate it back to right side up
        transform.rotation = Quaternion.Euler(Mathf.Clamp(transform.rotation.eulerAngles.x, currentRotation.x, currentRotation.x), Mathf.Clamp(transform.rotation.eulerAngles.y, currentRotation.y, currentRotation.y), z + clampAroundAngle);
    }

    //Make sure angle is within 0,360 range
    float WrapAngle(float angle)
    {
        //If its negative rotate until its positive
        while (angle < 0)
            angle += 360;

        //If its to positive rotate until within range
        return Mathf.Repeat(angle, 360);
    }
}
