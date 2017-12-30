using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

	public int damage = 10;

	void OnCollisionEnter(Collision hit){

		if (hit.gameObject.tag == "Enemy") {
			hit.gameObject.GetComponent<EnemyHealth> ().damageTaken (damage);
		}

		Debug.Log (hit.transform.name);

	}
}
