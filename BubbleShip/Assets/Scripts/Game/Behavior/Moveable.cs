using UnityEngine;
using System.Collections;

public class Moveable : MonoBehaviour, IMoveable
{

	public Vector3 speed;
	public float limitLeft = 0;
	public float limitRight = 0;

	void Start ()
	{
		//Si los limites son muy pequeños se considera sin limites
		if (limitLeft == 0) {
			limitLeft = float.MinValue;
		}
		if (limitRight == 0) {
			limitRight = float.MaxValue;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 movement = speed * Time.deltaTime;
		if (transform.localPosition.x+movement.x < limitLeft) {
			movement.x = limitLeft - transform.localPosition.x;
			//Debug.Log ("NewLocal: "+transform.localPosition.x+movement.x);
		} else if (transform.localPosition.x+movement.x > limitRight) {
			movement.x = limitRight - transform.localPosition.x;
		}
		transform.Translate (movement);
	}

	public void SetSpeed (Vector3 speedParam)
	{
		speed = speedParam;
	}

	public Vector3 GetSpeed ()
	{
		return speed;
	}
}
