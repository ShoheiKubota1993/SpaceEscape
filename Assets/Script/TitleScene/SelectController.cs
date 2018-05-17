using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectController : MonoBehaviour
{
	public GameObject gameStart;
	public GameObject explanation;
	public GameObject titlePanel;
	public Text title;
	float redP, blueP, greenP, alfaP;
	float redT, blueT, greenT, alfaT;
	public float speed = 0.01f;
	public AudioClip click;


	void Start ()
	{
		titlePanel.SetActive (true);
	}

	void Update ()
	{

	}

	public void Gamestart ()
	{
		GetComponent<AudioSource> ().PlayOneShot (click);
		SceneManager.LoadScene ("GameScene");		
	}

	public void Tutorialstart ()
	{
		GetComponent<AudioSource> ().PlayOneShot (click);
		SceneManager.LoadScene ("TutorialScene");		
	}

	public void changeColor (string name)
	{
		if (name == "Start") {
			gameStart.GetComponent<Image> ().color = new Color (0.3f, 0.4f, 1.0f, 1.0f);
		}
		if (name == "Explanation") {
			explanation.GetComponent<Image> ().color = new Color (0.3f, 0.4f, 1.0f, 1.0f);
		}


	}

	public void returnColor (string name)
	{
		if (name == "Start") {
			gameStart.GetComponent<Image> ().color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
		}
		if (name == "Explanation") {
			explanation.GetComponent<Image> ().color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
		}

	}
}
		
