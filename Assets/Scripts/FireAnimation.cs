using UnityEngine;
using System.Collections;

public class FireAnimation : MonoBehaviour {

	Animator anim;
	//public Animation animation;
	public string WiimoteName = "RightWiimote";	
	// Use this for initialization
	void Start () {
		
		anim = GetComponent<Animator> ();
		//animation = GetComponent<Animation>();
		anim.SetBool("Fire", false);
	}
	
	// Update is called once per frame
	void Update () {
		if (InputBroker.GetKeyDown (WiimoteName + ":B")) {

			//Debug.Log ("presswd" + anim.GetBool("Fire"));

			anim.SetBool ("Fire", true);
			//animation.Play("GunFire");
		
		}
		else{

			anim.SetBool ("Fire", false);
			anim.Play("Idle");

		}
			}
}
