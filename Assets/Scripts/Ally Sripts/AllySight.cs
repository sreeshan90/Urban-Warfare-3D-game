using UnityEngine;
using System.Collections;

public class AllySight : MonoBehaviour {
	public float fieldOfViewAngle = 110f;
	public bool EnemyInSight;
	public Vector3 personalLastSighting;
	
	private NavMeshAgent nav;
	private SphereCollider col;
	private Animator anim;
	public GameObject Enemy;
	private Vector3 previousSighting;  
	
	
	
	
	
	
	
	
	void Awake(){
		nav = GetComponent < NavMeshAgent >();
		col = GetComponent<SphereCollider> ();
		anim = GetComponent<Animator> ();
		//player = GameObject.Find ("HMD");
		//player = GameObject.FindGameObjectWithTag ("Player");
		EnemyInSight = false;
		
	}
	
	void Update(){
		anim.SetBool(Animator.StringToHash("PlayerInSight"), EnemyInSight);
	}
	
	void OnTriggerStay(Collider other){
		if (other.gameObject.tag == "Enemy") {
			EnemyInSight = false;
			Vector3 direction = other.transform.position - transform.position;
			float angle = Vector3.Angle (direction, transform.forward);
			
			if (angle < fieldOfViewAngle * 0.5f) {
				RaycastHit hit;
				
				// ... and if a raycast towards the player hits something...
				if (Physics.Raycast (transform.position + transform.up+transform.up, direction.normalized, out hit, col.radius)) {
					//Debug.Log(hit.collider.gameObject);		// ... and if the raycast hits the player...
					if (hit.collider.gameObject.tag == "Enemy") {
						//Debug.Log("hits player");	
						Enemy = hit.collider.gameObject;// ... the player is in sight.
						EnemyInSight = true;
					}
				}
			}
		}
		
	}
	
	
	void OnTriggerExit (Collider other)
	{
		// If the player leaves the trigger zone...
		if(other.gameObject.tag == "Enemy")
			// ... the player is not in sight.
			EnemyInSight = false;
	}
	
	float CalculatePathLength (Vector3 targetPosition)
	{
		// Create a path and set it based on a target position.
		NavMeshPath path = new NavMeshPath();
		if(nav.enabled)
			nav.CalculatePath(targetPosition, path);
		
		// Create an array of points which is the length of the number of corners in the path + 2.
		Vector3[] allWayPoints = new Vector3[path.corners.Length + 2];
		
		// The first point is the enemy's position.
		allWayPoints[0] = transform.position;
		
		// The last point is the target position.
		allWayPoints[allWayPoints.Length - 1] = targetPosition;
		
		// The points inbetween are the corners of the path.
		for(int i = 0; i < path.corners.Length; i++)
		{
			allWayPoints[i + 1] = path.corners[i];
		}
		
		// Create a float to store the path length that is by default 0.
		float pathLength = 0;
		
		// Increment the path length by an amount equal to the distance between each waypoint and the next.
		for(int i = 0; i < allWayPoints.Length - 1; i++)
		{
			pathLength += Vector3.Distance(allWayPoints[i], allWayPoints[i + 1]);
		}
		
		return pathLength;
	}

}
