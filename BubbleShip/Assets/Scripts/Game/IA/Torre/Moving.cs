using UnityEngine;
using System.Collections;

namespace Torre{

	public class Moving : IState {

		readonly GameObject stateable;
		float timeElapsed = 0;
		float updateRating = 1;
		Vector3 speed;
		bool fire;

		public Moving(GameObject stateableParam){
			stateable = stateableParam;
			int vel = Random.Range (0, 15);
			int direction = Random.Range (0, 100);
			direction = direction>50?-1:1;
			speed = new Vector3 (vel * direction, 0, 0);
		}



		#region IState implementation
		public void updateState ()
		{
			timeElapsed += Time.deltaTime;
			stateable.GetComponent<IMoveable> ().SetSpeed (speed);
			RaycastHit2D hit = Physics2D.Raycast(stateable.transform.position-new Vector3(0,3,0), -Vector2.up);
			if (hit.collider != null) {
				if(hit.collider.gameObject.tag == "Player"){
					fire = true;
				}
			}
		}
		public IState changeState ()
		{
			IState newState = null;
			if (timeElapsed > updateRating) {
				stateable.GetComponent<IMoveable> ().SetSpeed (Vector3.zero);
				timeElapsed = 0;
				newState = new Thinking(stateable);
			}else if(fire){
				stateable.GetComponent<IMoveable> ().SetSpeed (Vector3.zero);
				newState = new Shooting(stateable);
			}
			return newState;
		}
		#endregion
	}
}