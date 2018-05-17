using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCameraController : MonoBehaviour
{
	float timer;
	public GameObject destinationPosition;
	public ParticleSystem particle;




	// Use this for initialization
	void Start ()
	{
		
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		timer += Time.deltaTime;

		if (timer >= 5) {			
			transform.position = Vector3.Lerp (transform.position, destinationPosition.transform.position, 0.5f * Time.deltaTime);

		}
	}
}
