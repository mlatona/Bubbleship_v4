using UnityEngine;
using System.Collections;

public class Cambia_Sonido : MonoBehaviour {
	public AudioClip otherClip;
	AudioSource audio;
	
	void Start() {
		audio = GetComponent<AudioSource>();
	}
	
	void Update() {
		if (!audio.isPlaying) {
			audio.clip = otherClip;
			audio.Play();
			Debug.Log("++++++++++"+audio.clip.name);
		}

		Debug.Log("**************"+audio.clip.name);
	}
}