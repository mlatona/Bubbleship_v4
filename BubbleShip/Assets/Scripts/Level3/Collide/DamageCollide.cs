using UnityEngine;
using System.Collections;

public class DamageCollide : MonoBehaviour,ICollideCommand {

	Collider2D collider2d;

	#region ICommand implementation
	public void Run ()
	{
		GetComponent<IDamageable> ().Damage (collider2d.GetComponent<IDamageable>().GetDamageTaken());
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
