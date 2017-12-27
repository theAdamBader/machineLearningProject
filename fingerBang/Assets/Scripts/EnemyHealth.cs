using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	public int currentHealth = 10;

	public void damageTaken (int amount){
		currentHealth -= amount;

		if (currentHealth <= 0) {
			Destroy (gameObject);
		}
	}
}
