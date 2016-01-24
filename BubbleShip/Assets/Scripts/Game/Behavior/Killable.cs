using UnityEngine;
using System.Collections;

public class Killable : MonoBehaviour, IKillable {

	public string callbackStr;
	ICommand callback;
	IScoreable scorable;
	public float killTimeOutSeconds;
	Collider2D col;

	void Start(){
		//Debug.Log ("Killable: "+killTimeOutSeconds);
		col = GetComponent<Collider2D> ();
		scorable = GetComponent<IScoreable>();
		if (callbackStr != null) {
			callback = (ICommand)GetComponent(callbackStr);
		}
	}

	public void Kill(){
		if(callback != null){
			callback.Run();
		}
		if (scorable != null) {
			scorable.Score();
		}
		col.enabled = false;
		//kill
		Invoke ("Destroy", killTimeOutSeconds);
	}

	private void Destroy(){
		//Debug.Log("Killable "+gameObject.tag);
		Destroy (gameObject);
	}

}
