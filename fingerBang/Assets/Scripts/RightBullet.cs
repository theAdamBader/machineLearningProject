using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightBullet : MonoBehaviour {

	public GameObject bulletPrefab;
	public Transform bulletSpawn;

	public int damage = 10;

	// Use this for initialization
	void Start () {
		
	}
	
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


		RaycastHit hit;
		Ray ray = new Ray (transform.position, transform.forward);
		if (Physics.Raycast(ray, out hit, 100f)){
			if (hit.transform.tag == "Enemy") {
				hit.transform.GetComponent<EnemyHealth> ().damageTaken(damage);
			}

		}

		// Destroy the bullet after 2 seconds
		Destroy(bullet, 2.0f);
	}


}
