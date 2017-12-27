using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftBullet : MonoBehaviour {
	public GameObject bulletPrefab;
	public Transform bulletSpawn;


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.E)){
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

		Rigidbody bulletRigid;
		bulletRigid = bullet.GetComponent<Rigidbody>();

		// Destroy the bullet after 2 seconds
		Destroy(bullet, 2.0f);
	}

	void OnCollisionEnter(){
		Destroy (gameObject);
	}
}
