using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemigo_golpeado : MonoBehaviour {

	//public int hp = 3;
	public int nivel_vida_enemigo = 1000;
	public int golpe_normal = 50;
	public int golpe_powerup = 150;
	GameController gameController;
	//public Sprite hpRemoved;

	public GameObject GO_Explosion;
	public AudioClip efecto_sonido_explosion, efecto_sonido_bomba, efecto_sonido_misil, efecto_sonido_all;
	private AudioSource audiosource;

	void Awake (){
		gameController = GameController.Instance ();
		gameObject.AddComponent<AudioSource> ();
		audiosource = gameObject.GetComponent<AudioSource> ();
	}
	// Use this for initialization


	/*
	void OnCollisionEnter2D (Collision2D collider)
	{
		GameObject go = collider.gameObject;
		Debug.Log ("ESTO ES: -- "+ go.name);
*/
		/*
		Bubble scriptBubble = go.GetComponent<Bubble> ();
		
		if (scriptBubble != null && scriptBubble.playerFired) {
			Debug.Log ("OUCH!!!!!");
		}
		*/
	//}

	void OnTriggerEnter2D(Collider2D col){
		GameObject go = col.gameObject;
		Debug.Log ("Enemigo_golpeado:/// Estoy en OnTriggerEnter2D: ");

		//PlayExplosion();
		if (nivel_vida_enemigo > 0) {

			if (go.tag == "NormalBubble") {
				nivel_vida_enemigo = nivel_vida_enemigo - golpe_normal;
				Play_Explosion ();

				//Eliminamos la bola que colisiono
				Bubble scriptBubble = go.GetComponent<Bubble> ();
				gameController.destroy (scriptBubble.gameObject);

				Debug.Log ("Enemigo_golpeado: por " + go.tag + " NIVEL DE VIDA:: " + nivel_vida_enemigo.ToString ());
			}

			if (go.tag == "Powerup_BOMBA") {
				//Cargar Sonido correspondiente
				nivel_vida_enemigo = nivel_vida_enemigo - golpe_powerup;
				Debug.Log ("Enemigo_golpeado: por " + go.tag + " NIVEL DE VIDA:: " + nivel_vida_enemigo.ToString ());
			} else
		
			if (go.tag == "Powerup_MISIL") {
				//Cargar Sonido correspondiente
				nivel_vida_enemigo = nivel_vida_enemigo - golpe_powerup;
				Debug.Log ("Enemigo_golpeado: por " + go.tag + " NIVEL DE VIDA:: " + nivel_vida_enemigo.ToString ());

			} else

			if (go.tag == "Powerup_ALL") {
				//Cargar Sonido correspondiente
				nivel_vida_enemigo = nivel_vida_enemigo - golpe_powerup;
				Debug.Log ("Enemigo_golpeado: por " + go.tag + " NIVEL DE VIDA:: " + nivel_vida_enemigo.ToString ());
			}
		} else
			Destroy (gameObject);

	}// end OnTriggerEnter2D

	///----------------------------------------------------------------------------
	/** Controla la ANIMACION de una EXPLOSION de una Bubble NORMAL
	 *  Autor: Richard
	 */
	void Play_Explosion(){
		Play_Sound_Explosion ();
		GameObject explosion = (GameObject)Instantiate (GO_Explosion);
		explosion.transform.position = transform.position;
	}
	
	/** Reproduce el SONIDO de la EXPLOSION
	 *  Autor: Richard
	 */
	public void Play_Sound_Explosion(){
		audiosource.PlayOneShot (efecto_sonido_explosion);
	}

	///----------------------------------------------------------------------------
	/** Controla la ANIMACION de la BOMBA
	 *  Autor: Richard
	 */
	void Play_BOMBA(){
		Play_Sound_BOMBA ();

		//OJO !!!! Modificar GO_Explosion por el que corresponde
		GameObject explosion = (GameObject)Instantiate (GO_Explosion);
		explosion.transform.position = transform.position;
	}

	/** Reproduce el sonido de la BOMBA
	 *  Autor: Richard
	 */
	public void Play_Sound_BOMBA(){
		audiosource.PlayOneShot (efecto_sonido_bomba);
	}

	///----------------------------------------------------------------------------
	/** Controla la ANIMACION del MISIL
	 *  Autor: Richard
	 */
	void Play_MISIL(){
		Play_Sound_MISIL ();
		
		//OJO !!!! Modificar GO_Explosion por el que corresponde
		GameObject explosion = (GameObject)Instantiate (GO_Explosion);
		explosion.transform.position = transform.position;
	}
	
	/** Reproduce el SONIDO del MISIL
	 *  Autor: Richard
	 */
	public void Play_Sound_MISIL(){
		audiosource.PlayOneShot (efecto_sonido_misil);
	}

	///----------------------------------------------------------------------------
	/** Controla la ANIMACION de ALL
	 *  Autor: Richard
	 */
	void Play_ALL(){
		Play_Sound_ALL ();
		
		//OJO !!!! Modificar GO_Explosion por el que corresponde
		GameObject explosion = (GameObject)Instantiate (GO_Explosion);
		explosion.transform.position = transform.position;
	}
	
	/** Reproduce el SONIDO de ALL
	 *  Autor: Richard
	 */
	public void Play_Sound_ALL(){
		audiosource.PlayOneShot (efecto_sonido_all);
	}
}
