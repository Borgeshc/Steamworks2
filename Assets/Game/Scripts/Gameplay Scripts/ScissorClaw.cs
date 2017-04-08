using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScissorClaw : MonoBehaviour
{
    public Animator anim;
	GameObject player;

	void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag.Equals ("Player")) 
		{
			player = other.gameObject;
			other.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
			other.transform.parent = this.transform;
            StartCoroutine(Animate());
		}
		else if (other.transform.tag.Equals ("ScissorClawEnd")) 
		{
			if (player != null) {
				player.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
				player.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionZ;
				player.transform.parent = null;
			}
		}
	}

    IEnumerator Animate()
    {
        anim.SetBool("Activate", true);
        yield return new WaitForSeconds(12);
        anim.SetBool("Activate", false);
    }
}
