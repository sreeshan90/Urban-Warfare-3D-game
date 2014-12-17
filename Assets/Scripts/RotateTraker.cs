using UnityEngine;
using System.Collections;

// This class provides an easy method of controlling a GameObject with a Vicon tracker
// Directions:
// 		1. Attach to the GameObject that will be tracked
//		2. Change ViconName to the name of the Vicon object that is being tracked
public class RotateTraker : MonoBehaviour {
	public float BootScale = 7.0f/4.0f;
	
	private GameObject Head;
	private float lastX;
	private float lastZ;
	private bool firstFrame = true;
	
	// Use this for initialization
	void Start () {
		
		Head = GameObject.Find("HMD");
		lastX = Head.transform.localPosition.x;
		lastZ = Head.transform.localPosition.z;
	}
	
	// Update is called once per frame
	void Update () { 
		
		if(!firstFrame) {
			
			
			float currentX = Head.transform.localPosition.x;
			float currentZ = Head.transform.localPosition.z;
			
			CommonVariables.mappedPosition.x += (BootScale * (currentX - lastX)) - (currentX - lastX);
			CommonVariables.mappedPosition.z += (BootScale * (currentZ - lastZ)) - (currentZ - lastZ);
			
			lastX = currentX;
			lastZ = currentZ;
			
		}
		else {
			firstFrame = false;
			lastX = Head.transform.localPosition.x;
			lastZ = Head.transform.localPosition.z;
		}
		
	}
}
