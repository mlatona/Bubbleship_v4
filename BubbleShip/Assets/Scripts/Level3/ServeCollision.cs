using UnityEngine;
using System.Collections;

public class ServeCollision : MonoBehaviour
{

	void OnTriggerEnter2D (Collider2D collider)
	{
		AttendCollision (collider);
	}

	void OnTriggerStay2D(Collider2D collider){
		AttendCollision (collider);
	}

	void AttendCollision(Collider2D collider){
		Debug.Log ("ServeCollision yo=" + gameObject.tag +"el="+collider.gameObject.tag);
		ICollisionable collisionable = gameObject.GetComponent<ICollisionable> ();
		if (collisionable != null) {
			switch (collider.gameObject.tag) {
			case "NormalBubble":
				collisionable.CollideWithBubble (collider.gameObject);
				break;
			case "Player":
				collisionable.CollideWithSpaceShip(collider.gameObject);
				break;
			}
		}
	}
}
