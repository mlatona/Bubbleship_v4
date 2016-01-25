using UnityEngine;
using System.Collections;

namespace Vigilante{

public class Thinking : IState {

	readonly GameObject stateable;
	readonly VigilanteEnemy vigilante;
	bool fire;

	public Thinking(GameObject stateableParam){
		stateable = stateableParam;
		vigilante = stateable.GetComponent<VigilanteEnemy> ();
		fire = false;
	}

	#region IState implementation

	public void updateState ()
	{
			fire = vigilante.enemyPos != Vector3.zero;
	}

	public IState changeState ()
	{
		if(fire){
				//[SOUND] te ha detectado vigilante
			return new Shooting(stateable);
		}
			return new Moving(stateable);
	}

	#endregion



}
}