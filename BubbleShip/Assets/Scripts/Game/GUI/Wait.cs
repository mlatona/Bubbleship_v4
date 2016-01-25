using UnityEngine;
using System.Collections;

public class Wait : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		Debug.Log ("ddd");
	}
	
	// Update is called once per frame
	void Update () {
		Invoke ("Destroy", 3);
	}
	private void Destroy(){
		Debug.Log ("aaa");

		//SceneManager.LoadScene (1);
		Application.LoadLevel (1);
			
	}
}
