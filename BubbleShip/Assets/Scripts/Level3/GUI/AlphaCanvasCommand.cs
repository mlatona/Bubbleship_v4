using UnityEngine;
using System.Collections;

public class AlphaCanvasCommand : MonoBehaviour, ICommand {

	public CanvasGroup canvas;

	#region ICommand implementation

	public void Run ()
	{
		Debug.Log ("AlphasCanvasCommand");
		canvas.alpha = 1;
		canvas.interactable = true;
		canvas.blocksRaycasts = true;
	}

	#endregion




}
