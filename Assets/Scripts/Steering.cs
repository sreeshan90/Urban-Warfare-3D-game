using UnityEngine;
using System.Collections;

// This class provides a 3D steering technique
// Directions:
// 		1. Attach to the GameObject that will be used to direct steering
//		2. Change WiimoteName to the name of the Wiimote that will be used for input
//		3. Change TravelSpeed if desired
//		4. Change RotationSpeed if desired
public class Steering : MonoBehaviour {
	
	public string WiimoteName = "RightWiimote";	
	public float TravelSpeed = 2f;
	public float RotationSpeed = 90f;
	private float prevY =0.0f;
	private Vector3 prev;
	private Vector3 current;

	// Use this for initialization
	void Start () {
		//current = CommonVariables.mappedPosition;
		prevY = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		prevY = CommonVariables.mappedPosition.y;
		prev = current;
		current = current + transform.forward * TravelSpeed * Time.deltaTime;


		Ray rayForward = new Ray (transform.position, transform.forward);
		Ray rayBack = new Ray (transform.position, -transform.forward);
		Debug.DrawRay(transform.position, transform.forward*100.0f);
	
		RaycastHit rayHit;
	


			if (InputBroker.GetKeyDown (WiimoteName + ":Up")) {
				bool hit = Physics.Raycast (rayForward, out rayHit, 0.5f);
			if (hit && (rayHit.collider.gameObject.tag != "Enemy") && (rayHit.collider.gameObject.tag != "Player") ) {
					Debug.DrawRay (rayForward.origin, rayHit.point, Color.green);
				
				}
				else{
					
					CommonVariables.mappedPosition += transform.forward * TravelSpeed * Time.deltaTime;
					CommonVariables.mappedPosition.y = prevY;
				
				}

			}
			
			// Down button moves backwards relative to the object's transformation
			if (InputBroker.GetKeyDown (WiimoteName + ":Down")) {
				bool hit = Physics.Raycast (rayForward, out rayHit, 0.5f);
				if (hit && (rayHit.collider.gameObject.tag != "Enemy")) {
					Debug.DrawRay (rayBack.origin, rayHit.point, Color.green);
					
				}
				else{

					CommonVariables.mappedPosition -= transform.forward * TravelSpeed * Time.deltaTime;
					CommonVariables.mappedPosition.y = prevY;
				}

			}
		
	
	}
}

	
