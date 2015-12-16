using UnityEngine;
using System.Collections;

public class BubbleObj : MonoBehaviour, IBubbleMatrix, IOwner
{

	public Vector3 rowCol;
	GameController gameController;
	GameObject owner;

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
		if (owner == null) {
			gameController.insert (gameObject, false);
		}
	}


	#region IBubbleMatrix implementation
	public Vector3 GetRowCol(){ return rowCol;}
	public void SetRowCol(Vector3 rowColParam){rowCol = rowColParam;}
	
	public Enums.BUBBLECOLOR GetBubbleColor(){return bubbleColor;}
	public void SetBubbleColor(Enums.BUBBLECOLOR bubbleColorParam){bubbleColor = bubbleColorParam;}
	#endregion

	#region IParam implementation
	public void Set (GameObject t)
	{
		owner = t;
	}
	public GameObject Get ()
	{
		return owner;
	}
	#endregion
}
