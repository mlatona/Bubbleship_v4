using UnityEngine;
using System.Collections;

public class DamageCollide : MonoBehaviour,ICollideCommand {

	Collider2D collider2d;

	#region ICommand implementation
	public void Run ()
	{
		//Si es mia no me hace daño
		IEnemyType otherEnemy = collider2d.gameObject.GetComponent<IEnemyType> ();
		IEnemyType enemy = GetComponent<IEnemyType> ();
		if (enemy.Get()==Enums.OWNER.ISENEMY && otherEnemy.Get()==Enums.OWNER.ISNOTENEMY
		    || enemy.Get()==Enums.OWNER.ANY && otherEnemy.Get()==Enums.OWNER.ISNOTENEMY
		    || enemy.Get()==Enums.OWNER.ISNOTENEMY && otherEnemy.Get()!=Enums.OWNER.ISNOTENEMY) {
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
