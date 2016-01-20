using UnityEngine;
using System.Collections;

public class VerticalSpeedCommand : MonoBehaviour, ICommand {

	IMoveable moveable;
	float baseSpeed;
	public float maxSpeed;
	public float adjust;

	// Use this for initialization
	void Start () {
		moveable = GetComponent<IMoveable>();
		baseSpeed = moveable.GetSpeed().y;
	}
	
	// Update is called once per frame
	public void Run () {
		float inputY = Input.GetAxis ("Vertical");
		Vector3 actualSpeed = moveable.GetSpeed();
		actualSpeed.y += inputY * adjust;
		if (actualSpeed.y < baseSpeed) {
			actualSpeed.y = baseSpeed;
		}else if(actualSpeed.y > maxSpeed){
			actualSpeed.y = maxSpeed;
		}
		gameObject.GetComponent<IMoveable> ().SetSpeed (actualSpeed);
	}
}
