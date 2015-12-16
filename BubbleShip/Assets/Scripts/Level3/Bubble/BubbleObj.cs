using UnityEngine;
using System.Collections;

public class BubbleObj : MonoBehaviour, IBubbleMatrix
{

	public Vector3 rowCol;
	GameController gameController;

	public Enums.BUBBLECOLOR bubbleColor;
	public Sprite[] typeBubbles;

	void Awake ()
	{
		changeColor ((int)bubbleColor);
		gameController = GameController.Instance ();
	}

	public void changeColor(int bubbleCol){
		GetComponent<SpriteRenderer> ().sprite = typeBubbles [bubbleCol];
	}

	// Use this for initialization
	void Start ()
	{
			gameController.insert (gameObject, false);
	}


	/**
	 * Implements IBubbleMatrix, because it wants to be in the matrix
	 * 
	 * */
	public Vector3 GetRowCol(){ return rowCol;}
	public void SetRowCol(Vector3 rowColParam){rowCol = rowColParam;}
	
	public Enums.BUBBLECOLOR GetBubbleColor(){return bubbleColor;}
	public void SetBubbleColor(Enums.BUBBLECOLOR bubbleColorParam){bubbleColor = bubbleColorParam;}

}
