using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour {

	public int hp = 3;
	GameController gameController;
	public Sprite hpRemoved;

	void Awake ()
	{
		gameController = GameController.Instance ();
	}


	// Methods called when there is a collision between the wall and the spaceship
	void OnCollisionEnter2D (Collision2D col){
		handleCollision (col);
	}

	void OnCollisionStay2D(Collision2D col){
		handleCollision (col);
	}

	void handleCollision(Collision2D col){

		Debug.Log (col.gameObject.name);
	
		if (col.gameObject.name == "RightWall" || col.gameObject.name == "LeftWall") {

			return;

		} else {

			Bubble bubble = col.gameObject.GetComponent<Bubble>();
			
			
			if (bubble.playerFired) {
				return;
			}
			
			Debug.Log ("collision");
			Debug.Log ("Bubble Damage: " + bubble.damage);
			
			hp -= bubble.damage;
			
			Debug.Log ("Lifes left: " + hp);
			
			//Destroy (bubble.gameObject);
			gameController.destroy (bubble.gameObject);
			
			if (hp == 2) {
				Debug.Log ("hp==2");
				GameObject.FindGameObjectWithTag ("HP1").GetComponent<Image> ().sprite = hpRemoved;
				//Destroy(GameObject.FindGameObjectWithTag("HP1"));
			}
			
			if (hp == 1) {
				Debug.Log ("hp==1");
				GameObject.FindGameObjectWithTag ("HP2").GetComponent<Image> ().sprite = hpRemoved;
				//Destroy(GameObject.FindGameObjectWithTag("HP2"));
			}
			
			if (hp <= 0) {
				Debug.Log ("hp==0");
				GameObject.FindGameObjectWithTag ("HP3").GetComponent<Image> ().sprite = hpRemoved;
				//Destroy(GameObject.FindGameObjectWithTag("HP3"));
				Destroy (gameObject);
			}
		}
	}
}
