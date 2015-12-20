using UnityEngine;
using System.Collections;

public class HorizontalMoveCommand : MonoBehaviour,ICommand {

	public float adjust;

	public void Run(){
		float inputX = Input.GetAxis ("Horizontal");
		Vector3 actualSpeed = gameObject.GetComponent<IMoveable> ().GetSpeed();
		actualSpeed.x = inputX * adjust;
		gameObject.GetComponent<IMoveable> ().SetSpeed (actualSpeed);
	}

}
