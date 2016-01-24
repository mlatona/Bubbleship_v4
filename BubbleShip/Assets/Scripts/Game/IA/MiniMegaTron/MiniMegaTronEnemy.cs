using UnityEngine;
using System.Collections;
using MiniMegaTron;

public class MiniMegaTronEnemy : MonoBehaviour {

	Enemy enemyIA;
	[HideInInspector] public Vector3 enemyPos;

	// Use this for initialization
	void Start () {
		enemyIA = new Enemy (new Thinking(gameObject));
		enemyPos = Vector3.zero;
	}

	void Update(){
		enemyIA.Update ();
	}


}
