using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ControllablePulley : MonoBehaviour 
{
	public float horizontalSpeed;
	public float verticalSpeed;

	public float minXClamp;
	public float maxXClamp;

	public float minYClamp;
	public float maxYClamp;

	float horizontal;
	float vertical;

	void Update()
	{
		#if MOBILE_INPUT
		horizontal += CrossPlatformInputManager.GetAxisRaw("Horizontal") * horizontalSpeed * Time.deltaTime;
		vertical += CrossPlatformInputManager.GetAxisRaw("Vertical") * verticalSpeed * Time.deltaTime;
		#else
		horizontal += Input.GetAxisRaw("Horizontal") * horizontalSpeed * Time.deltaTime;
		vertical += Input.GetAxisRaw("Vertical") * verticalSpeed * Time.deltaTime;
		#endif

		horizontal = Mathf.Clamp(horizontal, minXClamp, maxXClamp);
		vertical = Mathf.Clamp(vertical, minYClamp, maxYClamp);

		transform.position = new Vector3 (horizontal, vertical,0);
	}
}
