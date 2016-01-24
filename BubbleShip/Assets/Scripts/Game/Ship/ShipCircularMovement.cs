using UnityEngine;
using System.Collections;

public class ShipCircularMovement : MonoBehaviour {

	float contador;
	float speed = 1f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//contador += Time.deltaTime * speed;
		contador += Time.deltaTime;

		transform.Translate(0,0,speed); 
		transform.Rotate(0,speed,0);
		//transform.Translate(x,y,z);

	}
}
