using UnityEngine;
using System.Collections;

public class BubbleWithBubbleCollide : MonoBehaviour ,ICollideCommand {
	
	Collider2D collider2d;
	GameController gameController;
	IOwner owner;
	IDamageable damageable;

	public void Start(){
		gameController = GameController.Instance ();
		damageable = gameObject.GetComponent<IDamageable>();
		owner = GetComponent<IOwner> ();
	}
	
	#region ICommand implementation
	public void Run ()
	{
		IMoveable moveable = GetComponent<IMoveable> ();

		IOwner otherOwner = collider2d.gameObject.GetComponent<IOwner> ();
		//Bola que impacta con grupo de bolas
		if (owner.Get () != null 
			&& otherOwner.Get () == null) {
			//Debug.Log("BubbleWithBubbleCollide: "+owner.Get().tag);
			moveable.SetSpeed (Vector3.zero);
			gameController.insert (gameObject, true);
			owner.Set (null);
			gameController.destroyBubbles (gameObject);
		} 
		//Bubble enemy that imact with bubble Ship
		else if(owner.Get () != null 
		        && otherOwner.Get () != null && owner.Get ().gameObject.tag!=otherOwner.Get ().gameObject.tag){
			damageable.Damage(otherOwner.Get ().gameObject.GetComponent<IDamageable>().GetDamageTaken());
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
