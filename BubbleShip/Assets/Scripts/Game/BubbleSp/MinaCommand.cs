using UnityEngine;
using System.Collections;
using System.Linq;

public class MinaCommand : MonoBehaviour, ICollideCommand {

	Collider2D collider2d;
	public float killTimeOutSeconds;

	#region ICommand implementation

	public void Run ()
	{
		//Si tiene dueño
		if(GetComponent<IEnemyType>().Get()==Enums.OWNER.ISNOTENEMY){
			Debug.Log("MinaCommand_localPosition: "+transform.localPosition);
			Vector3 rowCol = GameController.Instance().getRowCol(transform.localPosition);
			Vector3 pos = GameController.Instance().correctPosition(transform.localPosition, rowCol);
			transform.localPosition = pos;
			GetComponent<IMoveable>().SetSpeed(Vector3.zero);
			GameObject[] bubbles = GameController.Instance().getNeighbours(rowCol);
			GameObject[] combineBubbles = bubbles.ToArray();
			foreach(GameObject a in bubbles){
				if(a == null) continue;
				combineBubbles = combineBubbles.Concat(GameController.Instance().getNeighbours(
					GameController.Instance().getRowCol(a.transform.localPosition))
				                                       ).ToArray();
			}
			GameController.Instance().destroyBubbles(
				combineBubbles
				);
			//Ejecutar sonido

			Invoke ("Destroy", killTimeOutSeconds);
		}
	}

	private void Destroy(){
		//[SOUND] mina explota
		GetComponent<IKillable> ().Kill ();
	}

	#endregion

	#region IParam implementation

	public void Set (Collider2D t)
	{
		collider2d = t;
	}

	public Collider2D Get ()
	{
		return collider2d;
	}

	#endregion
}
