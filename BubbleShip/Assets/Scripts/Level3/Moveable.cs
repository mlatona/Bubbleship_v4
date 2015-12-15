using UnityEngine;
using System.Collections;

public class Moveable : MonoBehaviour {

	public Vector3 speed;
	
	// Update is called once per frame
	void Update () {
		Vector3 movement = speed * Time.deltaTime;
		transform.Translate (movement);
	}
}
