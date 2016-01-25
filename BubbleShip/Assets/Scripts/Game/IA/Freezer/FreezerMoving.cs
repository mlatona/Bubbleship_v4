using UnityEngine;
using System.Collections;

namespace Freezer{

	public class FreezerMoving : IState {

		readonly GameObject stateable;
		float timeElapsed = 0;
		float updateRating = 1;
		Vector3 speed;
		float y=-5;
		float x=-5;
		bool fire;

		public FreezerMoving(GameObject stateableParam){
			stateable = stateableParam;
			x=stateable.GetComponent<IMoveable> ().GetSpeed ().x;
		}



		#region IState implementation
		public void updateState ()
		{
			timeElapsed += Time.deltaTime;

			if (stateable.transform.localPosition.y < 6 && y < 0)
				y = 5;
			else if (stateable.transform.localPosition.y > 13 && y > 0)
				y = -5;
			else if (x == 0)
				x = -5;
			
			if(stateable.transform.localPosition.x<5 && x<0)
				x=5;
			else if(stateable.transform.localPosition.x>30 && x>0)
				x= -10;
			//Debug.Log ("-- "+ x +" --");
			
			stateable.GetComponent<IMoveable> ().SetSpeed (new Vector3(x,y,0));
			//[SOUND] freezer se mueve

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
				//stateable.GetComponent<IMoveable> ().SetSpeed (Vector3.zero);
				timeElapsed = 0;
				newState = new FreezerThinking(stateable);
			}else if(fire){
				stateable.GetComponent<IMoveable> ().SetSpeed (Vector3.zero);
				newState = new FreezerShooting(stateable);
			}
			return newState;
		}
		#endregion
	}
}