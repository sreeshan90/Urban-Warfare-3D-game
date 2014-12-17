using UnityEngine;
using System.Collections;

// This class provides an easy method of controlling a GameObject with a Vicon tracker
// Directions:
// 		1. Attach to the GameObject that will be tracked
//		2. Change ViconName to the name of the Vicon object that is being tracked
public class SevenLeagueBoots : MonoBehaviour
{
	private GameObject Head;
	private bool isFirstFrame = true; 
	private float savedX;
	private float savedZ; 
	public static bool stairs = false;
	public bool alert = false;
	//public float changeRate = 1.713762f/2.7f;
	public float changeRate = 10000.0f;
	private float Xdiff =0.0f;
	private float Zdiff = 0.0f;
	//private Vector3 prev;
	//private Vector3 current;

	//Set scale
	public float scale = 1.75f; 

	// Use this for initialization
	void Start ()
	{
		Head = GameObject.Find ("HMD"); 
		savedX = Head.transform.localPosition.x;
		savedZ = Head.transform.localPosition.z; 
		//current = Head.transform.localPosition;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//prev = current;
		//Is it the first frame being ran?
		if (isFirstFrame == true) {

			//Get current position
			float currentX = Head.transform.localPosition.x; 
			float currentZ = Head.transform.localPosition.z; 
			Xdiff = (scale * (currentX - savedX)) - (currentX - savedX);
			Zdiff = (scale * (currentZ - savedZ)) - (currentZ - savedZ);
			//current = new Vector3(prev.x + Xdiff, prev.y, prev.z +Zdiff);
			CommonVariables.mappedPosition.x += Xdiff;
			CommonVariables.mappedPosition.z += Zdiff;
			savedX = currentX;
			savedZ = currentZ; 
			/*Ray ray = new Ray(prev, Head.transform.forward);

			RaycastHit hit;
			//
			if (!Physics.Raycast (ray, out hit, (current - prev).magnitude)) {
				Debug.Log("not within 1m");
				CommonVariables.mappedPosition.x += Xdiff;
				CommonVariables.mappedPosition.z += Zdiff;
								
				//Update position
				savedX = currentX;
				savedZ = currentZ; 

			}
			else{
				Debug.Log("within 1m");
				current = prev;
			}
			//Apply scaling*/


		} else { //If not the first frame

			//Change flag since we no longer are in first frame 
			isFirstFrame = false; 

			//Update positions
			savedX = Head.transform.localPosition.x;
			savedZ = Head.transform.localPosition.z; 
		}
	}
}
