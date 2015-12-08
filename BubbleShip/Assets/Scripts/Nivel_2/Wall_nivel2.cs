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
		Debug.Log ("ESTO ES: -- "+ go.name);

		if (go.tag == "Freezer"){
			Debug.Log ("**** Freezer  ***");
			Freezer scriptFreezer = go.GetComponent<Freezer> ();
			scriptFreezer.direccion.x *= -1;
			scriptFreezer.tmp.x *= -1;
			Debug.Log ("Freezer cambia de direccion en X");
		}

		Bubble scriptBubble = go.GetComponent<Bubble> ();

		if (scriptBubble != null && scriptBubble.playerFired) {
			scriptBubble.direction.x *= -1;
			Debug.Log("Pared - Bubble choca con pared");
		}
		/*
		if(collider.gameObject.GetComponent<Bubble> () != null){
			Bubble scriptBubble = collider.gameObject.GetComponent<Bubble> ();
			if (scriptBubble != null && scriptBubble.playerFired) {
				scriptBubble.direction.x *= -1;
				Debug.Log("Pared - Bubble choca con pared");
			}
		}
		*/

		/*
		else
		if(){

		}
		*/

		/*
		Bubble scriptBubble = collider.gameObject.GetComponent<Bubble> ();
		if (scriptBubble != null && scriptBubble.playerFired) {
			scriptBubble.direction.x *= -1;
			Debug.Log("Pared - Bubble choca con pared");
		}
		*/

	}
}
