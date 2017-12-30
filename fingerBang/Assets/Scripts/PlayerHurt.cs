using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurt : MonoBehaviour {

	public int damage = 5;

	void OnCollisionEnter(Collision hit){

		if (hit.gameObject.tag == "Player") {
			hit.gameObject.GetComponent<PlayerHealth> ().damageTaken (damage);
		}
	}
}
