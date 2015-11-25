using UnityEngine;
using System.Collections;

public class meteorito_1Controller : MonoBehaviour {

	public float gradosps = 72.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Rotate(new Vector3(0.0f,5*Time.deltaTime, 0.0f));
		transform.Rotate (Vector3.forward * -1);
	}
}
