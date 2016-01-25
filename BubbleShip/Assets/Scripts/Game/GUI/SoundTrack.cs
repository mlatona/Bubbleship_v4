using UnityEngine;
using System.Collections;

public class SoundTrack : MonoBehaviour {

	bool oneTime = true;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (oneTime) {
			GameObject.FindGameObjectWithTag ("SoundController").GetComponent<SoundController> ().PlaySoundTrack ();
			oneTime=false;
		}
	}
}
