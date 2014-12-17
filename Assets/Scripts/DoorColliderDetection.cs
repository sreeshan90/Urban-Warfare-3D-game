using UnityEngine;
using System.Collections;

public class DoorColliderDetection : MonoBehaviour {
	
	Animator anim;
	private GameObject rFoot;
	private GameObject lFoot;
	private GameObject wiMote;


	void    Start () {

		anim = GetComponent<Animator> ();
		rFoot = GameObject.Find ("RightShoeObject");
		lFoot = GameObject.Find ("LeftShoeObject");
		wiMote = GameObject.Find ("RightWiiMoteObject");
		anim.SetBool ("open", false);
	}
	
	// Update is called once per frame
	void Update () {

	}
	// Trigger function for collisions
	void OnTriggerEnter(Collider other) {

		if(other.gameObject == rFoot || other.gameObject == lFoot || other.gameObject == wiMote){
			anim.SetBool ("open", true);

		}
		Debug.Log("enter");

	}
	
	// Trigger function for exiting collisions
	void OnTriggerExit(Collider other) {
		Debug.Log("exit");
		anim.SetBool ("open", false);
	}
}

