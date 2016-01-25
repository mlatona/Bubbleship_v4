using UnityEngine;
using System.Collections;

public class GameOverCommand : MonoBehaviour, ICommand {

	public CanvasGroup canvas;

	#region ICommand implementation

	public void Run ()
	{
		//Debug.Log ("AlphasCanvasCommand");
		canvas.alpha = 1;
		canvas.interactable = true;
		canvas.blocksRaycasts = true;
		Time.timeScale = 0;
		GameController.Instance ().paused = true;
		GameObject.FindGameObjectWithTag ("SoundController").GetComponent<SoundController> ().Stop ();
		GameObject.FindGameObjectWithTag ("SoundController").GetComponent<SoundController> ().PlayGameOver ();

	}

	#endregion




}
