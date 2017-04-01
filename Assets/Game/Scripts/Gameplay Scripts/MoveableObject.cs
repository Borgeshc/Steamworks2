using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MoveableObject : MonoBehaviour 
{
	public float horizontalSpeed;
	public float verticalSpeed;

	public float minXClamp;
	public float maxXClamp;

	public float minYClamp;
	public float maxYClamp;

    public bool hasVerticalMovement;
    public bool hasHorizontalMovement;

	float horizontal;
	float vertical;

	void Update()
	{
		#if MOBILE_INPUT
		horizontal += CrossPlatformInputManager.GetAxisRaw("Horizontal2") * (horizontalSpeed * .5f)* Time.deltaTime;
		vertical += CrossPlatformInputManager.GetAxisRaw("Vertical2") * (verticalSpeed * .5f) * Time.deltaTime;
		#else
		horizontal += Input.GetAxisRaw("Horizontal") * horizontalSpeed * Time.deltaTime;
		vertical += Input.GetAxisRaw("Vertical") * verticalSpeed * Time.deltaTime;
		#endif

		horizontal = Mathf.Clamp(horizontal, minXClamp, maxXClamp);
		vertical = Mathf.Clamp(vertical, minYClamp, maxYClamp);

        if(hasVerticalMovement)
		    transform.position = new Vector3 (transform.position.x, vertical,0);

        if (hasHorizontalMovement)
            transform.position = new Vector3(horizontal, transform.position.y, 0);
    }
}
