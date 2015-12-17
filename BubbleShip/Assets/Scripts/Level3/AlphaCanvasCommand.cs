using UnityEngine;
using System.Collections;

public class AlphaCanvasCommand : MonoBehaviour, ICommand {

	public CanvasGroup canvas;

	#region ICommand implementation

	public void Run ()
	{
		canvas.alpha = 1;
	}

	#endregion




}
