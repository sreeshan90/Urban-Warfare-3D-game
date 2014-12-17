using UnityEngine;
using System.Collections;

public class AllyAI : MonoBehaviour {
	public float patrolSpeed = 2f;
	public float chaseSpeed = 5f;
	public float chaseWaitTime= 5f;
	public float patrolWaitTime =1f;
	public Transform[] patrolWayPoints;
	public bool shooting = false;
	public bool holding = false;
	public bool goToPoint = false;
	public bool following = false;
	
	private AllySight allySight;
	private NavMeshAgent nav;
	private Transform player;
	public Transform shotLocation;
	public Transform moveToPoint;
	public Transform leftWiMote;
	private float chaseTimer;
	private float patrolTimer;
	private int wayPointIndex;
	private Animator anim;
	
	void Awake(){
		anim = GetComponent<Animator> ();
		allySight = GetComponent<AllySight> ();
		nav = GetComponent<NavMeshAgent> ();
		//player = GameObject.Find ("HMD").transform;
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		
	}
	
	void Update(){
		if(allySight.EnemyInSight)
		{
			Shooting ();

		}
		else if (holding) {
			Holding();
		}
		else if(goToPoint){
			Moving();
		}
		else {
			//

			//Following ();
		}
	}
	
	void Shooting(){
		nav.Stop ();
	}
	void Holding(){
		nav.Stop ();
	}
	
	void Moving(){
		
		nav.destination = shotLocation.position;
		
		nav.speed = chaseSpeed;
		
		// If near the last personal sighting...
		if(nav.remainingDistance < nav.stoppingDistance)
		{
			// ... increment the timer.
			goToPoint = false;
		}
	}
	
	void Following(){
		nav.speed = patrolSpeed;
		
		if (nav.remainingDistance < nav.stoppingDistance) {
			patrolTimer += Time.deltaTime;
			if (patrolTimer >= patrolWaitTime) {
				if (wayPointIndex == patrolWayPoints.Length - 1) {
					wayPointIndex = 0;
				} else {
					wayPointIndex++;
				}
				patrolTimer = 0f;
			}
		}
		else {
			patrolTimer = 0f;
		}
		nav.destination = patrolWayPoints [wayPointIndex].position;
	}
}
