using UnityEngine;
using System.Collections;

public class ReboteVertical : MonoBehaviour {
	
	int direction = 1;

	void Update(){

		transform.Translate(0,direction*0.01f,0);

		if (transform.position.y > 2) {
			direction = -1;
		}

		if (transform.position.y < -1) {
			direction = 1;
		}
	}
}
