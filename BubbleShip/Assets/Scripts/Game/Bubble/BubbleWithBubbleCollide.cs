using UnityEngine;
using System.Collections;

public class BubbleWithBubbleCollide : MonoBehaviour ,ICollideCommand {
	
	Collider2D collider2d;
	GameController gameController;
	IEnemyType enemy;
	IDamageable damageable;

	public void Start(){
		gameController = GameController.Instance ();
		damageable = gameObject.GetComponent<IDamageable>();
		enemy = GetComponent<IEnemyType> ();
	}
	
	#region ICommand implementation
	public void Run ()
	{
		IMoveable moveable = GetComponent<IMoveable> ();

		IEnemyType otherEnemy = collider2d.gameObject.GetComponent<IEnemyType> ();
		//Debug.Log (enemy.Get()+"-"+otherEnemy.Get());
		//Bola que impacta con grupo de bolas
		if (enemy.Get()==Enums.OWNER.ISNOTENEMY && otherEnemy.Get()==Enums.OWNER.ANY) {
			//Debug.Log("BubbleWithBubbleCollide: "+owner.Get().tag);
			moveable.SetSpeed (Vector3.zero);
			gameController.insert (gameObject, true);
			enemy.Set (Enums.OWNER.ANY);
			gameController.destroyBubbles (gameObject);
		} 
		//Bubble enemy that imact with bubble Ship
		else if(enemy.Get()==Enums.OWNER.ISNOTENEMY && otherEnemy.Get()==Enums.OWNER.ISENEMY 
		        || enemy.Get()==Enums.OWNER.ISENEMY && otherEnemy.Get()==Enums.OWNER.ISNOTENEMY){
			damageable.Damage(collider2d.gameObject.GetComponent<IDamageable>().GetDamageTaken());
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
