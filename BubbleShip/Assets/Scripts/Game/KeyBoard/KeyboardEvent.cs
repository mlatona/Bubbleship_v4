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
	ICommand scCommandOn;
	ICommand scCommandOff;

	void Start(){
		scCommandOn = (ICommand)gameObject.GetComponent (commandOn);
		scCommandOff = (ICommand)gameObject.GetComponent (commandOff); 
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
				if (scCommandOn != null) {
					scCommandOn.Run ();
				}
				timeElapsed = 0;
			} else {
				if (scCommandOff != null) {
					scCommandOff.Run ();
				}
			}
		}
	}
}
