using UnityEngine;
using System.Collections;

public class BubbleWithBubbleCollide : MonoBehaviour ,ICollideCommand {
	
	Collider2D collider2d;
	GameController gameController;

	public void Start(){
		gameController = GameController.Instance ();
	}
	
	#region ICommand implementation
	public void Run ()
	{
		IMoveable moveable = GetComponent<IMoveable> ();
		IOwner owner = GetComponent<IOwner> ();
		IOwner otherOwner = collider2d.gameObject.GetComponent<IOwner> ();
		if (owner.Get ()!=null 
		    && otherOwner.Get ()==null) {
			//Debug.Log("BubbleWithBubbleCollide: "+owner.Get().tag);
			moveable.SetSpeed(Vector3.zero);
			gameController.insert (gameObject, true);
			owner.Set(null);
			gameController.destroyBubbles (gameObject);
		}
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
