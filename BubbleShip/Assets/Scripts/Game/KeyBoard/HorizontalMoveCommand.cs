using UnityEngine;
using System.Collections;

public class HorizontalMoveCommand : MonoBehaviour,ICommand {

	IMoveable moveable;
	public float adjust;

	void Start(){
		moveable = GetComponent<IMoveable> ();
	}

	public void Run(){
		if(tag=="Player"){
			//[SOUND] Se mueve el player derecha izquierda		
		}
		float inputX = Input.GetAxis ("Horizontal");
		Vector3 actualSpeed = moveable.GetSpeed();
		actualSpeed.x = inputX * adjust;
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2(actualSpeed.x, 0);
	}

}
