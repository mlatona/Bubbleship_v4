using UnityEngine;
using System.Collections;

public class Freezer : MonoBehaviour {

	//velocidad de movimiento
	//static Vector2 speed = new Vector2(0.8f, 0.5f);
	static float speed = 2f; // ok---


	//public Vector3 tmp;
	public Vector3 direccion = new Vector3 (speed, 0.1f , 0);
	
	// Update is called once per frame
	void Update () {

		/* Movimiento propio del Enemigo Freezer
		 * Inicialmente de izquierda a derecha,
		 * posteriormente sera randomico
		 */
		transform.Translate (direccion * Time.deltaTime);

	}

	/* Funcion que es llamada cuando ocurre
	 * una colision entre una Pared y Freezer
	 */
	/*
	void OnCollisionEnter2D (Collision2D col){
		Debug.Log ("Estoy en OnCollisionEnter2D" + col.gameObject.name);
		handleCollision (col);
		//direccion.x *= -1;
		//Debug.Log ("--CAMBIAMOS DIRECCION --");
	}

	void handleCollision(Collision2D col){
		Debug.Log ("Estoy en handleCollision: " + col.gameObject.name);
		
		if (col.gameObject.tag == "Wall") {
			Debug.Log ("FREEZER colisiona con Pared ----///--- "+ col.gameObject.tag + " ----///-----");
			//cambioDireccion();
			return;
		} // end if for collision with wall detection
	}
	*/
}
