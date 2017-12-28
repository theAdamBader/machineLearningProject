using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightBullet : MonoBehaviour {

	public GameObject bulletPrefab;
	public Transform bulletSpawn;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.R)){
			Fire();
		}

	}

	void Fire()
	{
		// Create the Bullet from the Bullet Prefab
		GameObject bullet;
		bullet = Instantiate (bulletPrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation) as GameObject;

		// Add velocity to the bullet
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;

		// Destroy the bullet after 2 seconds
		Destroy(bullet, 2.0f);
	}
		


//	void OnCollisionEnter(Collision col){
//		var hit = col.gameObject;
//		var health = hit.GetComponent<EnemyHealth> ();
//
//		if (health != null) {
//			health.damageTaken (10);
//		}
//
//		Destroy (gameObject);
//	}


}
