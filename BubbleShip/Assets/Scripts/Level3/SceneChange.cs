using UnityEngine;
using System.Collections;

public class SceneChange : MonoBehaviour,ICollisionable,ICommand {

	public int scene;

	public void Run(){
		Application.LoadLevel (scene);
	}

	#region ICollisionable implementation
	public void CollideWithBubble (GameObject collideObject){}
	public void CollideWithSpaceShip (GameObject collideObject){
		Run ();
	}
	public void CollideWithLeftWall (GameObject collideObject){}
	public void CollideWithRightWall (GameObject collideObject){}
	#endregion
}
