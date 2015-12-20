using UnityEngine;
using System.Collections;

public class SceneChange : MonoBehaviour,ICommand {

	public int scene;

	public void Run(){
		Application.LoadLevel (scene);
	}
	
}
