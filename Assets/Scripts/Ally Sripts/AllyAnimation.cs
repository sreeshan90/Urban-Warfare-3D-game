using UnityEngine;
using System.Collections;

public class AllyAnimation : MonoBehaviour {
	public float deadZone = 5f;

	private GameObject[] ens;
	private Transform[] enemies;
	private AllySight allySight;
	private NavMeshAgent nav;
	private Animator anim;
	private AnimatorSetup animSetup;  
	
	
	
	void Awake()
	{
		//player = GameObject.Find ("HMD").trtansform;
		ens = GameObject.FindGameObjectsWithTag ("Enemy");
		allySight = GetComponent<AllySight> ();
		nav = GetComponent < NavMeshAgent> ();
		anim = GetComponent<Animator> ();
		
		nav.updateRotation = false;
		animSetup = new AnimatorSetup (anim);
		anim.SetLayerWeight (1, 1f);
		anim.SetLayerWeight (2, 1f);
		
		deadZone *= Mathf.Deg2Rad;
		
	}
	
	void Update(){
		NavAnimSetup ();
		
	}
	
	void OnAnimatorMove(){
		nav.velocity = anim.deltaPosition / Time.deltaTime;
		transform.rotation = anim.rootRotation;
	}
	
	void NavAnimSetup()
	{
		float speed;
		float angle;
		
		
		if (allySight.EnemyInSight) {
			speed = 0f;
			Transform closest = allySight.Enemy.transform;
			for(int i =0 ; i < ens.Length; i++){
				if(ens[i] == allySight.Enemy){
					closest = ens[i].transform;
				}
			}
			angle = FindAngle (transform.forward, closest.position - transform.position, transform.up);
		}
		else {
			speed = Vector3.Project(nav.desiredVelocity, transform.forward).magnitude;
			angle = FindAngle(transform.forward, nav.desiredVelocity, transform.up);
			if(Mathf.Abs (angle) < deadZone){
				transform.LookAt(transform.position + nav.desiredVelocity);
				angle = 0f;
			}
		}
		
		animSetup.Setup (speed, angle);
	}
	
	
	float FindAngle(Vector3 fromVector, Vector3 toVector, Vector2 upVector){
		if (toVector == Vector3.zero) {
			return 0f;
		}
		
		float angle = Vector3.Angle (fromVector, toVector);
		Vector3 normal = Vector3.Cross (fromVector, toVector);
		angle *= Mathf.Sign (Vector3.Dot (normal, upVector));
		angle *= Mathf.Deg2Rad;
		
		return angle;
	}
}
