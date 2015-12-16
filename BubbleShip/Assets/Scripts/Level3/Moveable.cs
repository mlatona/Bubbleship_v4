using UnityEngine;
using System.Collections;

public class Moveable : MonoBehaviour, IMoveable {

	public Vector3 speed;
	public bool canMove = true;
	
	// Update is called once per frame
	void Update () {
		Vector3 movement = speed * Time.deltaTime;
		if (canMove) {
			transform.Translate (movement);
			if(transform.localPosition.x < 1){
				float x = 1 - transform.localPosition.x;
				transform.localPosition += new Vector3(x,0,0);
			}else if(transform.localPosition.x > 11){
				float x = transform.localPosition.x - 11;
				transform.localPosition -= new Vector3(x,0,0);
			}
		}
	}

	public void SetSpeed(Vector3 speedParam){speed = speedParam;}
	public Vector3 GetSpeed(){return speed;}
	public void SetCanMove(bool canMoveParam){canMove = canMoveParam;}
}
