using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceController : MonoBehaviour
{
	//public static float forceSpeed = -1.5f;
	public static float forceSpeed = -60f;
	public static int scrollCount;
	public GameObject GoalFrame;
	public GameObject SpaceFront;
	float cofficient = 0.97f;
	public static float currentDistance;



	// Use this for initialization
	void Awake ()
	{
		Initialize ();
	
	}

	void Initialize ()
	{
		transform.position = new Vector3 (0, 0, 0);
		scrollCount = 0;
		forceSpeed = -1.5f;
		currentDistance = 0f;
		GetComponent<BoxCollider> ().enabled = true;
		GoalFrame.SetActive (false);
		SpaceFront.SetActive (false);

	}

	// Update is called once per frame
	void Update ()
	{
		if (GameManager.gameStart) {


			if (PlayController.isDamaged) {
				forceSpeed *= cofficient;	
			} else {
				if (!PlayController.isDead && !PlayController.isGoal) {
					forceSpeed = -60f;			
				}

			}
			transform.Translate (0, 0, forceSpeed * Time.deltaTime);
			currentDistance += Mathf.Abs (forceSpeed) * Time.deltaTime;


			if (scrollCount == GameManager.finalPartCount) {
				GoalFrame.SetActive (true);
				SpaceFront.SetActive (true);
				GetComponent<BoxCollider> ().enabled = false;

			}

				
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player" && !PlayController.isGoal) {
			scrollCount++;
			transform.position = new Vector3 (0, 0, 0);
			
			
		}
		
	}
}
