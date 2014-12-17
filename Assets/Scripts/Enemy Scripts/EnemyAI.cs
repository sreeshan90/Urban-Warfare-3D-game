using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	public float patrolSpeed = 2f;
	public float chaseSpeed = 5f;
	public float chaseWaitTime= 5f;
	public float patrolWaitTime =1f;
	public Transform[] patrolWayPoints;
	public bool EnemyDead = false;
	public bool dying = false;
	public bool patroller = false;
	public bool chasing = false;

	private EnemySight2 enemySight;
	private NavMeshAgent nav;
	private Transform player;
	public Transform shotLocation;
	private float chaseTimer;
	private float patrolTimer;
	private int wayPointIndex;
	private Animator anim;

	void Awake(){
		anim = GetComponent<Animator> ();
		enemySight = GetComponent<EnemySight2> ();
		nav = GetComponent<NavMeshAgent> ();
		//player = GameObject.Find ("HMD").transform;
		player = GameObject.FindGameObjectWithTag ("Player").transform;

	}

	void Update(){
		if(EnemyDead)
		{
			if(!dying){
				anim.SetLayerWeight (3, 1f);
				anim.SetBool ("Dead", true);
				dying= true;
			}
		}
		else if (enemySight.playerInSight) {
			Shooting ();
		}
		else if(patroller && chasing){
			Chasing ();
		}
		else {
			Patrolling ();
		}
	}

	void Shooting(){
		nav.Stop ();
	}

	void Chasing(){

		nav.destination = shotLocation.position;
	
		nav.speed = chaseSpeed;
		
		// If near the last personal sighting...
		if(nav.remainingDistance < nav.stoppingDistance)
		{
			// ... increment the timer.
			chasing = false;
		}
	}



	void Patrolling(){
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
