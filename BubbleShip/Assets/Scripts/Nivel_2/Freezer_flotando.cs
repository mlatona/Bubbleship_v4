using UnityEngine;
using System.Collections;

public class Freezer_flotando : MonoBehaviour {

	//public Vector3 direccion = new Vector3 (0f, 1f , 0);

	public Vector2 speed = new Vector2(10,10);
	private Vector2 movement = new Vector2(1,1);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Translate (direccion * Time.deltaTime);
		/*
		float inputX = Input.GetAxis ("Horizontal");
		float inputY = Input.GetAxis ("Vertical");
		*/
		movement = new Vector2(0f, 0.01f);
		transform.Translate(movement);
		/*
		if (Input.GetKeyDown ("space")){
			transform.Translate(Vector3.up * 260 * Time.deltaTime, Space.World);
		}
		*/
	}
	/*
	void FixedUpdate(){
		// 5 - Move the game object
		rigidbody2D.velocity = movement;
		rigidbody2D.velo
		//rigidbody2D.AddForce(movement);
	}
	*/
}
