using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D collider)
	{
		Bubble scriptBubble = collider.gameObject.GetComponent<Bubble> ();
		if (scriptBubble != null && scriptBubble.playerFired) {
			scriptBubble.direction.x *= -1;
			Debug.Log("Pared - Bubble choca con pared");
		}
	}
}
