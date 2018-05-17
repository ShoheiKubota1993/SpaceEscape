using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//敵の攻撃用クラス
public class EnemyAttackController : MonoBehaviour
{


	private GameObject player;
	//プライヤーの位置同期用
	Vector3 newPosition;
	//攻撃の可視化有効範囲(Z軸)
public class EnemyAttackController : MonoBehaviour
{
	float desPosition = -300;
	// Use this for initialization
	void Start ()
	{
		//rigid = GetComponent<Rigidbody> ();
		player = GameObject.Find ("Player");

	}

	// Update is called once per frame
	void LateUpdate ()
	{
		//目的地をプレイヤーのZ軸5m先に設定
		newPosition = player.transform.position;
		newPosition.z += 5;
		if (gameObject.tag == "EnemyAttackLeft") {
			newPosition.x -= 0.25f;
		}

		//徐々にプレイヤーに近くように設定

		transform.position = Vector3.Lerp (transform.position, newPosition, Time.deltaTime);

	}

	void Update ()
	{
		//攻撃オブジェクトが攻撃の可視化有効範囲から外れてしまった場合実行
		if (transform.position.z > desPosition) {
			Destroy (gameObject);

		}
	}
}
