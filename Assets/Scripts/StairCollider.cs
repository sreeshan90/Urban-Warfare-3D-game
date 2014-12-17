using UnityEngine;
using System.Collections;

public class StairCollider : MonoBehaviour
{

	public float stairNumber = 0; 
	private float stairScale = 0.0f; 
	private GameObject rFoot;
	private GameObject lFoot;
	private GameObject wiMote;



	// Use this for initialization
	void Start ()
	{
		rFoot = GameObject.Find ("RightShoeObject");
		lFoot = GameObject.Find ("LeftShoeObject");
		wiMote = GameObject.Find ("RightWiiMoteObject");
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnTriggerEnter (Collider other)
	{
		//SevenLeagueBoots.stairs = !SevenLeagueBoots.stairs;
		if(other.gameObject == rFoot || other.gameObject == lFoot){
			//Vector3 forward = wiMote.transform.forward;
			// Zero out the y component of your forward vector to only get the direction in the X,Z plane
			/*forward.x = 0;
			float pitchAngle = Quaternion.LookRotation(forward).eulerAngles.x;
			if(pitchAngle >= 0f){*/
		//Movement factor for going up stairs
			stairScale = 0.1904185f * stairNumber; 
			CommonVariables.mappedPosition.y = stairScale;
			//}
			/*else{
				stairScale = 0.1904185f * (stairNumber-1); 
				CommonVariables.mappedPosition.y = stairScale;
			}*/
		}

		//previousY is used in Steering script to reset Y position
		//Steering.previousY = stairScale; 

	}
	
	// Trigger function for exiting collisions
	void OnTriggerExit (Collider other)
	{


	}
}
