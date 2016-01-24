using UnityEngine;
using System.Collections;
using Freezer;

public class FreezerEnemy : MonoBehaviour {

	Enemy enemyIA;

	// Use this for initialization
	void Start () {
		enemyIA = new Enemy (new FreezerMoving(gameObject));
	}

	void Update(){
		enemyIA.Update ();
	}
}
