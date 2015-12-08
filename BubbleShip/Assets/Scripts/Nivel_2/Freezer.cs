using UnityEngine;
using System.Collections;

public class Freezer : MonoBehaviour {

	//velocidad de movimiento
	//static Vector2 speed = new Vector2(0.8f, 0.5f);
	static float speed = 0.8f; // ok---

	//public Vector3 direccion = new Vector3(1f,1f,0f);
	//Vector3 direccion = new Vector3(0.1f,0f,0f);// ok---

	public Vector3 tmp;
	public Vector3 direccion = new Vector3 (-2f, 0.1f , 0);
	
	// Update is called once per frame
	void Update () {

		/* Movimiento propio del Enemigo Freezer
		 * Inicialmente de izquierda a derecha,
		 * posteriormente sera randomico
		 */
		//tmp = new Vector3 (speed * 2f, 0.1f , 0);
		//movement = tmp * Time.deltaTime;
		//movement = {movement.x * speed; movement.y, movement.z}


		tmp = new Vector3 (speed * -2f, 0.1f , 0);

		direccion = tmp * Time.deltaTime;
		transform.Translate (direccion);

		//direccion = tmp * Time.deltaTime;
		/*
		direccion.x = direccion.x * speed;
		direccion.y = 0.1f;
		direccion.z = 0f;
		transform.Translate (direccion* Time.deltaTime);
		 */

		//transform.Translate (direccion*Time.deltaTime);
		//Debug.Log ("altura***: "+direccion.y);
	}

	/*
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Wall") {
			Debug.Log ("FREEZER colisiona con Pared ----///--- "+ col.gameObject.tag + " ----///-----");
			cambioDireccion();
		}
	}

	void cambioDireccion(){
		direccion.x *= -1;
	}
	*/

	/* Funcion que es llamada cuando ocurre
	 * una colision entre una Pared y Freezer
	 */

	void OnCollisionEnter2D (Collision2D col){
		Debug.Log ("Estoy en OnCollisionEnter2D" + col.gameObject.name);
		handleCollision (col);
		//direccion.x *= -1;
		//cambioDireccion();
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



	/*
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Wall") {
			cambioDireccion();
		}
	}
	*/

	void cambioDireccion(){
		direccion.x *= -1;
	}

}
