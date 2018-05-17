using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameClearController : MonoBehaviour
{
	float timer;
	public ParticleSystem particle;
	public GameObject clearText;
	public GameObject backButton;
	bool once1 = true;
	bool once2 = true;
	bool isCameraChange;
	float interval = 5.0f;
	public GameObject[] cameras;
	public GameObject mainCamera;
	Animator animator;
	public Button returnButton;

	// Use this for initialization
	void Awake ()
	{
		animator = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update ()
	{
		timer += Time.deltaTime;
		if (timer >= 7 && once1) {
			once1 = false;
			particle.Play ();
		}
		if (timer >= 9) {
			clearText.SetActive (true);	
		}

		if (timer >= 12 && once2) {
			once2 = false;
			timer = 0.0f;
			isCameraChange = true;
			backButton.SetActive (true);

		}
		if (isCameraChange) {
			

			if (timer > interval) {
				clearText.SetActive (false);
				timer = 0.0f;
				mainCamera.SetActive (false);
				int num = Random.Range (0, cameras.Length);
				for (int i = 0; i < cameras.Length; i++) {

					if (i == num) {
						cameras [i].SetActive (true);
						
					} else {
						cameras [i].SetActive (false);						
					}
				}
			}		
		}
	}

	void Happy (AudioClip voice)
	{
		GetComponent<AudioSource> ().PlayOneShot (voice);
		
	}

	public void Return ()
	{
		animator.SetTrigger ("IsReturn");

	}

	void Bye (AudioClip voice)
	{
		GetComponent<AudioSource> ().PlayOneShot (voice);
		Invoke ("ReturnGame", 4.0f);
		
	}

	void ReturnGame ()
	{
<<<<<<< HEAD
		SceneManager.LoadScene ("GameScene", LoadSceneMode.Single);
=======
		SceneManager.LoadScene ("TitleScene", LoadSceneMode.Single);
>>>>>>> SpaceEscape/master

		
	}

	public void changeColor ()
	{
		returnButton.GetComponent<Image> ().color = new Color (0.3f, 0.3f, 0.3f, 1.0f);
	}

	public void returnColor ()
	{
		returnButton.GetComponent<Image> ().color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
	}
}
