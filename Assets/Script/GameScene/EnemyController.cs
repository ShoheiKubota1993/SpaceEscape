using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
//敵の制御クラス
public class EnemyController : MonoBehaviour
{

	//消滅位置
	private float enemyDeathPos = -200;
	//ブースト発動位置
	private float enemyBoostPos = -310;
	//z軸に進む速さ
	public static float directionSpeed;
	//減衰係数
	float cofficient = 0.97f;
	//敵毎に撃破されて時のポイントを設定
	public int point;
	//敵の種類、数を登録

	public GameObject[] enemyAttacks;
	public ParticleSystem attackLeft;
	public ParticleSystem attackRight;
	// Use this for initialization
	void Start ()
	{
		//InvokeRepeating ("Attack", 3.0f, 6.0f);
		StartCoroutine ("Attack");
	}

	// Update is called once per frame
	void Update ()
	{

		if (PlayController.isDamaged) {
			//徐々にスピードを落とす
			directionSpeed *= cofficient;
		}
		if (gameObject.tag == "Enemy") {
			directionSpeed = 0.1f;
		}
		//z座標がブースト発動位置を過ぎた場合、スピードを変更
		if (transform.position.z > enemyBoostPos && gameObject.tag == "Enemy") {
			directionSpeed = 1.0f;
		}
		transform.Translate (0, 0, directionSpeed, Space.World);

		//z座標が消滅位置を過ぎた場合、オブジェクトを破壊する
		if (transform.position.z > enemyDeathPos && gameObject.tag == "Enemy") {
			Destroy (gameObject);
		}
		//プレイヤーがゴールまたは、死亡した場合
		if (PlayController.isDead || PlayController.isGoal) {
			Destroy (gameObject);

		}




	}

	private IEnumerator Attack ()
	{
		while (true) {
			//6秒毎に攻撃
			yield return new WaitForSeconds (6.0f);
			int ranNum = Random.Range (0, 2);
			//数によって攻撃する個数および位置を決定/実行
			if (ranNum == 2) {
				Instantiate (enemyAttacks [0], transform.position, transform.rotation);
				Instantiate (enemyAttacks [1], transform.position, transform.rotation);
				attackLeft.Play ();
				attackRight.Play ();
			}
			if (ranNum == 1) {
				Instantiate (enemyAttacks [1], transform.position, transform.rotation);
				attackRight.Play ();
			}
			if (ranNum == 0) {
				Instantiate (enemyAttacks [0], transform.position, transform.rotation);
				attackLeft.Play ();
			}


		}

	}
}
