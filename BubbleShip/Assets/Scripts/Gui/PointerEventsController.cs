using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PointerEventsController : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler {
	
	public int mouseOnCount = 0;
	public AudioClip audioclip;
	private AudioSource audiosource;
	public GameObject spaceship;
	
	public void Start(){
		//audioclip = Resources.Load <AudioClip> ("button_hover_sound");
		gameObject.AddComponent<AudioSource> ();
		audiosource = gameObject.GetComponent<AudioSource> ();
	}
	
	public void OnPointerEnter(PointerEventData eventData)
	{
		/*Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(transform.position);
		float temp  = worldMousePosition.y;
		if(spaceship!=null)
		spaceship.transform.position 
			= new Vector3(spaceship.transform.position.x,temp,spaceship.transform.position.z);*/
		mouseOnCount = mouseOnCount+1;
		Debug.Log(mouseOnCount);
		audiosource.PlayOneShot (audioclip);
	}
	public void OnPointerExit(PointerEventData eventData)
	{
		
	}
	
}