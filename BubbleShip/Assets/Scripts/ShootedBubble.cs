using UnityEngine;
using System.Collections;

public class ShootedBubble : MonoBehaviour {

	private Vector3 direction;

	public void SettingDirection(Vector3 direction){
	
		this.direction = direction;
	}

	void OnCollisionEnter2D (Collision2D col){

		Debug.Log ("Sono in collisione");
		Debug.Log (direction.x);

		if (col.gameObject.tag == "RightWall" || col.gameObject.tag == "LeftWall") {

			Debug.Log ("Sono nell'if");

			direction.x *= -1;


		}

	}
}
