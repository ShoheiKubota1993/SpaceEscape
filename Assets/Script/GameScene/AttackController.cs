using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤー攻撃用クラス
public class AttackController : MonoBehaviour
{
	GameObject effect;
	ParticleSystem hit;

	//攻撃の有効可視範囲(Z軸)
	private float attackDeathPos = -500;

	void Start ()
	{
		effect = GameObject.Find ("Burst");
		hit = effect.GetComponent<ParticleSystem> ();

	}

	// Update is called once per frame
	void Update ()
	{
		//攻撃が有効可視を超えた場合実行
		if (transform.position.z < attackDeathPos) {
			Destroy (gameObject);

		}

	}

	public void Attack (Vector3 dir)
	{

		//指定座標に向けて進む
		GetComponent<Rigidbody> ().AddForce (dir, ForceMode.Impulse);


	}

	void OnTriggerEnter (Collider other)
	{

		//Enemy、EnemyAttackLeft、EnemyAttackRightのいずれかのオブジェクトに衝突した場合
		if (other.CompareTag ("Enemy") || other.CompareTag ("EnemyAttackLeft") || other.CompareTag ("EnemyAttackRight")) {
			//攻撃オブジェクトを破壊する
			Destroy (gameObject);
			//攻撃の位置にエフェクトの位置を合わせる
			effect.transform.position = transform.position;
			hit.Play ();
			//衝突したオブジェクトを破壊する

			Destroy (other.gameObject);
			effect.GetComponent<AudioSource> ().Play ();
			if (other.CompareTag ("Enemy")) {
				FindObjectOfType<TextManager> ().AddPoint (5000);
			}


		}


	}
}
