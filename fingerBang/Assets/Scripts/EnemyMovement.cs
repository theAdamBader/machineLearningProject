using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	Transform enemyMovement;
	float rotationSpeed = 3.0f;
	float movementSpeed = 2.0f;

	// Use this for initialization
	void Start () {
		enemyMovement = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		Movement ();
	}

	void Movement(){
		//Look at the player
		transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (enemyMovement.position - transform.position), rotationSpeed * Time.deltaTime);

		//Move to the player
		transform.position += transform.forward * movementSpeed * Time.deltaTime;

		Destroy (gameObject, 20.0f);
	}
}
