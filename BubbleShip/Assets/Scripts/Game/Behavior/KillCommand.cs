using UnityEngine;
using System.Collections;

public class KillCommand : MonoBehaviour, ICommand {

	Animator animator;
	IMoveable moveable;
	public string parameter;

	void Awake(){
		animator = GetComponent<Animator>();
		moveable = GetComponent<IMoveable> ();
	}

	#region ICommand implementation

	public void Run ()
	{
		//Debug.Log ("KillCommand");
		moveable.SetSpeed (Vector3.zero);
		animator.SetInteger (parameter, -1);
	}

	#endregion

}
