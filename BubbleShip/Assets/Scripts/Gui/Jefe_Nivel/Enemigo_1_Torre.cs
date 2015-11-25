using UnityEngine;
using System.Collections;

public class Enemigo_1_Torre : MonoBehaviour {

	public float moveSpeed = 1f;
	public Vector3 direccion = new Vector3(1f,0f,0f);
	

	// Update is called once per frame
	void Update () {
		transform.Translate (direccion*moveSpeed*Time.deltaTime);
	}

}
