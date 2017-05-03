using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bellows : MonoBehaviour 
{
	public float force;
	public bool inverted;
    public bool isBlowing;
    public ToggleScript toggleScript;
    
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
