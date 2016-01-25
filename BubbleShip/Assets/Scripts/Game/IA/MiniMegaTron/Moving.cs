using UnityEngine;
using System.Collections;
using MegaTron;

namespace MiniMegaTron{

	public class Moving : IState {

		readonly GameObject stateable;
		readonly MiniMegaTronEnemy miniMegaTron;
		float timeElapsed = 0;
		float updateRating = 0.3f;
		Vector3 speed;
		Vector3 direction;

		public Moving(GameObject stateableParam){
			stateable = stateableParam;
			miniMegaTron = stateable.GetComponent<MiniMegaTronEnemy> ();
			Vector3 heading = stateable.transform.localPosition - miniMegaTron.enemyPos;
			float distance = heading.magnitude;
			direction = heading / distance;
			direction = -direction;
			direction.x *= 10;
			direction.y *= 4;
			if (direction.y > 0)
				stateable.GetComponent<Killable> ().Kill ();
		}



		#region IState implementation
		public void updateState ()
		{
			timeElapsed += Time.deltaTime;
			stateable.GetComponent<IMoveable> ().SetSpeed (direction);
			//[SOUND] se mueve minimegatron
		}
		public IState changeState ()
		{
			IState newState = null;
			if (timeElapsed > updateRating) {
				stateable.GetComponent<IMoveable> ().SetSpeed (Vector3.zero);
				timeElapsed = 0;
				newState = new Thinking(stateable);
			}
			return newState;
		}
		#endregion
	}
}