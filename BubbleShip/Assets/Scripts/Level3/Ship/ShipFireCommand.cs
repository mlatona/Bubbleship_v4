using UnityEngine;
using System.Collections;

public class ShipFireCommand : MonoBehaviour,ICommand {

	FireCommand fireCommand;

	public void Start(){
		fireCommand = gameObject.GetComponent<FireCommand> ();
	}
	
	public void Run(){
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = 59;
		Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePos);
		worldMousePosition = worldMousePosition - (transform.position + new Vector3(0,1,0));
		worldMousePosition.z = 0;
		fireCommand.speed = worldMousePosition;
		fireCommand.Run ();
	}
}
