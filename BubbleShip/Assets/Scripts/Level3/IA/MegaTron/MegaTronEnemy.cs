using UnityEngine;
using System.Collections;
using MegaTron;

public class MegaTronEnemy : MonoBehaviour {

	Enemy enemyIA;

	// Use this for initialization
	void Start () {
		enemyIA = new Enemy (new Moving(gameObject));
	}

	void Update(){
		enemyIA.Update ();
	}
}
