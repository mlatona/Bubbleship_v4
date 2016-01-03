using UnityEngine;
using System.Collections;

public class nave_1 : MonoBehaviour {

	public Vector2 speed = new Vector2(1f, 0f);

	public GameObject GO_Explosion;
	
	void Update ()
	{
		//Get our raw inputs
		float x = Input.GetAxisRaw ("Horizontal");
		float y = Input.GetAxisRaw ("Vertical");
		//Normalize the inputs
		Vector2 direction = new Vector2 (x, y).normalized;
		//Move the player
		Move (direction);
	}
	
	void Move (Vector2 direction)
	{
		float inputX = Input.GetAxis ("Horizontal");
		//float inputY = Input.GetAxis ("Vertical");
		
		Vector3 tmp = new Vector3 (speed.x * inputX *100, speed.y , 0);
		
		Vector3 movement = tmp * Time.deltaTime;
		transform.Translate (movement);
		//PlayExplosion();
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "EsferaTAG"){
			PlayExplosion();
			Destroy(gameObject);
		}
	}

	void PlayExplosion(){
		GameObject explosion = (GameObject)Instantiate (GO_Explosion);
		explosion.transform.position = transform.position;
	}
}
