using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;


public class Boton_change_sprite : MonoBehaviour {

	public Sprite encendido;
	public Sprite apagado;

	// Use this for initialization
	/*
	void Start () {
	
	}
	*/

	// Update is called once per frame
	void Update () {
		// Check if the left mouse button was clicked
		if(Input.GetMouseButtonDown(0))
		{
			// Check if the mouse was clicked over a UI element
			if(!EventSystem.current.IsPointerOverGameObject())
			{
				Debug.Log("Did not Click on the UI");
			}
		}
	}
}
