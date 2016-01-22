using UnityEngine;
using System.Collections;

public class VerticalSpeedCommand : MonoBehaviour, ICommand {

	IMoveable moveable;
	public float maxSpeed;
	public float minSpeed;
	public float adjust;

	// Use this for initialization
	void Start () {
		moveable = GetComponent<IMoveable>();
	}
	
	// Update is called once per frame
	public void Run () {
		float inputY = Input.GetAxis ("Vertical");
		Vector3 actualSpeed = moveable.GetSpeed();
		actualSpeed.y += inputY * adjust;
		if (actualSpeed.y < minSpeed) {
			actualSpeed.y = minSpeed;
		}else if(actualSpeed.y > maxSpeed){
			actualSpeed.y = maxSpeed;
		}
		gameObject.GetComponent<IMoveable> ().SetSpeed (actualSpeed);
	}
}
