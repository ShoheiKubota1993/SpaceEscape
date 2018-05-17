using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤー用のエフェクトクラス
public class EffectController : MonoBehaviour
{

	public GameObject player;
	// Use this for initialization
	void Start ()
	{


	}

	// Update is called once per frame
	void Update ()
	{
		Vector3 newPosition = transform.position;
		//プレイヤーの位置に更新
		newPosition = player.transform.position;
		transform.position = newPosition;
	}

}
