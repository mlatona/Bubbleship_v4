using UnityEngine;
using System.Collections;

namespace Torre{
	public class Shooting : IState {

		readonly GameObject stateable;
		FireCommand fireCommand;
		float timeElapsed = 0;
		float lastFire = 0;
		float fireTime = 0.2f;
		float updateRating = 1;

		public Shooting(GameObject stateableParam){
			stateable = stateableParam;
			fireCommand = stateable.GetComponent<FireCommand> ();
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
