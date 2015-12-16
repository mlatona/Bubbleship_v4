using UnityEngine;
using System.Collections;

public class DamageCollide : MonoBehaviour,ICollideCommand {

	Collider2D collider2d;

	#region ICommand implementation
	public void Run ()
	{
		//Si es mia no me hace daño
		IOwner otherOwner = collider2d.gameObject.GetComponent<IOwner> ();
		IOwner owner = GetComponent<IOwner> ();
		//Ambos son cosas distintas de poseidas
		if ((owner == null && otherOwner == null)
		//Una es poseida y le pertenece
			|| (!(owner != null && owner.Get()!=null && owner.Get ().tag == collider2d.tag)
		    && !(otherOwner != null && otherOwner.Get()!=null && otherOwner.Get ().tag == tag))) {
			GetComponent<IDamageable> ().Damage (collider2d.GetComponent<IDamageable> ().GetDamageTaken ());
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
