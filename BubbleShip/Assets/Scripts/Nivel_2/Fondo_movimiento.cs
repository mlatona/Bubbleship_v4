using UnityEngine;
using System.Collections;

public class Fondo_movimiento : MonoBehaviour {

	public float velocidad = 0.005f;
	//public Vector2 velocidad = new Vector2(0f, 0.005f);// = new Vector2(1,1);
	private Vector2 movimiento;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		movimiento = new Vector2(0f, velocidad);
		transform.Translate(movimiento);
	}
}
