using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bellows : MonoBehaviour 
{
	public float force;
	public bool inverted;
    bool isBlowing;
    public ToggleScript toggleScript;

    void OnEnable()
    {
        if (toggleScript != null)
        {
            toggleScript.OnToggle += ToggleOn;
            toggleScript.OnExit += ToggleOff;
        }
    }

    void OnDisable()
    {
        if (toggleScript != null)
        {
            toggleScript.OnToggle -= ToggleOn;
            toggleScript.OnExit -= ToggleOff;
        }
    }
    
    void ToggleOn()
    {
        isBlowing = true;
    }

    void ToggleOff()
    {
        isBlowing = false;
    }

	void OnTriggerEnter(Collider other)
	{
        if (isBlowing)
        {
            if (other.transform.tag.Equals("Player"))
            {
                if (!inverted)
                    other.GetComponent<Rigidbody>().AddForce(transform.right * force, ForceMode.Acceleration);
                else
                    other.GetComponent<Rigidbody>().AddForce(-transform.right * force, ForceMode.Acceleration);
            }
        }
	}
}
