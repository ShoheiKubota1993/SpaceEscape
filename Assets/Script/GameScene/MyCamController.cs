using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamController : MonoBehaviour
{

	public GameObject player;
	Vector3 offset;





	// Use this for initialization
	void Start ()
	{
		
		offset = transform.position - player.transform.position;

		
		
	}
	
	// Update is called once per frame
	void LateUpdate ()
	{
		Vector3 newPosition = transform.position;
		newPosition = player.transform.position + offset;
		transform.position = Vector3.Lerp (transform.position, newPosition, 5.0f * Time.deltaTime);

	}
}
