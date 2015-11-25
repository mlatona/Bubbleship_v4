using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Botones_sprite : MonoBehaviour {

	//public Sprite a;
	public Sprite encendido;
	public Sprite apagado;
	private Image spriteRenderer; 

	// Use this for initialization

	void Start () {
		spriteRenderer = GetComponent<Image>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
    	if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
			spriteRenderer.sprite = encendido; // set the sprite to sprite1
	}

	// Update is called once per frame
	/*
	void Update () {
		GetComponent<SpriteRenderer>().sprite;
	}
	*/

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space)) // If the space bar is pushed down
		{
			ChangeTheDamnSprite (); // call method to change sprite
		}
	}

	void ChangeTheDamnSprite ()
	{
		if (spriteRenderer.sprite == apagado) // if the spriteRenderer sprite = sprite1 then change to sprite2
		{
			spriteRenderer.sprite = encendido;
		}
		else
		{
			spriteRenderer.sprite = apagado; // otherwise change it back to sprite1
		}
	}
}
