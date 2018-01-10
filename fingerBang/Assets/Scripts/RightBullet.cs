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
using UnityEngine.UI;

public class RightBullet : MonoBehaviour {

	public GameObject bulletPrefab;
	public Transform bulletSpawn;

	public float fireRate = 0.4f;
	private float nextShot = 0.0f;

	public int maxAmmo = 10;
	private int currentAmmo;
	public float reloadSpeed = 1f;

	public Text rightAmmoCount;


	void Start(){

		//Starts with current ammo
		currentAmmo = maxAmmo; 

		ammoCounts ();
	}

	// Update is called once per frame
	void Update(){

		 //If key press A to reload weapon
		if (Input.GetKeyDown (KeyCode.Alpha2)) {

			//Start Coroutine, starts the reload function; then returns back to the function
			StartCoroutine (Reload ());
			return;

			}
		
		//If key press R then shoot bullet
		if (Input.GetKeyDown(KeyCode.Alpha1) && Time.time > nextShot){

			//If current ammo is more than zero then fire weapon
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

		//Lose one bullet everytime the weapon is shot
		currentAmmo--;

		ammoCounts ();

	}

	IEnumerator Reload(){
		
		Debug.Log ("Reloading...");

		//Get accessor to a new wait with a reload speed
		yield return new WaitForSeconds (reloadSpeed);

		//When reloading, current ammo grabs the max ammo
		currentAmmo = maxAmmo;

		ammoCounts ();
	}

	void ammoCounts(){

		rightAmmoCount.text = "Right Ammo: " + currentAmmo + "/" + maxAmmo.ToString();
	}
}