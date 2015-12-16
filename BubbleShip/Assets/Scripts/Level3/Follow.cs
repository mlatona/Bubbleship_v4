using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {

	GameObject followObject;
	IMoveable moveable;
	public string followTag;

	void Start(){
		followObject = GameObject.FindGameObjectWithTag (followTag);
		moveable = followObject.GetComponent<IMoveable> ();
	}
	
	// Update is called once per frame
	void Update () {
		float tmp = followObject.transform.position.y;
		gameObject.transform.position = new Vector3(gameObject.transform.position.x,tmp,gameObject.transform.position.z);
	}
}
