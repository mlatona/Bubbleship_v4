using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour, ICollideCommand  {

	public int typeSp;
	private GameController gameController;
	private Collider2D collider2d;

	// Use this for initialization
	void Start () {
		gameController = GameController.Instance ();
	}



	#region ICommand implementation
	public void Run ()
	{
		//Si no tiene dueño
		if(GetComponent<IEnemyType>().Get()==Enums.OWNER.ANY){
			//Ejecutar sonido

			//notificar
			gameController.AddSp (typeSp);
			GetComponent<IKillable> ().Kill ();
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
