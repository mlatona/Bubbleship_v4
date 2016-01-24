using UnityEngine;
using System.Collections;

namespace Vigilante{
	public class Shooting : IState {

		readonly GameObject stateable;
		FireCommand fireCommand;
		float timeElapsed = 0;
		float lastFire = 0;
		float fireTime = 0.7f;
		float updateRating = 1;

		public Shooting(GameObject stateableParam){
			stateable = stateableParam;
			fireCommand = stateable.GetComponent<FireCommand> ();
			VigilanteEnemy vigilante = stateable.GetComponent<VigilanteEnemy> ();
			Vector3 heading = stateable.transform.position - vigilante.enemyPos;
			float distance = heading.magnitude;
			Vector3 direction = heading / distance;
			vigilante.enemyPos = Vector3.zero;
			direction.x *= -10;
			direction.y *= -4;
			fireCommand.speed = direction;
		}

		#region IState implementation

		public void updateState ()
		{
			if(lastFire>fireTime){
				fireCommand.Run();
				lastFire = 0;
			}
			timeElapsed += Time.deltaTime;
			lastFire += Time.deltaTime;

		}
		public IState changeState ()
		{
			IState newState = null;
			if (timeElapsed > updateRating) {
				
				timeElapsed = 0;
				newState = new Thinking(stateable);
			}
			return newState;
		}

		#endregion



	}
}
