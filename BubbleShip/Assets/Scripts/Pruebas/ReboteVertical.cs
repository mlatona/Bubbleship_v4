using UnityEngine;
using System.Collections;

public class ReboteVertical : MonoBehaviour {
	
	public int direction = 1;
	public float velocidadY = 0.01f;

	void Update(){

		transform.Translate(0,direction*velocidadY,0);

		if (transform.position.y > 2) {
			direction = -1;
		}

		if (transform.position.y < -1) {
			direction = 1;
		}
	}
}
