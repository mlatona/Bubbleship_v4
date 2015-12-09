using UnityEngine;
using System.Collections;

public class BossLevel1 : MonoBehaviour {

	// Boss speed
	public Vector2 speed = new Vector2(0, 0);
	
	public Vector3 movement;

	// Use this for initialization
	void Start () {

		speed.x = 4;

	}
	
	// Update is called once per frame
	void Update () {

		// Boss direction
		Vector3 tmp = new Vector3 (speed.x, 0, 0);
		
		// Boss movement vector
		movement = tmp * Time.deltaTime;

		// Translation 
		transform.Translate (movement);

	
	}

	void OnCollisionEnter2D(Collision2D col){
		Debug.Log ("Collision detected");

		if (col.gameObject.tag == "Wall") {
			Debug.Log ("Collision boss-wall detected");
		
			speed.x *= -1;

		}

	}

}
