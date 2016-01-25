using UnityEngine;
using System.Collections;
using Freezer;

public class FreezerThinking : IState {

	readonly GameObject stateable;
	bool fire;

	public FreezerThinking(GameObject stateableParam){
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
		IState newState = new FreezerMoving(stateable);
		if(fire){
			//[SOUND] estas debajo de freezer
			newState = new FreezerShooting(stateable);
		}
		return newState;
	}

	#endregion



}
