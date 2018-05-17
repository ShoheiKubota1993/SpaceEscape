using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{

	public Text text1;
	public Text text2;
	public Button button1;
	public Button button2;
	public Text text3;
	public Button button3;
	public Text text4;
	public Button button4;
	public GameObject player;
	public GameObject[] cameras;

	void Start ()
	{
		text1.gameObject.SetActive (true);
		button1.gameObject.SetActive (true);
		player.SetActive (true);

	}

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey (KeyCode.LeftAlt)) {
			if (cameras [0].activeSelf == true) {
				cameras [0].SetActive (false);
				cameras [1].SetActive (true);				
			} else {
				cameras [2].SetActive (false);
				cameras [1].SetActive (true);

			}		

		}
		if (Input.GetKeyUp (KeyCode.LeftAlt)) {
			if (cameras [1].activeSelf == true) {
				cameras [2].SetActive (true);
				cameras [1].SetActive (false);

			}

		}


	}

	public void Next1 ()
	{
		text1.gameObject.SetActive (false);
		button1.gameObject.SetActive (false);
		text2.gameObject.SetActive (true);
		button2.gameObject.SetActive (true);

	}

	public void Next2 ()
	{
		text2.gameObject.SetActive (false);
		button2.gameObject.SetActive (false);
		player.SetActive (false);
		text3.gameObject.SetActive (true);
		button3.gameObject.SetActive (true);

	}

	public void Next3 ()
	{
		text3.gameObject.SetActive (false);
		button3.gameObject.SetActive (false);
		text4.gameObject.SetActive (true);
		button4.gameObject.SetActive (true);

	}

	public void Next4 ()
	{
		text4.gameObject.SetActive (false);
		button4.gameObject.SetActive (false);
		SceneManager.LoadScene ("GameScene");

	}

	public void changeColor (int index)
	{
		switch (index) {
		case 1:
			button1.GetComponent<Image> ().color = new Color (0.3f, 0.3f, 0.3f, 1.0f);
			break;
		
		case 2:
			button2.GetComponent<Image> ().color = new Color (0.3f, 0.3f, 0.3f, 1.0f);
			break;

		case 3:
			button3.GetComponent<Image> ().color = new Color (0.3f, 0.3f, 0.3f, 1.0f);
			break;

		case 4:
			button4.GetComponent<Image> ().color = new Color (0.3f, 0.3f, 0.3f, 1.0f);
			break;

		default:
			break;

		}


	}

	public void returnColor (int index)
	{
		switch (index) {
		case 1:
			button1.GetComponent<Image> ().color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
			break;

		case 2:
			button2.GetComponent<Image> ().color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
			break;

		case 3:
			button3.GetComponent<Image> ().color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
			break;

		case 4:
			button4.GetComponent<Image> ().color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
			break;

		default:
			break;

		}
	}



}
