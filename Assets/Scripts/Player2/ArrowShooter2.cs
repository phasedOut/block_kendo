using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShooter2 : MonoBehaviour {

	public float waitTimeAfterShoot;

	private GameObject arrowPrefab;
	private bool readyToShoot;
	GameObject newArrow;
	Rigidbody rb;

	// Use this for initialization
	void Start () {
		arrowPrefab = Resources.Load ("arrowProjectile") as GameObject;
		readyToShoot = true;

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Slash)) {
			if (readyToShoot) {
				StartCoroutine (ShootAndDestroyArrow ());
			}
			//bowPrefab.SetActive (true);
		}
	}
		

	IEnumerator ShootAndDestroyArrow() {
		newArrow = Instantiate (arrowPrefab) as GameObject;
		newArrow.tag = "Player2Arrow";
		newArrow.AddComponent<BoxCollider> ();
		newArrow.transform.position = transform.position + (transform.forward*2);
		rb = newArrow.GetComponent<Rigidbody> ();
		rb.velocity = transform.forward * 15;
		readyToShoot = false;
		yield return new WaitForSeconds (waitTimeAfterShoot);
		readyToShoot = true;

		Destroy (newArrow, 3f);
	}
}
