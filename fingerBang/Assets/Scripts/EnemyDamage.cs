using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

	public int damage = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision other){

		if (other.gameObject.tag == "Enemy") {
			other.gameObject.GetComponent<EnemyHealth> ().damageTaken (damage);
		}

		Debug.Log (other.transform.name);
	}
}
