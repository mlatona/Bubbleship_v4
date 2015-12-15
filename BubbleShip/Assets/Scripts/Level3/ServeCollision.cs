using UnityEngine;
using System.Collections;

public class ServeCollision : MonoBehaviour
{

	void OnTriggerEnter2D (Collider2D collider)
	{
		Debug.Log ("ServeCollision " + gameObject.tag);
		ICollisionable collisionable = gameObject.GetComponent<ICollisionable> ();
		if (collisionable != null) {
			switch (gameObject.tag) {
			case "NormalBubble":
				collisionable.CollideWithBubble (collider.gameObject);
				break;
			}
		}
	}
}
