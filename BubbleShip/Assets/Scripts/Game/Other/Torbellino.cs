using UnityEngine;
using System.Collections;

public class Torbellino : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit2D(Collider2D collider){
		IMoveable m = collider.gameObject.GetComponent<IMoveable> ();
		m.SetSpeed (new Vector3(0, m.GetSpeed().y, 0));
		//Debug.Log ("Exit");
	}

	void OnTriggerStay2D(Collider2D collider){
		if (collider.tag != "Player")
			return;
		float dirX = transform.position.x - collider.transform.position.x;
		IMoveable m = collider.gameObject.GetComponent<IMoveable> ();
		if (dirX > 2) {
			m.SetSpeed (new Vector3 ((20 / Mathf.Max (dirX, 1f)), m.GetSpeed ().y, 0));
			//collider.GetComponent<Rigidbody2D>().AddForce(new Vector3 ((1000 / Mathf.Max (dirX, 1f)), m.GetSpeed ().y, 0));
		} else if (dirX < -2) {
			m.SetSpeed (new Vector3 ((20 / Mathf.Min (dirX, -1f)), m.GetSpeed ().y, 0));
		} else {
			m.SetSpeed (new Vector3 (0, m.GetSpeed ().y, 0));
		}
		//Debug.Log ("InSide");
	}
}
