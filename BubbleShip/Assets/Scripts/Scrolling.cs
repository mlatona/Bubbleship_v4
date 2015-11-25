using UnityEngine;
using System.Collections;

public class Scrolling : MonoBehaviour {

	//velocidad
	public Vector2 speed = new Vector2(2, 2);
	//direccion
	public Vector2 direction = new Vector2(-1, 0);
	//enlace a la camara
	public bool isLinkedToCamera = false;

	// Update is called once per frame
	void Update () {
	
		//Calculamos movimiento
		Vector3 movement = new Vector3(speed.x * direction.x, speed.y * direction.y, 0);
		
		movement *= Time.deltaTime;
		transform.Translate(movement);
		
		//Movemos la camara
		if (isLinkedToCamera){
			Camera.main.transform.Translate(movement);
		}
	}
}
