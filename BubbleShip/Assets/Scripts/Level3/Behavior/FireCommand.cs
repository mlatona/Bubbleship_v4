using UnityEngine;
using System.Collections;

public class FireCommand : MonoBehaviour, ICommand {

	public Vector3 speed;
	public Vector3 added;
	public GameObject objectFire;

	public void Run(){
		GameObject b = 
			Instantiate(objectFire, transform.position + added, transform.rotation) as GameObject;
		b.transform.parent = gameObject.transform.parent;
		b.GetComponent<IMoveable> ().SetSpeed (speed);
		b.GetComponent<IOwner> ().Set (gameObject);
	}
}
