using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleScript : MonoBehaviour {

    public enum Actions
    {
        Animation,
        BoolChange,
        Instantiate
    };

    public Actions action = Actions.Animation;

    //Animation variables
    public Animator anim;
    public string animParameter;
    public float animDelay;

    //BoolChange variables
    public MonoBehaviour targetScript;
    public string methodName;
    public float boolDelay;

    //Instantiate variables
    public GameObject spawnable;
    public Vector3 position;
    public Vector3 rotation;
    public float spawnDelay;

	void OnTriggerEnter(Collider other)
    {
        switch(action)
        {
            case Actions.Animation:
                StartCoroutine(StartAnimation());
                break;
            case Actions.BoolChange:
                ChangeBool();
                break;
            case Actions.Instantiate:
                StartCoroutine(InstantiateObject());
                break;
        }
    }

    IEnumerator StartAnimation()
    {
        yield return new WaitForSeconds(animDelay);
        anim.Play(animParameter);
    }

    void ChangeBool()
    {
        targetScript.Invoke(methodName, boolDelay);
    }

    IEnumerator InstantiateObject()
    {
        yield return new WaitForSeconds(spawnDelay);
        GameObject clone = Instantiate(spawnable, position, Quaternion.Euler(rotation)) as GameObject;
        clone.name = spawnable.name;
    }
}
