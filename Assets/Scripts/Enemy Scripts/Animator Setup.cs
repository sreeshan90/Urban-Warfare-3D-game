using UnityEngine;
using System.Collections;

public class AnimatorSetup 
{
	public float speedDampTime = 0.1f;
	public float angularSpeedDampTime = .7f;
	public float angleResponseTime = .6f;  




	private Animator anim;

	public AnimatorSetup(Animator animator)
	{
		anim = animator;
	}

	public void Setup(float speed, float angle)
	{
			float angularSpeed = angle / angleResponseTime;
		anim.SetFloat (Animator.StringToHash ("Speed"), speed, speedDampTime, Time.deltaTime);
		anim.SetFloat (Animator.StringToHash ("AngularSpeed"), angularSpeed, angularSpeedDampTime, Time.deltaTime);

	}
}
