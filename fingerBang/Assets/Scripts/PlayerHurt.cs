using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurt : MonoBehaviour {

	public int playerDamage = 5;

	void OnCollisionEnter(Collision playerHit){

		if (playerHit.gameObject.tag == "Player") {
			playerHit.gameObject.GetComponent<PlayerHealth> ().damagePlayerTaken (playerDamage);
		}
	}
}
