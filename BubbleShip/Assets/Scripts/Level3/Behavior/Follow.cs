using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {

	GameObject followObject;
	public string followTag;
	public float decrementoCamara;
	//private float tmp;

	void Start(){
		followObject = GameObject.FindGameObjectWithTag (followTag);
		//tmp = followObject.transform.position.y - decrementoCamara;
	}
	
	// Update is called once per frame
	void Update () {
		if(!isDestroyed(followObject.gameObject)){
			float tmp = followObject.transform.position.y - decrementoCamara;
			gameObject.transform.position = new Vector3(gameObject.transform.position.x,tmp,gameObject.transform.position.z);
		}
	}

	bool isDestroyed(GameObject gameObjectParam){
		return gameObjectParam == null && !ReferenceEquals (gameObjectParam, null);
	}
}
