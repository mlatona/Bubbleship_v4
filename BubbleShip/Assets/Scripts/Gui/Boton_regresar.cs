using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Boton_regresar : MonoBehaviour {

	// Use this for initialization
	public Sprite encendido_1;
	public Sprite apagado_2;
	private Image spriteRenderer; 
	
	// Use this for initialization
	
	void Start () {
		spriteRenderer = GetComponent<Image>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
		if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
			spriteRenderer.sprite = encendido_1; // set the sprite to sprite1
	}

	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Tab)) // If the space bar is pushed down
		{
			ChangeTheDamnSprite (); // call method to change sprite
		}
	}
	
	void ChangeTheDamnSprite ()
	{
		if (spriteRenderer.sprite == apagado_2) // if the spriteRenderer sprite = sprite1 then change to sprite2
		{
			spriteRenderer.sprite = encendido_1;
		}
		else
		{
			spriteRenderer.sprite = apagado_2; // otherwise change it back to sprite1
		}
	}
}
