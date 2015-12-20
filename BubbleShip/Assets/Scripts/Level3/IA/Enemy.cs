using UnityEngine;
using System.Collections;

public class Enemy {
	
	public IState state;

	public Enemy(IState stateParam){
		state = stateParam;
	}
	
	// Update is called once per frame
	public void Update () {
		state.updateState ();
		IState newState = state.changeState ();
		state =  newState == null ? state : newState;
	}
}
