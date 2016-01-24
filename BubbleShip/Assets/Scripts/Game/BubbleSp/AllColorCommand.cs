using UnityEngine;
using System.Collections;

public class AllColorCommand : MonoBehaviour, ICollideCommand {
	
	Collider2D collider2d;
	public float killTimeOutSeconds;
	
	#region ICommand implementation
	
	public void Run ()
	{
		//Si tiene dueño
		if(GetComponent<IEnemyType>().Get()==Enums.OWNER.ISNOTENEMY){
			Debug.Log("AllColorCommand_localPosition: "+transform.localPosition);
			Enums.BUBBLECOLOR color = collider2d.gameObject.GetComponent<BubbleObj>().bubbleColor;
			Vector3 rowCol = GameController.Instance().getRowCol(transform.localPosition);
			Vector3 pos = GameController.Instance().correctPosition(transform.localPosition, rowCol);
			transform.localPosition = pos;
			GetComponent<IMoveable>().SetSpeed(Vector3.zero);
			ArrayList cpV = (ArrayList)GameController.Instance().getVisibles().Clone();
			foreach(BubbleObj a in cpV){
				if(color == a.bubbleColor){
					//Debug.Log(a);
					if(a == null && !ReferenceEquals(a, null)){
						GameController.Instance().getVisibles().Remove(a);
					}else{
						GameController.Instance().destroy(a.gameObject);
					}
				}
			}
			//Ejecutar sonido
			
			Invoke ("Destroy", killTimeOutSeconds);
		}
	}
	
	private void Destroy(){
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
