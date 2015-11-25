using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PlaySound : MonoBehaviour {

	public AudioClip efecto_sonido;

	public void OnPointerEnter(BaseEventData data) { AudioSource.PlayClipAtPoint(efecto_sonido, new Vector3(0,0,0)); }
	

}
