using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerEndController : MonoBehaviour
{
	Animator animator;
	float timer;
	public GameObject select;
	bool once = true;
	public Button yes;
	public Button no;

	// Use this for initialization
	void Start ()
	{
		animator = GetComponent<Animator> ();
		animator.SetTrigger ("IsStart");
		select.gameObject.SetActive (false);
	
	}

	// Update is called once per frame
	void Update ()
	{
		timer += Time.deltaTime;
		if (timer >= 5.0f && !select.activeSelf && once) {
			select.gameObject.SetActive (true);
			once = false;
			
		}
		
	}

	void Dontmind (AudioClip voice)
	{
		GetComponent<AudioSource> ().PlayOneShot (voice);
	
	}

	void Question (AudioClip voice)
	{
		GetComponent<AudioSource> ().PlayOneShot (voice);

	}

	public void Challange ()
	{
		animator.SetTrigger ("IsChallenge");
		select.gameObject.SetActive (false);
		
	}

	public void NoChallange ()
	{
		animator.SetTrigger ("IsNoChallenge");
		select.gameObject.SetActive (false);

	}

	void Yes (AudioClip voice)
	{
		GetComponent<AudioSource> ().PlayOneShot (voice);
<<<<<<< HEAD
		Invoke ("Restart", 3.0f);
=======
		Invoke ("GameRestart", 3.0f);
>>>>>>> SpaceEscape/master
	
	}

	void No (AudioClip voice)
	{
		GetComponent<AudioSource> ().PlayOneShot (voice);
<<<<<<< HEAD
		Invoke ("Restart", 3.0f);
		
	}

	void Restart ()
=======
		Invoke ("ReturnTitle", 3.0f);
		
	}

	void GameRestart ()
>>>>>>> SpaceEscape/master
	{
		SceneManager.LoadScene ("GameScene");
		
	}

<<<<<<< HEAD
=======
	void ReturnTitle ()
	{
		SceneManager.LoadScene ("TitleScene");

	}

>>>>>>> SpaceEscape/master
	public void changeColor (int index)
	{
		switch (index) {
		case 1:
			yes.GetComponent<Image> ().color = new Color (0.3f, 0.3f, 0.3f, 1.0f);
			break;

		case 2:
			no.GetComponent<Image> ().color = new Color (0.3f, 0.3f, 0.3f, 1.0f);
			break;

		default:
			break;

		}


	}

	public void returnColor (int index)
	{
		switch (index) {
		case 1:
			yes.GetComponent<Image> ().color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
			break;

		case 2:
			no.GetComponent<Image> ().color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
			break;
		default:
			break;

		}
	}

}
