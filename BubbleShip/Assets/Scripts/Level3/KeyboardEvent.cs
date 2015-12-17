using UnityEngine;
using System.Collections;

public class KeyboardEvent : MonoBehaviour
{

	public string eventname;
	public string commandOn;
	public string commandOff;
	public float timeBetweenEvents;
	public bool preventPauseEffect = false;
	float timeElapsed = 99999;
	float threshold = 0.1f;

	void Start(){
		if (!preventPauseEffect) {
			threshold = 0;
		}
	}

	// Update is called once per frame
	void Update ()
	{
		timeElapsed += Time.deltaTime + threshold;
		if (timeElapsed >= timeBetweenEvents) {
			if (Input.GetButton (eventname)) {
				ICommand command = (ICommand)gameObject.GetComponent (commandOn);
				if (command != null) {
					command.Run ();
				}
				timeElapsed = 0;
			} else {
				ICommand command = (ICommand)gameObject.GetComponent (commandOff);
				if (command != null) {
					command.Run ();
				}
			}
		}
	}
}
