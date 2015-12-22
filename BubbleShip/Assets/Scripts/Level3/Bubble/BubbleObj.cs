using UnityEngine;
using System.Collections;

public class BubbleObj : MonoBehaviour, IBubbleMatrix, IOwner
{

	public Vector3 rowCol;
	GameController gameController;
	public GameObject owner;
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

	public int GetColor(){
		return animator.GetInteger ("color");
	}

	// Use this for initialization
	void Start ()
	{
		if (owner == null) {
			gameController.insert (gameObject, false);
		}
	}

	void Update(){
		if(GetColor() != -1){
			changeColor ((int)bubbleColor);
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
