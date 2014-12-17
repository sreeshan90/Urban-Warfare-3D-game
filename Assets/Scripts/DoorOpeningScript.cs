using UnityEngine;
using System.Collections;

public class DoorOpeningScript : MonoBehaviour {

	Animator anim;
	//Animation anim;
	public bool door = false;  
	private bool played;
	private GameObject rFoot;
	private GameObject lFoot;
	private GameObject rHand;
	
	
	
	
	void    Start () {
		

		anim = GetComponent<Animator>();
		//anim.playAutomatically = false;
		//played = false;
		anim.SetBool ("open", false);
	}
	
	// Update is called once per frame
	void Update () {
		//anim.SetBool ("open", door);
		/*if (door && !played) {
			Debug.Log ("enter");
			anim.Play();
			played = true;
			anim.playAutomatically = true;
		}*/
	}
	
	// Trigger function for collisions
	void OnTriggerStay(Collider other) {
		//if (other.gameObject == rFoot || other.gameObject == lFoot || other.gameObject == rHand) {
			Debug.Log ("enter");
			anim.SetBool ("open", true);
			//door = true;
		//}
	}
	
	// Trigger function for exiting collisions
	/*void OnTriggerExit(Collider other) {
		Debug.Log("exit");
		// 	anim.SetBool ("open", false);
	}*/
}

