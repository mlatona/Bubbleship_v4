using UnityEngine;
using System.Collections;

public class Scoreable : MonoBehaviour, IScoreable {

	GameController gameController;
	public int score;

	// Use this for initialization
	void Awake () {
		gameController = GameController.Instance ();
	}



	#region IScoreable implementation
	public void Score ()
	{
		gameController.Score (score);
	}
	#endregion
}
