using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingAxe : MonoBehaviour {

	public static Animation anim;
	public GameObject myPrefab;
	public static float swingSpeed;

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animation> ();

	}
	
	// Update is called once per frame
	void Update () {


	}
		

//	public static void CreateAxe(Vector3 pos) {
//		Instantiate (myPrefab);
//		print ("created axe");
//
//	}


	public static void Swing() {
		anim["swing"].speed = swingSpeed;
		anim.Play ();

		//myPrefab.GetComponent<Renderer> ().enabled = false;
	}

//	IEnumerator ShowAndHide(float delay) {
//		go.SetActive (true);

//		anim.Play();
//		yield return new WaitForSeconds (delay);
//		go.SetActive (false);
//	}

}
