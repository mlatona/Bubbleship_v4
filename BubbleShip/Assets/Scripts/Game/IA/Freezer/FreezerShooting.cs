using UnityEngine;
using System.Collections;

namespace Freezer{
	public class FreezerShooting : IState {

		readonly GameObject stateable;
		FireCommand fireCommand;
		float timeElapsed = 0;
		float lastFire = 0;
		float fireTime = 0.2f;
		float updateRating = 1;

		public FreezerShooting(GameObject stateableParam){
			stateable = stateableParam;
			fireCommand = stateable.GetComponent<FireCommand> ();
		}

		#region IState implementation

		public void updateState ()
		{
			if(lastFire>fireTime){
				fireCommand.Run();
				//[SOUND] freezer dispara
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
				newState = new FreezerThinking(stateable);
			}
			return newState;
		}

		#endregion



	}
}
