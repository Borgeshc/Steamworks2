using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleScript : MonoBehaviour {

    //public Behaviour targetObject;

    public delegate void Toggle();
    public event Toggle OnToggle;
    public event Toggle OnExit;

	void OnTriggerEnter(Collider other)
    {
        OnToggle();            
    }

    void OnTriggerExit(Collider other)
    {
        OnExit();
    }
}
