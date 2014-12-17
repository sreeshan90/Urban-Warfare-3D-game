using UnityEngine;
using System.Collections;

// This class provides an easy method of controlling a GameObject with a Vicon tracker
// Directions:
// 		1. Attach to the GameObject that will be tracked
//		2. Change ViconName to the name of the Vicon object that is being tracked
public class Tracker : MonoBehaviour {
	
	public string ViconName = "none";

	//private Vector3 prev;
	//private Vector3 current;



	// Use this for initialization
	void Start () {
		//current = InputBroker.GetPosition(ViconName);
	}
	
	// Update is called once per frame
	void Update () {
		/*prev = current;
		Ray ray = new Ray(transform.position, transform.forward);
		RaycastHit hit;

		// Se rotation and position of object to match Vicon tracker

		if(!ViconName.Equals ("RiftDK1")){
		 	
			current = InputBroker.GetPosition(ViconName);
		}
		else if(!Physics.Raycast(ray, out hit, 0.2f)){
			current = InputBroker.GetPosition(ViconName);
		}
		else {
			current = prev;
		}
		transform.localRotation = InputBroker.GetRotation(ViconName);
		transform.localPosition = current;*/
		transform.localRotation = InputBroker.GetRotation(ViconName);
		transform.localPosition = InputBroker.GetPosition(ViconName);
	}
}
