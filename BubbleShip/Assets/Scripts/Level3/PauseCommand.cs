using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseCommand : MonoBehaviour, ICommand {

	GameController gameController;
	public CanvasGroup panelPausa;

	void Start(){
		gameController = GameController.Instance ();
		//panelPausa = GameObject.Find ("PanelPausa").GetComponent<CanvasGroup>();
	}

	#region ICommand implementation
	public void Run ()
	{
		if (gameController.paused) {
			Time.timeScale = 1;
			panelPausa.alpha = 0;
			gameController.paused = false;
		} else {
			Time.timeScale = 0;
			panelPausa.alpha = 1;
			gameController.paused = true;
		}
	}

	#endregion

}
