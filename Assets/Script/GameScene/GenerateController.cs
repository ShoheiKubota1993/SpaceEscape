using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateController : MonoBehaviour
{


	public GameObject[] trapXs;
	public GameObject[] items;
	public GameObject[] enemies;
	Vector3 generatePosition;
	public static bool generatable;
	public GameObject space;
	public Transform startRotation;
	bool endingModed;




	// Use this for initialization
	void Start ()
	{
		endingModed = false;
		InvokeRepeating ("TrapGenerate", 4.0f, 2.0f);
		InvokeRepeating ("ItemGenerate", 8.0f, 4.0f);
<<<<<<< HEAD
		InvokeRepeating ("ZombiGenerate", 16.0f, 16.0f);
=======
		InvokeRepeating ("EnemyGenerate", 16.0f, 16.0f);
>>>>>>> SpaceEscape/master
		
	}

	// Update is called once per frame
	void Update ()
	{
		if (SpaceController.scrollCount == Mathf.Abs (GameManager.finalPartCount / 2)) {
			CancelInvoke ();
			InvokeRepeating ("TrapGenerate", 1.0f, 1.3f);
			InvokeRepeating ("ItemGenerate", 2.0f, 2.6f);
<<<<<<< HEAD
			InvokeRepeating ("ZombiGenerate", 14.0f, 14.0f);
=======
			InvokeRepeating ("EnemyGenerate", 14.0f, 14.0f);
>>>>>>> SpaceEscape/master
			endingModed = true;

		}
		if (SpaceController.scrollCount == (GameManager.finalPartCount - 3)) {
			CancelInvoke ();
			InvokeRepeating ("TrapGenerate", 0.8f, 1.3f);
			InvokeRepeating ("ItemGenerate", 2.0f, 2.6f);
<<<<<<< HEAD
			InvokeRepeating ("ZombiGenerate", 10.0f, 10.0f);
=======
			InvokeRepeating ("EnemyGenerate", 10.0f, 10.0f);
>>>>>>> SpaceEscape/master

		}
		if (space.transform.position.z < -310.0f) {
			CancelInvoke ();
		}

		if (PlayController.isDamaged) {
			CancelInvoke ();
			if (endingModed) {
				InvokeRepeating ("TrapGenerate", 1.0f, 1.3f);
				InvokeRepeating ("ItemGenerate", 2.0f, 2.6f);
<<<<<<< HEAD
				InvokeRepeating ("ZombiGenerate", 4.0f, 5.2f);
=======
				InvokeRepeating ("EnemyGenerate", 4.0f, 5.2f);
>>>>>>> SpaceEscape/master
				
			} else {
				InvokeRepeating ("TrapGenerate", 4.0f, 2.0f);
				InvokeRepeating ("ItemGenerate", 8.0f, 4.0f);
<<<<<<< HEAD
				InvokeRepeating ("ZombiGenerate", 12.0f, 16.0f);
=======
				InvokeRepeating ("EnemyGenerate", 12.0f, 16.0f);
>>>>>>> SpaceEscape/master
			}
			
			
		}



	}

	void TrapGenerate ()
	{
		int ranNumTrapX = Random.Range (0, trapXs.Length);
		float rangeX = Random.Range (-5.0f, 5.0f);
		float rangeY = Random.Range (-5.0f, 5.0f);

		generatePosition = trapXs [ranNumTrapX].transform.position;
		generatePosition.x += rangeX;
		generatePosition.y += rangeY;
		Instantiate (trapXs [ranNumTrapX], generatePosition, trapXs [ranNumTrapX].transform.rotation);		
	}

<<<<<<< HEAD
	void ZombiGenerate ()
=======
	void EnemyGenerate ()
>>>>>>> SpaceEscape/master
	{
		int ranNumEnemy = Random.Range (0, enemies.Length);
		Instantiate (enemies [ranNumEnemy], enemies [ranNumEnemy].transform.position, enemies [ranNumEnemy].transform.rotation);		
	}

	void ItemGenerate ()
	{
		float rangeX = Random.Range (-3.0f, 3.0f);
		float rangeY = Random.Range (-4.0f, 1.0f);
		int ranNumItem = Random.Range (0, items.Length);

		generatePosition = items [ranNumItem].transform.position;
		generatePosition.x += rangeX;
		generatePosition.y += rangeY;


		Instantiate (items [ranNumItem], generatePosition, items [ranNumItem].transform.rotation);	


	}
}
