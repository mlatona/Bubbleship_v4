using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {

	GameController gameController;
	public string prefixText;
	public string suffixText;
	Text text;

	// Use this for initialization
	void Start () {
		gameController = GameController.Instance ();
		text = GetComponent<Text> ();
		text.text = prefixText+gameController.GetTotalScore ()+suffixText;
	}
	
	// Update is called once per frame
	void Update () {
		text.text = prefixText+gameController.GetTotalScore ()+suffixText;
	}
}
