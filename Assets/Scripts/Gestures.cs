using UnityEngine;
using System.Collections;

public class Gestures : MonoBehaviour {

	// Use this for initialization
	void Start () {

	
	
	}
	
	// Update is called once per frame
	void Update () {

		//Attempting to make it a range of +- 15 degrees is being gay

		if (transform.eulerAngles.x == 270) {
			Debug.Log ("I am pointing upwards"); 		
		}

		if (transform.eulerAngles.x == 90) {
			Debug.Log ("I am pointing downwards"); 		
		}
	
	}
}
