using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	public const int maxHealth = 30;
	public int currentHealth = maxHealth;

	void Update(){
	
	}

	public void damageTaken (int amount){
		currentHealth -= amount;

		if (currentHealth <= 0) {
			Destroy (gameObject);
		}
	}
}
