/*
REFERENCE:
	Shooting Script: https://unity3d.com/learn/tutorials/temas/multiplayer-networking/shooting-single-player?playlist=29690
	Delay Shooting: https://answers.unity.com/questions/283377/how-to-delay-a-shot.html
	Reload Bullet: https://www.youtube.com/watch?v=kAx5g9V5bcM
	No Ammo: https://www.youtube.com/watch?v=k4dTfJNaLmc
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightBullet : MonoBehaviour {

	public GameObject bulletPrefab;
	public Transform bulletSpawn;

	public float fireRate = 0.4f;
	private float nextShot = 0.0f;

	public int maxAmmo = 10;
	private int currentAmmo;
	public float reloadSpeed = 1f;
	private bool isReloading = false;

	void Start(){
		currentAmmo = maxAmmo;
	}

	// Update is called once per frame
	void Update(){


		 if (Input.GetKeyDown (KeyCode.A)) {
			StartCoroutine (Reload ());
			return;
			}
		

		if (Input.GetKeyDown(KeyCode.R) && Time.time > nextShot){
			if (currentAmmo > 0) {
				nextShot = Time.time + fireRate;
				Fire ();
			}
		}

	}

	void Fire(){
		
		// Create the Bullet from the Bullet Prefab
		GameObject bullet;
		bullet = Instantiate (bulletPrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation) as GameObject;

		// Add velocity to the bullet
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;

		// Destroy the bullet after 2 seconds
		Destroy(bullet, 2.0f);

		currentAmmo--;
	}

	IEnumerator Reload(){

		isReloading = true;
		Debug.Log ("Reloading...");

		yield return new WaitForSeconds (reloadSpeed);

		currentAmmo = maxAmmo;

		isReloading = false;
	}
		
}