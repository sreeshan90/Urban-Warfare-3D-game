using UnityEngine;
using System.Collections;

public class AllyShooting : MonoBehaviour {
	public float random;
	
	private Animator anim;
	private Transform enemy;
	private bool shooting;
	private SphereCollider col;
	
	void Awake(){
		anim = GetComponent<Animator> ();
		col = GetComponent<SphereCollider> ();
		//player = GameObject.Find ("HMD").transform;
		enemy = GetComponent<AllySight>().Enemy.transform;
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
		anim.SetIKPosition (AvatarIKGoal.RightFoot, enemy.position);
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
		//			//GameObject[] patrollers = GameObject.fin
		
	}
}
