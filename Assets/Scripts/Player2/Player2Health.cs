using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2Health : MonoBehaviour {

	public float startingHealth;
	public float currentHealth;
	public Slider healthSlider;

	//melee (0)
	//arrow(1)
	public bool isHit;
	public int hitWeapon;

	public bool isBlocking;

	// Use this for initialization
	void Start () {
		currentHealth = startingHealth;
		healthSlider.value = CalculateHealth();
	}
	
	// Update is called once per frame
	void Update () {
		//melee weapon damage
		if (isHit) {
			if (!isBlocking) {
				if (hitWeapon == 0) {
					DealDamage (6);
					isHit = false;
				}
				//arrow weapon damage
				if (hitWeapon == 1) {
					DealDamage (3);
					isHit = false;
				}
			}
		}
	}

	void DealDamage(float damageValue) {
		currentHealth -= damageValue;
		healthSlider.value = CalculateHealth ();
		if (currentHealth <= 0) {
			Die ();
		}

	}

	float CalculateHealth() {
		return currentHealth / startingHealth;
	}

	void Die() {
		currentHealth = 0;
		mainmenu.gameIsSet = true;
		mainmenu.winner = "blue";

	}
}
