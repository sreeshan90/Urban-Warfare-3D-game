using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour {
	public float random;

	private Animator anim;
	private Transform player;
	private bool shooting;
	private SphereCollider col;

	void Awake(){
		anim = GetComponent<Animator> ();
		col = GetComponent<SphereCollider> ();
		//player = GameObject.Find ("HMD").transform;
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		random = 5f;
	}


	void Update(){
		float shot = anim.GetFloat(Animator.StringToHash("Shot"));

		if (shot > .5f && !shooting) {
			Shoot ();
		}

		if (shot < .5f) {
			shooting = false;
		}
	}
	void OnAnimatorIK(int layerIndex){
		float aimWeight = anim.GetFloat (Animator.StringToHash ("AimWeights"));
		anim.SetIKPosition (AvatarIKGoal.RightFoot, player.position);
		anim.SetIKPositionWeight (AvatarIKGoal.RightHand, aimWeight);
	}

	void Shoot()
	{
		shooting = true;
		ShotEffects ();
		//float fractionDistance = (col.radius - Vector3.Distance (transform.position, player.position)) / col.radius;

	}

	void ShotEffects()
	{
		//
		GameObject[] patrollers = GameObject.FindGameObjectsWithTag ("Enemy");
		for (int i =0; i < patrollers.Length; i++) {
			if(patrollers[i].GetComponent<EnemyAI>().patroller){
				patrollers[i].GetComponent<EnemyAI>().chasing = true;
				patrollers[i].GetComponent<EnemyAI>().shotLocation = transform;
			}
		}
		//GameObject[] patrollers = GameObject.fin

	}
}
