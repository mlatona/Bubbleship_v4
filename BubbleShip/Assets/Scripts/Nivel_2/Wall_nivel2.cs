using UnityEngine;
using System.Collections;

public class Wall_nivel2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter2D (Collision2D collider)
	{
		GameObject go = collider.gameObject;
		//Debug.Log ("ESTO ES: -- "+ go.name);

		if (go.tag == "Freezer"){
			Debug.Log ("Wall_nivel2: **** Freezer  ***");
			Freezer scriptFreezer = go.GetComponent<Freezer> ();
			scriptFreezer.direccion.x *= -1;
			//scriptFreezer.tmp.x *= -1;
			Debug.Log ("Wall_nivel2: Freezer cambia de direccion en X");
		}

		Bubble scriptBubble = go.GetComponent<Bubble> ();

		if (scriptBubble != null && scriptBubble.playerFired) {
			scriptBubble.direction.x *= -1;
			Debug.Log("Wall_nivel2: Pared - Bubble choca con pared");
		}
	}
}
