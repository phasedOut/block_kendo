using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Movement : MonoBehaviour {

	private Rigidbody rb;
	private GameObject axe;
	private GameObject bow;

	public float speed;
	public float blockInterval;
	public float swingSpeed;
	public float swingDuration;
	public float waitTimeAfterAttack;
	public float waitTimeAfterShoot;

	private Animation anim;

	private bool shootingRightNow;
	private bool swingingRightNow;
	private bool isOkayToBlock;

	Rigidbody AxeRb;
	Player1Health playerHealth;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		isOkayToBlock = true;
		axe = transform.Find ("_Axe").Find ("axe").gameObject;
		axe.SetActive (false);
		bow = transform.Find ("_Bow").Find ("strangeBow").gameObject;
		bow.SetActive (false);


		anim = axe.GetComponent<Animation> ();
		swingingRightNow = false;
		shootingRightNow = false;

		playerHealth = transform.GetComponent<Player1Health> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Q)) {
			transform.Translate(Vector3.forward * Time.deltaTime * speed);
		}
		if (Input.GetKey (KeyCode.G)) {
			transform.Rotate (0, 5, 0);
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.Rotate (0, -5, 0);
		}

		if (Input.GetKeyDown (KeyCode.F)) {
			if (isOkayToBlock) {
				transform.Translate(-Vector3.forward * 1);
				isOkayToBlock = false;
				StartCoroutine (BlockWait ());
			}
		}

		if (Input.GetKeyDown (KeyCode.W)) {
			if (!swingingRightNow) {
				axe.SetActive(true);
				StartCoroutine (Attack ());
			}
		}

		if (Input.GetKeyDown (KeyCode.E)) {
			if (!shootingRightNow) {
				StartCoroutine (ShowAndHideBow ());

			}
		}
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "Player2Axe") {
			Debug.Log ("Axe hit!");
			playerHealth.isHit = true;
			playerHealth.hitWeapon = 0;
			Vector3 dir = other.contacts [0].point - transform.position;
			dir = -dir.normalized;
			rb.transform.Translate (-dir * 2);
		} 
		if (other.gameObject.tag == "Player2Arrow") {
			Debug.Log ("Arrow hit!");
			playerHealth.isHit = true;
			playerHealth.hitWeapon = 1;
		}
	}
		
	IEnumerator BlockWait() {
		yield return new WaitForSeconds(blockInterval);
		isOkayToBlock = true;
	}

	IEnumerator Attack() {
		swingingRightNow = true;
		anim ["swing"].speed = swingSpeed;
		anim.Play ();
		yield return new WaitForSeconds(swingDuration);
		axe.SetActive (false);
		yield return new WaitForSeconds (waitTimeAfterAttack);
		swingingRightNow = false;
	}

	IEnumerator ShowAndHideBow() {
		shootingRightNow = true;
		bow.SetActive (true);
		yield return new WaitForSeconds (waitTimeAfterShoot);
		bow.SetActive (false);
		shootingRightNow = false;

	}
	//TODO
	//make attackwait faster for faster swingSpeed
}
