using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour
{

	public  float forwardForce = 10.0f;
	Rigidbody rigid;
	Animator animator;
	private float force;
	public float zForce;
	public ParticleSystem getCoin;
	public ParticleSystem boost;
	public GameObject effect;
	public AudioClip start;
	public AudioClip coinGet;
	public AudioClip damaged;
	public AudioClip dead;
	public AudioClip goal;
	public AudioClip dash;
	public AudioClip attacked;
	public int point = 10;
	public static int life = 5;
	bool isChangeable = true;
	public static bool isDead = false;
	public static bool isDamaged;
	public static bool isGoal;
	bool isTurnable = false;
	public Transform backRotation;
	public Transform frontRotation;
	public GameObject attack;
	public Camera attackCamera;
	bool unlocked;
	public Transform player;
	public LineRenderer line;


	void Awake ()
	{
		Initialize ();

	}

	void Start ()
	{
		Invoke ("TurnForward", 2.0f);
		Invoke ("Unlocked", 4.0f);
		
	}

	void Initialize ()
	{
		rigid = GetComponent<Rigidbody> ();
		animator = GetComponent<Animator> ();
		animator.SetTrigger ("IsStart");
		life = 5;

	}

	void Update ()
	{		


		if (GameManager.attackMode && unlocked) {
			isTurnable = false;
			Turning ();
			transform.rotation = Quaternion.Slerp (player.transform.rotation, backRotation.transform.rotation, 0.2f);
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Input.GetKey (KeyCode.LeftCommand)) {
				line.enabled = true;
			}
			if (Input.GetKeyUp (KeyCode.LeftCommand)) {
				line.enabled = false;
			}
			line.SetPosition (0, transform.position);
			line.SetPosition (1, ray.origin + ray.direction * 100);
			if (Input.GetMouseButtonDown (0)) {
				Vector3 worldDir = ray.direction;
				Vector3 generatePosition = transform.position;
				generatePosition.z -= 2.0f;
				GameObject attacker = Instantiate (attack, generatePosition, transform.rotation) as GameObject;
				attacker.GetComponent<AttackController> ().Attack (worldDir.normalized * 100);
				animator.SetTrigger ("IsAttack");
				GetComponent<AudioSource> ().PlayOneShot (attacked);


				RaycastHit hit = new RaycastHit ();

				if (Physics.Raycast (ray, out hit)) {
					line.SetPosition (1, hit.point);
				} else {
					line.SetPosition (1, ray.origin + ray.direction * 100);
				}

			}

		}
		if (!GameManager.attackMode && unlocked) {
			line.enabled = false;
			isTurnable = true;
		}




		float x = Input.GetAxisRaw ("Horizontal");
		float y = Input.GetAxisRaw ("Vertical");
		force = 50.0f;

		if (Input.GetKey (KeyCode.LeftShift)) {
			force = 100.0f;

		}
			
		if (!isDamaged) {
			Move (x, y, force);
		} else {
			x = 0.0f;
			y = 0.0f;
			force = 0.0f;
			Move (x, y, force);
			
		}
		if (isTurnable) {
			transform.rotation = Quaternion.Slerp (player.transform.rotation, frontRotation.transform.rotation, 0.1f);			
		}

		
	}

	void Move (float x, float y, float force)
	{
		rigid.AddForce (x * force, y * force, 0.0f);
		animator.SetFloat ("Horizontal", x);
		animator.SetFloat ("Vertical", y);
		if (force >= 90 && x != 0.0f || force >= 100 && y != 0.0f) {
			boost.Play ();	
		}
		
	}



	void OnTriggerEnter (Collider other)
	{
		
		if (other.CompareTag ("TrapX") || other.CompareTag ("Storn") || other.CompareTag ("Enemy") || other.CompareTag ("EnemyAttackLeft") || other.CompareTag ("EnemyAttackRight")) {
			if (!isDamaged && !isGoal && !isDead) {
				string currentLayer = LayerMask.LayerToName (gameObject.layer);
				if (currentLayer == "Player") {
					StartCoroutine ("Damaged");					
				}
			}
		} 

		if (other.CompareTag ("Item")) {
			getCoin.Play ();
			GetComponent<AudioSource> ().PlayOneShot (coinGet);
			FindObjectOfType<TextManager> ().AddPoint (other.gameObject.GetComponent<ItemController> ().point);
			Destroy (other.gameObject);
	
		}
		if (other.CompareTag ("Goal")) {
			isGoal = true;
			Goal ();

		} 

	}


	IEnumerator Damaged ()
	{

		   
		if (life > 0) {
			if (isChangeable) {
				isChangeable = false;
				life--;

				if (life == 0) {					
					isDead = true;
					Dead ();
					yield break;

				}
				isDamaged = true;
				animator.SetBool ("Damaged", true);
				GetComponent<AudioSource> ().PlayOneShot (damaged);
				gameObject.layer = LayerMask.NameToLayer ("Invisible");
				yield return new WaitForSeconds (0.75f);
				animator.SetBool ("Damaged", false);
				yield return new WaitForSeconds (1.25f);			
				isChangeable = true;
				isDamaged = false;
				yield return new WaitForSeconds (3.0f);
				gameObject.layer = LayerMask.NameToLayer ("Player");


			
			}


		}


	}

	void Dead ()
	{
		animator.SetTrigger ("IsDead");
		GetComponent<AudioSource> ().PlayOneShot (dead);
		
	}

	void Goal ()
	{
		animator.SetTrigger ("IsClear");
		GetComponent<AudioSource> ().PlayOneShot (goal);

	}

	void StartVoice (AudioClip voice)
	{
		GetComponent<AudioSource> ().PlayOneShot (voice);


	}

	void TurnForward ()
	{
		isTurnable = true;
	}

	void Unlocked ()
	{
		unlocked = true;
	}

	void Turning ()
	{
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);

		Debug.DrawRay (camRay.origin, camRay.direction * 100, Color.red, 0.1f, false);
		RaycastHit floorHit;
		if (Physics.Raycast (camRay, out floorHit)) {
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (floorHit.point - transform.position), 0.3f);

		}


	}
		




}


