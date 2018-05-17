using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{

	private float itemDeathPos = -350;
	public static float directionSpeed = -1.0f;
	public float rotationX;
	public float rotationY;
	public float rotationZ;
	float cofficient = 0.97f;
	public int point;





	// Use this for initialization
	void Awake ()
	{
	}

	// Update is called once per frame
	void Update ()
	{


		if (PlayController.isDamaged) {
			directionSpeed *= cofficient;	
		} else {
			if (!PlayController.isDead && !PlayController.isGoal) {
				directionSpeed = -1.0f;			
			}
		}
		transform.Rotate (rotationX, rotationY, rotationZ);
		transform.Translate (0, 0, directionSpeed, Space.World);

		if (transform.position.z < itemDeathPos) {
			Destroy (gameObject);

		}

		if (PlayController.isDead || PlayController.isGoal) {
			Destroy (gameObject);

		}


	}




}