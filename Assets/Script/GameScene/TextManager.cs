using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
	//ライフ表示用
	public Text lifeText;
	//スコア用
	public Text scoreText;
	//ハイスコア用
	public Text highScoreText;
	//時間表示用
	public Text timeText;
	//距離
	public Slider distance;
	//選択したプライヤーのアイコン
	public Image icon;
	//ゲーム開始時表示用
	public GameObject startText;
	//ゴール後表示用
	public GameObject goalText;
	//ゲームオーバー表示用
	public GameObject gameOverText;
	string sLife;
	public GameObject life;
	public Image gage1;
	public Image gage2;
	public Image gage3;
	public Image gage4;
	public Image gage5;
	public static float time;
	public static int score;
	int highScore;
	string highScoreKey = "highScore";
	//スタートテキストのカラー
	float redS, blueS, greenS, alfaS;
	//ゴールテキストのカラー
	float redG, blueG, greenG, alfaG;
	float redD, blueD, greenD, alfaD;
	float red, blue, green, alfa;
	public float speed = 0.01f;


	void Awake ()
	{
		Initialize ();

	}

	void Start ()
	{
		distance.maxValue = GameManager.goalDistance;

	}


	void Update ()
	{

		//ゲームスタート
			//ライフ計算※ここはいけてないのでいずれ修正したい
		if (GameManager.gameStart) {
			life.gameObject.SetActive (true);
			timeText.gameObject.SetActive (true);
			//icon.gameObject.SetActive (true);
			distance.gameObject.SetActive (true);
			if (PlayController.life == 4) {
				gage5.gameObject.SetActive (false);

			} else if (PlayController.life == 3) {
				gage4.gameObject.SetActive (false);
			} else if (PlayController.life == 2) {
				gage3.gameObject.SetActive (false);
			} else if (PlayController.life == 1) {
				gage2.gameObject.SetActive (false);
			} else if (PlayController.life == 0) {
				gage1.gameObject.SetActive (false);
			}

			startText.SetActive (true);
			startText.GetComponent<Text> ().color = new Color (redS, greenS, blueS, alfaS);
			alfaS -= speed;


			if (PlayController.isGoal) {
				//ゴール表示
				goalText.SetActive (true);
				goalText.GetComponent<Text> ().color = new Color (redG, greenG, blueG, alfaG);
				//徐々に消えるように設定
				alfaG -= speed;
				//afterGoal.SetActive (true);
				//afterGoal.GetComponent<Image> ().color = new Color (red, green, blue, alfa);
				alfa += speed;


			}
			if (PlayController.isDead) {
				//ゲームオーバー表示
				gameOverText.SetActive (true);
				gameOverText.GetComponent<Text> ().color = new Color (redD, greenD, blueD, alfaD);
				alfaD -= speed;

			}
			if (!PlayController.isDead && !PlayController.isGoal) {
				time += Time.deltaTime;
			}

			timeText.text = "TIME:" + time.ToString ("F2");
			lifeText.text = sLife;
			if (score > highScore) {
				highScore = score;
			}
			scoreText.text = "Score:" + score.ToString ();
			distance.value = Mathf.Abs (SpaceController.currentDistance);
		}
		highScoreText.text = "HighScore:" + highScore.ToString ();
	}


	//再プレイのためにゲームスタート前に初期化
	private void Initialize ()
	{
		score = 0;
		time = 0;
		highScore = PlayerPrefs.GetInt (highScoreKey, 0);
		sLife = "︎❤︎︎❤︎︎❤︎︎︎︎❤︎︎︎︎︎❤";
		startText.SetActive (false);
		goalText.SetActive (false);
		gameOverText.SetActive (false);
		lifeText.gameObject.SetActive (false);
		timeText.gameObject.SetActive (false);
		icon.gameObject.SetActive (false);
		distance.gameObject.SetActive (false);
		startText.SetActive (false);
		goalText.SetActive (false);
		gameOverText.SetActive (false);
		timeText.gameObject.SetActive (false);
		life.gameObject.SetActive (false);
		gage1.gameObject.SetActive (true);
		gage2.gameObject.SetActive (true);
		gage3.gameObject.SetActive (true);
		gage4.gameObject.SetActive (true);
		gage5.gameObject.SetActive (true);
		//icon.gameObject.SetActive (false);
		distance.gameObject.SetActive (false);
		//	afterGoal.SetActive (false);
		redS = goalText.GetComponent<Text> ().color.r;
		greenS = goalText.GetComponent<Text> ().color.g;
		blueS = goalText.GetComponent<Text> ().color.b;
		alfaS = goalText.GetComponent<Text> ().color.a;
		redG = goalText.GetComponent<Text> ().color.r;
		redD = goalText.GetComponent<Text> ().color.r;
		greenG = goalText.GetComponent<Text> ().color.g;
		greenD = goalText.GetComponent<Text> ().color.g;
		blueG = goalText.GetComponent<Text> ().color.b;
		blueD = goalText.GetComponent<Text> ().color.b;
		alfaG = goalText.GetComponent<Text> ().color.a;
		alfaD = goalText.GetComponent<Text> ().color.a;



	}
	//ハイスコア保存用

//		red = afterGoal.GetComponent<Image> ().color.r;
//		green = afterGoal.GetComponent<Image> ().color.g;
//		blue = afterGoal.GetComponent<Image> ().color.b;
//		alfa = afterGoal.GetComponent<Image> ().color.a;


	}

	public void Save ()
	{
		PlayerPrefs.SetInt (highScoreKey, highScore);
		PlayerPrefs.Save ();

	}
	//ポイント追加用
	public void AddPoint (int point)
	{
		score += point;
	}
}
