using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeText : MonoBehaviour {

	public float maxTimeSeconds;
	public float alertTimeSeconds;
	public string maxTimeNameCommand;
	public string alertNameCommand;
	ICommand maxTimeCommand;
	ICommand alertTimeCommand;
	Text text;
	float timeElapsed;

	// Use this for initialization
	void Start () {
		maxTimeCommand = (ICommand)gameObject.GetComponent (maxTimeNameCommand);
		alertTimeCommand = (ICommand)gameObject.GetComponent (alertNameCommand);
		timeElapsed = 0;
		text = GetComponent<Text> ();
		text.text = "000";
	}
	
	// Update is called once per frame
	void Update () {
		timeElapsed += Time.deltaTime;
		Debug.Log (timeElapsed);
		text.text = string.Format("{0:D3}", Mathf.FloorToInt(timeElapsed));
		if(maxTimeSeconds<timeElapsed){
			if (maxTimeCommand != null) {
				maxTimeCommand.Run ();
			}
		}else if(alertTimeSeconds<timeElapsed){
			if (alertTimeCommand != null) {
				alertTimeCommand.Run ();
			}
		}
	}
}
