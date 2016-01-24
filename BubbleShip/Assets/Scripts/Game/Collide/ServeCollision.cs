using UnityEngine;
using System.Collections;

public class ServeCollision : MonoBehaviour
{
	public string[] tagObject;
	public string[] scriptName;
	Hashtable tagCommand;

	void Start(){
		tagCommand = new Hashtable ();
		if(tagObject.Length != scriptName.Length){
			Debug.Log("ServerCollision: Deben tener las mismas dimensiones");
		}
		for(int i=0;i<tagObject.Length;i++){
			tagCommand.Add(tagObject[i], scriptName[i]);
		}
	}


	void OnTriggerEnter2D (Collider2D collider)
	{
		AttendCollision (collider);
	}

	void OnTriggerStay2D(Collider2D collider){
		AttendCollision (collider);
	}

	void AttendCollision (Collider2D collider)
	{
		string objICollide = (string)tagCommand [collider.gameObject.tag];
		if(objICollide != null){
			Debug.Log ("ServeCollision yo=" + gameObject.tag + " el=" + collider.gameObject.tag);
			Object objCommand = gameObject.GetComponent(objICollide);
			if(objCommand is ICollideCommand)
				((ICollideCommand)objCommand).Set(collider);
			((ICommand)objCommand).Run();
			}
	}
}
