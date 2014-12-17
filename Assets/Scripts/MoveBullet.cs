using UnityEngine;
using System.Collections;

public class MoveBullet : MonoBehaviour {

	public float speed = 1.0f;

	void Start ()	
 	{
		//Destroy(gameObject, 5f); //Delete the bullet after 5 seconds
	}


	void Update ()	
 	{
		this.transform.Translate(0, 0, speed);
		if(gameObject.name == "Bullet(Clone)"){
			Destroy(gameObject, 1.0f);
		}
	}
}
