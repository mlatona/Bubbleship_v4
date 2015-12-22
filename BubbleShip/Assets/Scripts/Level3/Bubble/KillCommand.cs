using UnityEngine;
using System.Collections;

public class KillCommand : MonoBehaviour, ICommand {

	Animator animator;
	IMoveable moveable;

	void Awake(){
		animator = GetComponent<Animator>();
		moveable = GetComponent<IMoveable> ();
	}

	#region ICommand implementation

	public void Run ()
	{
		//Debug.Log ("KillCommand");
		moveable.SetSpeed (Vector3.zero);
		animator.SetInteger ("color", -1);
	}

	#endregion

}
