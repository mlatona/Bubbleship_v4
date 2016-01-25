using UnityEngine;
using System.Collections;

namespace Torre{
public class Thinking : IState {

	readonly GameObject stateable;
	bool fire;

	public Thinking(GameObject stateableParam){
		stateable = stateableParam;
		fire = false;
	}

	#region IState implementation

	public void updateState ()
	{
		Debug.Log ("-O-");
		RaycastHit2D hit = Physics2D.Raycast(stateable.transform.position-new Vector3(0,6,0), -Vector2.up);
		if (hit.collider != null) {
			if(hit.collider.gameObject.tag == "Player"){
				fire = true;
			}
		}
	}

	public IState changeState ()
	{
		IState newState = new Moving(stateable);
		if(fire){
				//[SOUND] estas debajo de megatron
			newState = new Shooting(stateable);
		}
		return newState;
	}

	#endregion



}
}