using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using Random=UnityEngine.Random;

public class Disparo_de_Freezer : MonoBehaviour {

	public GameObject bubble;
	public float timeLapsedLastFire = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timeLapsedLastFire += Time.deltaTime;

		if (timeLapsedLastFire > 1) {
			
			timeLapsedLastFire = 0;
			GameObject b = Instantiate (bubble, transform.position + new Vector3 (0, (float)1.8, 0), transform.rotation) as GameObject;
		}
	}
}
