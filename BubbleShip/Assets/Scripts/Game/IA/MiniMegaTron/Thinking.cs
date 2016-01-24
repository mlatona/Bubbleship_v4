using UnityEngine;
using System.Collections;

namespace MiniMegaTron{

public class Thinking : IState {

	readonly GameObject stateable;
	readonly MiniMegaTronEnemy miniMegaTron;
	bool fire;

	public Thinking(GameObject stateableParam){
		stateable = stateableParam;
		miniMegaTron = stateable.GetComponent<MiniMegaTronEnemy> ();
		fire = false;
	}

	#region IState implementation

	public void updateState ()
	{
			fire = miniMegaTron.enemyPos != Vector3.zero;
	}

	public IState changeState ()
	{
		if(fire){
			return new Moving(stateable);
		}
		return this;
	}

	#endregion



}
}