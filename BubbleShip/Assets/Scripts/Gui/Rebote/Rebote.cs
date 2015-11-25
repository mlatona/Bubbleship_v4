using UnityEngine;
using System.Collections;

public class Rebote : MonoBehaviour {

	public float moveSpeed = 10f;
	//public float turnSpeed = 50f;
	public Vector3 direccion = new Vector3(1f,1f,0f);
	public Vector3 direccion_opuesta = new Vector3(1f,1f,0f);

	public GameObject GO_Explosion;
	
	
	void Update ()
	{
		//if(Input.GetKey(KeyCode.UpArrow))
		//transform.Translate(moveSpeed, moveSpeed, 0f);

		//Movimiento_Positivo (0f,0f);
		transform.Translate (direccion*moveSpeed*Time.deltaTime);
		/*
		Debug.Log("POSICION X: " + gameObject.transform.position.x);
		Debug.Log("POSICION Y: " + gameObject.transform.position.y);
		Debug.Log("================================================= " );
		*/
		/*
		if(Input.GetKey(KeyCode.LeftArrow))
			transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
		
		if(Input.GetKey(KeyCode.RightArrow))
			transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
			*/
	}

	// Controla el movimiento positivo en X e Y
	public void Movimiento_Positivo(float coordenada_x, float coordenada_y){
		transform.Translate (coordenada_x+moveSpeed, coordenada_y+moveSpeed, 0f);
	}

	public void Movimiento_Negativo(float coordenada_x, float coordenada_y){
		transform.Translate (coordenada_x-moveSpeed, coordenada_y-moveSpeed, 0f);
	}

	void OnTriggerEnter2D(Collider2D col){
		if((col.tag == "ParedDerechaTAG") || (col.tag == "ParedIzquierdaTAG")){
		//if(col.tag == "ParedDerechaTAG"){
			//PlayExplosion();
			//changeDirection();
			Debug.Log("POSICION X: " + gameObject.transform.position.x);
			Debug.Log("POSICION Y: " + gameObject.transform.position.y);
			cambioDireccion();
			//Destroy(gameObject);
		}
	}

	void changeDirection(){
		float actual_x = gameObject.transform.position.x;
		float actual_y = gameObject.transform.position.y;
		direccion_opuesta = new Vector3 (actual_x*(-1), actual_y, 0f);
		transform.Translate (direccion_opuesta*moveSpeed*Time.deltaTime);
	}

	void cambioDireccion(){
		direccion.x *= -1;
	}
	
	void PlayExplosion(){
		GameObject explosion = (GameObject)Instantiate (GO_Explosion);
		explosion.transform.position = transform.position;
	}
}
