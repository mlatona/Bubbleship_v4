using UnityEngine;
using System.Collections;

public class SceneChange : MonoBehaviour,ICommand {

	public int scene;
	public bool resetGame = false;

	public void Run(){
		Application.LoadLevel (scene);
		if(resetGame){
			GameController.Instance().resetGame();
		}
	}
	
}
