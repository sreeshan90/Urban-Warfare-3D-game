using UnityEngine;
using System.Collections;

public class movementScript : MonoBehaviour {

	public string playmode = "shootAtPoint";
	public bool die = false;
	public Vector3 point = Vector3.zero;
	public float speed = 6.0F;
	public float multiplier = 1.0F;
	public Vector3 direction = Vector3.forward;
	public bool action = false;

	private int alternator = 0; 
	private Vector3 moveDirection = Vector3.zero;
	private CharacterController controller;
	private bool charAlive = true;



	// Use this for initialization
	void Start () {	
	controller = GetComponent<CharacterController>();
		animation.wrapMode = WrapMode.Loop;
	}
	
	// Update is called once per frame
	void Update () {

		if (playmode.Equals ("shootAtPoint")) {
			animation.CrossFade("soldierFiring");
			if (die){
				animation ["soldierDieFront"].wrapMode = WrapMode.Once;
				animation.CrossFade("soldierDieFront");
				die = false;
				charAlive = false;
			}
		
		}

		if (playmode.Equals ("strafeLeftAndShoot")) {
						
						if (die) {
								animation ["soldierDieBack"].wrapMode = WrapMode.Once;
								animation.CrossFade ("soldierDieBack");
								die = false;
								charAlive = false;
						} else {
								if (charAlive) {
									if(!action)
										animation.CrossFade("soldierIdle");
									else{
										controller.Move (moveDirection * Time.deltaTime);
										animation.CrossFade ("soldierCrouchStrafeLeft");
										moveDirection = Vector3.left;
										moveDirection = transform.TransformDirection (moveDirection);
										moveDirection *= speed;	
										moveDirection.x += multiplier * Time.deltaTime;
									}
								}
						}
				}

			if (playmode.Equals ("strafeRightAndShoot")) {
				if (die){
					animation ["soldierDieBack"].wrapMode = WrapMode.Once;
					animation.CrossFade("soldierDieBack");
					die = false;
					charAlive = false;
				}
				else {
				if(charAlive){
					if(!action)
						animation.CrossFade("soldierIdle");
					else{
						controller.Move(moveDirection * Time.deltaTime);
						animation.CrossFade("soldierCrouchStrafeRight");
						moveDirection = Vector3.right;
						moveDirection = transform.TransformDirection(moveDirection);
						moveDirection *= speed;	
						moveDirection.x += multiplier * Time.deltaTime;
					  }
					}
				}
			}

	}
}
