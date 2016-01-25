using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {

	public AudioClip bubbleMismoColor;
	public AudioClip bubbleDistintoColor;
	public AudioClip bubbleExplotaEnemigo;
	public AudioClip bubbleDisparadaShip;
	public AudioClip explosion1seg;
	public AudioClip explosion3seg;
	public AudioClip gameOver;
	public AudioClip gameWin;
	public AudioClip bethoven;

	AudioSource audioSource;
	AudioSource soundTrack;


	// Use this for initialization
	void Start () {
		audioSource = gameObject.GetComponent<AudioSource> ();
		audioSource.volume = GameController.Instance ().GetVolumeEffects ();
	}
	
	public void PlayBubbleMismoColor(){
		audioSource.PlayOneShot (bubbleMismoColor);
	}

	public void PlayBubbleDisparadaShip(){
		audioSource.PlayOneShot (bubbleDisparadaShip);
	}

	public void PlayBubbleDistintoColor(){
		audioSource.PlayOneShot (bubbleDistintoColor);
	}

	public void PlayGameOver(){
		audioSource.PlayOneShot (gameOver);
	}

	public void FinalScene(){
		audioSource.PlayOneShot (gameWin);
	}

	public void PlaySoundTrack(){
		audioSource.PlayOneShot (bethoven);
	}

	public void Stop(){
		audioSource.Stop ();
	}
}
