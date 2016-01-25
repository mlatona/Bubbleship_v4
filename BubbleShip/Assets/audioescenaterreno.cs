using UnityEngine;
using System.Collections;

public class audioescenaterreno : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.FindGameObjectWithTag ("SoundController").GetComponent<SoundController> ().FinalScene ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
