/*
	REFERENCE:
		Day/Night Cycle by Aaron Hibberd: https://www.youtube.com/watch?v=DmhSWEJjphQ&t=381s
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cycle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround (Vector3.zero, Vector3.right, 10f * Time.deltaTime);
	}
}
