using UnityEngine;
using System.Collections;
using Torre;


public class TorreEnemy : MonoBehaviour {

	Enemy enemyIA;

	// Use this for initialization
	void Start () {
		enemyIA = new Enemy (new Moving(gameObject));
	}

	void Update(){
		enemyIA.Update ();
	}
}

