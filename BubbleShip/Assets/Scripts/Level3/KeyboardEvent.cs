using UnityEngine;
using System.Collections;

public class KeyboardEvent : MonoBehaviour
{

	public string eventname;
	public string commandOn;
	public string commandOff;
	public float timeBetweenEvents;
	float timeElapsed = 99999;

	// Update is called once per frame
	void Update ()
	{
		timeElapsed += Time.deltaTime;
		if (timeElapsed > timeBetweenEvents) {
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
