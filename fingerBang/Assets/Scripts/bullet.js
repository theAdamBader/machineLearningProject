#pragma strict

public var bulletPrefab: GameObject;
public var bulletSpawn: Transform;

public var fireRate: float = 0.4;
private var nextShot: float = 0;

public var maxAmmo: int = 10;
private var currentAmmo: int;


function Start () {
	currentAmmo = maxAmmo;
}

function Update () {
	
}

function Fire(){

var bullet: GameObject;
bullet = Instantiate (bulletPrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation) as GameObject;

bullet.GetComponent(Rigidbody).velocity = bullet.transform.forward * 6;


	// Destroy the bullet after 2 seconds
	Destroy(bullet, 2.0f);

	//Lose one bullet everytime the weapon is shot
	currentAmmo--;
}