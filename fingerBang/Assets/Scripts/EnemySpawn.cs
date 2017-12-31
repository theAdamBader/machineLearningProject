/*
REFERENCE
	Enemy Spawn: https://unity3d.com/learn/tutorials/projects/survival-shooter/more-enemies
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

	public PlayerHealth playerHealth;
	public GameObject enemy;
	public float timeToSpawn = 3.0f;
	public Transform[] spawnPoints;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Spawn", timeToSpawn, timeToSpawn);
	}
	
	void Spawn(){

		if (playerHealth.currenPlayertHealth <= 0f) {
			return;
		}

		int spawnPointArray = Random.Range (0, spawnPoints.Length);

		Instantiate (enemy, spawnPoints [spawnPointArray].position, spawnPoints [spawnPointArray].rotation);
	}
}
