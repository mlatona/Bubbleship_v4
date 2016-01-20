using UnityEngine;
using System.Collections;

public class HorizontalMoveCommand : MonoBehaviour,ICommand {

	IMoveable moveable;
	public float adjust;

	void Start(){
		moveable = GetComponent<IMoveable> ();
	}

	public void Run(){
		float inputX = Input.GetAxis ("Horizontal");
		Vector3 actualSpeed = moveable.GetSpeed();
		actualSpeed.x = inputX * adjust;
		gameObject.GetComponent<IMoveable> ().SetSpeed (actualSpeed);
	}

}
