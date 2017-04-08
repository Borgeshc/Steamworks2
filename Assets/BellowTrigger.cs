using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellowTrigger : MonoBehaviour
{
    public Bellows bellow;
    public Animator anim;
    public GameObject bellowChild;
    public bool isAutomatic;

    bool waiting;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Player") && !anim.GetBool("Bellow"))
        {
            other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            other.transform.parent = bellowChild.transform;
            StartCoroutine(PlayAnim(other.gameObject));
        }
    }

    void Update()
    {
        if(isAutomatic)
        {
            if(!anim.GetBool("Bellow") && !waiting)
            {
                anim.SetBool("Bellow", true);
                bellow.isBlowing = true;
                StartCoroutine(Wait());
            }
            else if (!waiting)
            {
                anim.SetBool("Bellow", false);
                bellow.isBlowing = false;
                StartCoroutine(Wait());
            }
        }
    }

    IEnumerator PlayAnim(GameObject gyro)
    {
        bellow.isBlowing = true;
        anim.SetBool("Bellow", true);
        yield return new WaitForSeconds(3);
        anim.SetBool("Bellow", false);
        gyro.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        gyro.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
        bellow.isBlowing = false;
        gyro.transform.parent = null;
    }

    IEnumerator Wait()
    {
        waiting = true;
        yield return new WaitForSeconds(5);
        waiting = false;
    }
}
