	using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	public GameObject bullet;
	
	public GameObject bulletHole;

	public float delayTime = 0.1f;
	public string WiimoteName = "RightWiimote";
	private float counter = 0;

	void Start () {
		

	}

	void FixedUpdate ()	
 	{


		if (InputBroker.GetKeyDown (WiimoteName + ":B") && counter > delayTime) {

			Instantiate (bullet, transform.position, transform.rotation);
						audio.Play ();
						counter = 0;
			
			RaycastHit hit;
			Ray ray = new Ray(transform.position, transform.forward);
			Debug.DrawRay(transform.position, transform.forward*10.0f);







			if(Physics.Raycast(ray, out hit, 10.0f))
			{
				//Debug.Log ("collider "+hit.collider.tag);
				Debug.Log ("hit obj tag "+hit.transform.gameObject.tag );
				Debug.DrawRay(ray.origin, hit.point, Color.green);
				if(hit.collider.gameObject.tag == "Enemy"){//Equals(GameObject.Find ("testGuard").GetComponent<CapsuleCollider>)){
					Collider check = hit.collider;
					Debug.Log("type hit "+ check.GetType().ToString());
					if(check.GetType()==typeof(CapsuleCollider)){


						Debug.Log("table");
						check.gameObject.GetComponent<EnemyAI>().EnemyDead = true;
						//Destroy(check.gameObject);
					}
				}
				//else if(hit.collider.gameObject.tag != "Player"){
				else{
					Instantiate(bulletHole, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));

				}
			}

		}


		counter += Time.deltaTime;
	}
}
