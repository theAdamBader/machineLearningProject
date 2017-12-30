using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

	public GameObject bulletPrefab;
	public Transform bulletSpawn;

	public float fireRate = 3.0f;
	private float nextShot = 2.0f;
	float rotationSpeed = 3.0f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		//Look at the player
		transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (bulletSpawn.position - transform.position), rotationSpeed * Time.deltaTime);

		if (Time.time > nextShot){

				nextShot = Time.time + fireRate;
				Fire ();

			}
	}

	void Fire(){

		// Create the Bullet from the Bullet Prefab
		GameObject bullet;
		bullet = Instantiate (bulletPrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation) as GameObject;

		// Add velocity to the bullet
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 16;

		// Destroy the bullet after 2 seconds
		Destroy(bullet, 20.0f);

	}
}
