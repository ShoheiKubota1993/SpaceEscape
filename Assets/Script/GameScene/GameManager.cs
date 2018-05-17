using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public GameObject generate;
	public GenerateController gCon;
	public GameObject wind;
	public GameObject[] cameras;
	string endName;
	public GameObject space;
	public static bool gameStart;
	public GameObject player;
	public GameObject title;
	public GameObject ui;
	private float cofficient = 0.95f;
	public static int finalPartCount = 14;
	public static int goalDistance;
	public static bool attackMode;




	// Use this for initialization
	void Awake ()
	{
		Initialize ();
			
	}

	void Initialize ()
	{
		gameStart = false;
		PlayController.isGoal = false;
		PlayController.isDead = false;
		TrapController.directionSpeed = -1.0f;
		player.SetActive (false); 
		generate.SetActive (false);
		title.SetActive (true);
		ui.SetActive (true);
		cameras [0].SetActive (true);
		for (int i = 1; i < cameras.Length; i++) {
			cameras [i].SetActive (false);

		}
		goalDistance = (finalPartCount * 300) + 600;



	}

	// Update is called once per frame
	void Update ()
	{

		if (Input.GetKeyDown (KeyCode.X)) {
			gameStart = true;

		}

		if (gameStart) {
			title.SetActive (false);
			ui.SetActive (true);
			player.SetActive (true);
			generate.SetActive (true);
			//GetComponent<AudioSource> ().Stop ();

		}
		if (Input.GetKey (KeyCode.LeftAlt)) {
			if (cameras [0].activeSelf == true) {
				cameras [0].SetActive (false);
				cameras [3].SetActive (true);
				attackMode = true;
			} 		
			
		}
		if (Input.GetKeyUp (KeyCode.LeftAlt)) {
			if (cameras [3].activeSelf == true) {
				cameras [0].SetActive (true);
				cameras [3].SetActive (false);
				attackMode = false;

			}

		}



		if (PlayController.isGoal) {
			SpaceController.forceSpeed *= cofficient;
			endName = "Goal";
			generate.GetComponent<AudioSource> ().Stop ();
			StartCoroutine (EndGame (endName));			
		}


		if (PlayController.isDead) {
			SpaceController.forceSpeed *= cofficient;
			endName = "Dead";
			StartCoroutine (EndGame (endName));				
		}
		
	}

	IEnumerator EndGame (string name)
	{
		TrapController.directionSpeed = 0.0f;
		gCon.CancelInvoke ("Generate");
		Destroy (wind);
		if (endName == "Dead") {
			yield return new WaitForSeconds (2.0f);
			cameras [0].gameObject.SetActive (false);
			cameras [1].gameObject.SetActive (true);
			yield return new WaitForSeconds (4.0f);
			SceneManager.LoadScene ("GameOver");
		}
		if (endName == "Goal") {
			FindObjectOfType<TextManager> ().Save ();
			yield return new WaitForSeconds (2.0f);
			cameras [0].gameObject.SetActive (false);
			cameras [2].gameObject.SetActive (true);
			yield return new WaitForSeconds (4.0f);
			SceneManager.LoadScene ("GameClear", LoadSceneMode.Single);

		}



	}


}
