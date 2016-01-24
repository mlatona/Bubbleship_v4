using UnityEngine;
using System.Collections;
using Vigilante;

public class VigilanteEnemy : MonoBehaviour {

	Enemy enemyIA;
	public Vector3 rotationSpeed;
	public float maxAngle;
	public float minAngle;
	[HideInInspector] public Vector3 enemyPos;

	// Use this for initialization
	void Start () {
		enemyIA = new Enemy (new Thinking(gameObject));
		enemyPos = Vector3.zero;
	}

	void Update(){
		if(!GameController.Instance().paused)
		enemyIA.Update ();
	}


}
