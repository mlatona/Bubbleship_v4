using UnityEngine;
using System.Collections;

public class BubbleObj : MonoBehaviour, IBubbleMatrix, IOwner
{

	public Vector3 rowCol;
	GameController gameController;
	GameObject owner;
	Animator animator;

	public Enums.BUBBLECOLOR bubbleColor;

	void Awake ()
	{
		
		animator = GetComponent<Animator>();
		changeColor ((int)bubbleColor);
		gameController = GameController.Instance ();
	}

	public void changeColor(int bubbleColorParam){
		animator.SetInteger("color",bubbleColorParam);
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
