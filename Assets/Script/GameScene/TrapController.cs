using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//前から降ってくる隕石の制御クラス
public class TrapController : MonoBehaviour
{
	//消滅位置
	private float trapDeathPos = -350;
	//z軸へ進むスピード
	public static float directionSpeed;
	private float rotationX;
	private float rotationY;
	private float rotationZ;
	//減衰係数
	float cofficient = 0.97f;
	public int point;



	// Use this for initialization
	void Start ()
	{
		//x,y,z各座標を軸にランダムに回転するように設定
		rotationX = Random.Range (-2.0f, 2.0f);
		rotationY = Random.Range (-2.0f, 2.0f);
		rotationZ = Random.Range (-2.0f, 2.0f);
	}

	// Update is called once per frame
	void Update ()
	{


		if (PlayController.isDamaged) {
			//プレイヤーがダメージを受けたら、スピードを徐々に落とす
			directionSpeed *= cofficient;
		} else {
			if (!PlayController.isDead && !PlayController.isGoal) {
				directionSpeed = -1.2f;
			}
		}
		//x,y,z各座標を軸にランダムに回転
		transform.Rotate (rotationX, rotationY, rotationZ);
		//z軸にdirectionSpeedだけ進む(第二引数は回転に依存せず移動させるため)
		transform.Translate (0, 0, directionSpeed, Space.World);
		//消滅位置を越えると消滅
		if (transform.position.z < trapDeathPos) {
			Destroy (gameObject);

		}


		//プレイヤーがゴールまたは死んだら消滅
		if (PlayController.isDead || PlayController.isGoal) {
			Destroy (gameObject);

		}


	}




}
