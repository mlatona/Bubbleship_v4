using UnityEngine;
using System.Collections;
using Vigilante;

namespace Vigilante{

	public class Moving : IState {

		readonly GameObject stateable;
		readonly VigilanteEnemy vigilante;
		float timeElapsed = 0;
		float updateRating = 0.3f;

		public Moving(GameObject stateableParam){
			stateable = stateableParam;
			vigilante = stateable.GetComponent<VigilanteEnemy> ();
		}



		#region IState implementation
		public void updateState ()
		{
			//Debug.Log (vigilante.rotationSpeed.z +"_"+stateable.transform.rotation.eulerAngles.z);

			if ((stateable.transform.rotation.eulerAngles.z > vigilante.maxAngle && vigilante.rotationSpeed.z > 0)
				|| (stateable.transform.rotation.eulerAngles.z < vigilante.minAngle && vigilante.rotationSpeed.z < 0)) {
				vigilante.rotationSpeed = -vigilante.rotationSpeed;
			} 
			timeElapsed += Time.deltaTime;
			stateable.transform.Rotate (vigilante.rotationSpeed*timeElapsed);
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