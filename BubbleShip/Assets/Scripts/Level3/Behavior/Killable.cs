using UnityEngine;
using System.Collections;

public class Killable : MonoBehaviour, IKillable {

	public string callbackStr;
	ICommand callback;

	void Start(){
		if (callbackStr != null) {
			callback = (ICommand)GetComponent(callbackStr);
		}
	}

	public void Kill(){
		//kill
		Destroy (gameObject);
		if(callback != null){
			Debug.Log("Killed "+gameObject.tag);
			((ICommand)callback).Run();
		}
	}

}
