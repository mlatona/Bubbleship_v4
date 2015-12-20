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
		transform.Translate (movement);
		if (transform.localPosition.x < limitLeft) {
			float x = 1 - transform.localPosition.x;
			transform.localPosition += new Vector3 (x, 0, 0);
		} else if (transform.localPosition.x > limitRight) {
			float x = transform.localPosition.x - 11;
			transform.localPosition -= new Vector3 (x, 0, 0);
		}
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
