using UnityEngine;
using System.Collections;

public class BubbleWithWallCollide : MonoBehaviour ,ICollideCommand {
	
	Collider2D collider2d;
	
	#region ICommand implementation
	public void Run ()
	{
		IMoveable moveable = GetComponent<IMoveable> ();
		Vector3 speedParam = moveable.GetSpeed ();
		speedParam.x *= -1;
		moveable.SetSpeed (speedParam);
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
