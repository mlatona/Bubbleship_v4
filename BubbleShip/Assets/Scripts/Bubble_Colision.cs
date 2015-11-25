using UnityEngine;
using System.Collections;

public class Bubble_Colision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		Debug.Log (coll.gameObject.name);
	}
}
