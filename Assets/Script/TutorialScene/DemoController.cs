using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemoController : MonoBehaviour
{
	float force;
	public Animator animator;
	public LineRenderer line;
	public GameObject attack;
	public Transform backRotation;
	bool attackMode;
	public Camera sub;
	public Camera third;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		float x = Input.GetAxis ("Horizontal");
		float y = Input.GetAxis ("Vertical");
		force = 10.0f;

		if (Input.GetKey (KeyCode.LeftShift)) {
			force = 20.0f;
		}
		if (Input.GetKey (KeyCode.LeftAlt)) {
			attackMode = true;
			
		}
		if (Input.GetKeyUp (KeyCode.LeftAlt)) {
			attackMode = false;

		}

		transform.Translate (x * Time.deltaTime * force, y * Time.deltaTime * force, 0);
		animator.SetFloat ("Horizontal", x);
		animator.SetFloat ("Vertical", y);


		if (attackMode) {
			Turning ();
			transform.rotation = Quaternion.Slerp (transform.rotation, backRotation.transform.rotation, 0.2f);
			Ray ray = sub.ScreenPointToRay (Input.mousePosition);
			if (Input.GetKey (KeyCode.LeftCommand)) {
				line.enabled = true;
			}
			if (Input.GetKeyUp (KeyCode.LeftCommand)) {
				line.enabled = false;
			}
			line.SetPosition (0, transform.position);
			line.SetPosition (1, ray.origin + ray.direction * 100);
			if (Input.GetMouseButtonDown (0)) {
				Vector3 worldDir = ray.direction;
				GameObject attacker = Instantiate (attack, transform.position, transform.rotation) as GameObject;
				attacker.GetComponent<AttackController> ().Attack (worldDir.normalized * 100);
				animator.SetTrigger ("IsAttack");


				RaycastHit hit = new RaycastHit ();

				if (Physics.Raycast (ray, out hit)) {
					line.SetPosition (1, hit.point);
				} else {
					line.SetPosition (1, ray.origin + ray.direction * 100);
				}

			}

		}
		if (!attackMode) {
			line.enabled = false;
		}


	}

	void Turning ()
	{
		Ray camRay = sub.ScreenPointToRay (Input.mousePosition);

		RaycastHit floorHit;
		if (Physics.Raycast (camRay, out floorHit)) {
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (floorHit.point - transform.position), 0.3f);

		}


	}


}
