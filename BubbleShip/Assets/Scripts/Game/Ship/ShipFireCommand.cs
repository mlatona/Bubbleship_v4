using UnityEngine;
using System.Collections;

public class ShipFireCommand : MonoBehaviour,ICommand {

	FireCommand fireCommand;
	GameController gameController;
	BubbleObj actualBubble;
	BubbleObj nextBubble;
	BubbleObj objectFire;

	public void Start(){
		fireCommand = gameObject.GetComponent<FireCommand> ();
		objectFire = fireCommand.objectFire.GetComponent<BubbleObj>();
		gameController = GameController.Instance ();
		actualBubble = GameObject.FindGameObjectWithTag ("ActualBubble").GetComponent<BubbleObj>();
		nextBubble = GameObject.FindGameObjectWithTag ("NextBubble").GetComponent<BubbleObj>();
		actualBubble.bubbleColor = Enums.getRandomBubbleColor ();
		nextBubble.bubbleColor = Enums.getRandomBubbleColor ();
	}
	
	public void Run(){
		if (gameController.paused || Input.GetButton("Fire2")) {
			return;
		}
		//Vector3 mousePos = Input.mousePosition;
		//mousePos.z = 59;
		//Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePos);
		//worldMousePosition = worldMousePosition - (transform.position + new Vector3(0,1,0));
		//worldMousePosition.z = 0;
		//fireCommand.speed = fireCommand.speed;
		objectFire.bubbleColor = actualBubble.bubbleColor;
		actualBubble.bubbleColor = nextBubble.bubbleColor;
		nextBubble.bubbleColor = Enums.getRandomBubbleColor ();
		GameObject.FindGameObjectWithTag ("SoundController").GetComponent<SoundController> ().PlayBubbleDisparadaShip ();
		fireCommand.Run ();
	}
}
